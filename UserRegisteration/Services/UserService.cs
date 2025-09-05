using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using UserRegisteration.DTOs;
using UserRegisteration.Interfaces;
using BCrypt.Net;
using UserRegisteration.Entities;
using UserRegisteration.Helpers;
namespace UserRegisteration.Services

{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _Mapper;
        private readonly JWTHelper _jwt;

        public UserService(IUnitOfWork unitOfWork, IMapper Map , JWTHelper jwt)
        {
            this._unitOfWork = unitOfWork;
            this._Mapper = Map;
            this._jwt = jwt;

        }
        public async Task<AuthResponseDto> LoginAsync(LoginUserDto dto)
        {
            var user = (await _unitOfWork.Users.GetAllAsync()).FirstOrDefault(e => e.Email == dto.Email);
             
                
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash)) {
                return null;
            }
            return new AuthResponseDto { UserName = user.Name, Token = _jwt.GenerateToken(user) };
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            var exiting = (await _unitOfWork.Users.GetAllAsync())
                .FirstOrDefault(e => e.Email == dto.Email);
            if (exiting != null) return null;
            var user = new User

            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SavechangesAsync();
            return new AuthResponseDto { UserName = user.Name, Token = _jwt.GenerateToken(user) };

        }
    }
}
