using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Service.Dtos;
using ToDoList.Service.Services;

namespace ToDoList.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService AuthService;
    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost("signUp")]
    public async Task<long> SignUp(UserCreateDto userCreateDto)
    {
        return await AuthService.SignUpUserAsync(userCreateDto);
    }

    [HttpPost("login")]
    public async Task<LoginResponseDto> Login(UserLoginDto userLoginDto)
    {
        return await AuthService.LoginUserAsync(userLoginDto);
    }
}