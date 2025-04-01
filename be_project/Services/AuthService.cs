using be_project.Models;
using be_project.Repositories;
using Google.Apis.Auth;
using Google.Apis.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace be_project.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, System.Net.Http.IHttpClientFactory httpClientFactory, IUserRepository userRepository)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _userRepository = userRepository;
        }

        public async Task<string> LoginWithGoogleAsync()
        {
            var redirectUri = $"{_configuration["AppUrl"]}/api/Auth/login/google/callback";
            var url = $"https://accounts.google.com/o/oauth2/v2/auth?client_id={_configuration["GoogleOAuth:ClientId"]}&redirect_uri={redirectUri}&response_type=code&scope=email%20profile%20openid&access_type=offline";
            return url;
        }

        public async Task<User> GetUserFromGoogleAsync(string idToken)
        {
            var payload = await VerifyGoogleToken(idToken);
            var user = await _userRepository.GetUserByEmailAsync(payload.Subject);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Tài khoản của bạn chưa được đăng ký. Vui lòng liên hệ Admin.");
            }

            return user;
        }

        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _configuration["GoogleOAuth:ClientId"] }
            };
            return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
        }

        public async Task<TokenResult> GetTokenFromGoogle(string code)
        {
            var tokenRequest = new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", _configuration["GoogleOAuth:ClientId"] },
                { "client_secret", _configuration["GoogleOAuth:ClientSecret"] },
                { "redirect_uri", $"{_configuration["AppUrl"]}/api/Auth/login/google/callback" },
                { "grant_type", "authorization_code" }
            };

            var requestContent = new FormUrlEncodedContent(tokenRequest);
            var response = await _httpClient.PostAsync("https://oauth2.googleapis.com/token", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Invalid token response: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResult>(responseContent);
            if (string.IsNullOrEmpty(tokenResponse?.IdToken))
            {
                throw new Exception("Id token is null or empty.");
            }

            return tokenResponse;
        }
        public async Task<User> AddUserAsync(UserDto userDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Người dùng đã tồn tại.");
            }

            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Bu = userDto.Bu,
                Role = userDto.Role,
                RegionId = userDto.RegionId,
                UserLocations = userDto.UserLocations?.Select(loc => new UserLocation
                {
                    LocationId = loc.LocationId,
                }).ToList() 
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }
    }
}
