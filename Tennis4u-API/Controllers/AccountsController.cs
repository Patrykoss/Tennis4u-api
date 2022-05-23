using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Services.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IJwtService _jwtService;

        public AccountsController(IUserRepository userRepository, IUserAuthenticationService userAuthenticationService, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _userAuthenticationService = userAuthenticationService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerDTO)
        {
            var result = await _userRepository.AddNewUserAsync(registerDTO);

            return result switch
            {
                UserStatus.EmailNotAvailable => BadRequest("Email jest zajęty"),
                UserStatus.PhoneNumberNotAvailable => BadRequest("Numer telefonu jest zajęty"),
                UserStatus.DbError => StatusCode((int)HttpStatusCode.InternalServerError, "Błąd serwera"),
                UserStatus.UserAdded => NoContent(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmail(loginDTO);

            if (user is null)
                return BadRequest("Błędne dane logowania");

            var isPasswordCorrect = _userAuthenticationService.VerifyUserPassword(loginDTO.Password, user);

            if (!isPasswordCorrect)
                return BadRequest("Błędne dane logowania");

            var (refreshToken, refreshTokenExpirationDate) = _jwtService.GenerateRefreshToken();
            var isRefreshTokenAdded = await _userRepository.UpdateUserRefreshToken(user, refreshToken, refreshTokenExpirationDate);
            if (isRefreshTokenAdded == UserStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError);

            var accessToken = _jwtService.GenerateAccessToken(user);
            

            return Ok(new LoginResponseDTO
            {
                Name = user.FirstName + " " + user.LastName,
                Avatar = user.Avatar,
                AccessToken = _jwtService.WriteToken(accessToken),
                RefreshToken = refreshToken
            });
        }

    }
}
