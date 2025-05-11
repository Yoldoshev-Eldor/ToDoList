using ToDoList.Core.Errors;
using ToDoList.DataAccess.Entities;
using ToDoList.Repository.Services;
using ToDoList.Service.Dtos;
using ToDoList.Service.Services.Security;

namespace ToDoList.Service.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository UserRepository;
    private readonly ITokenService TokenService;


    public AuthService(ITokenService tokenService, IUserRepository userRepository)
    {
        TokenService = tokenService;
        UserRepository = userRepository;
    }

    public async Task<LoginResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
    {
        var user = await UserRepository.SelectUserByUserNameAsync(userLoginDto.UserName);

        var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.Password, user.Salt);

        if (checkUserPassword == false)
        {
            throw new UnauthorizedException("UserName or password incorrect");
        }

        var userGetDto = new UserGetDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };

        var token = TokenService.GenerateToken(userGetDto);
        var loginResponseDto = new LoginResponseDto()
        {
            AccessToken = token,
            TokenType = "Barier",
            Expires = 24
        };

        return loginResponseDto;
    }

    public async Task<long> SignUpUserAsync(UserCreateDto userCreateDto)
    {
        var tupleFromHasher = PasswordHasher.Hasher(userCreateDto.Password);
        var user = new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            UserName = userCreateDto.UserName,
            Email = userCreateDto.Email,
            PhoneNumber = userCreateDto.PhoneNumber,
            Password = tupleFromHasher.Hash,
            Salt = tupleFromHasher.Salt
        };

        return await UserRepository.InsertUserAsync(user);
    }
}
