using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using ControleFacil.Api.Contract.User;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Domain.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly TokenService _tokenService;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            TokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserLoginResponseContract> Authenticate(UserLoginRequestContract userLoginRequest)
        {
            UserResponseContract user = await Get(userLoginRequest.Email);
        
            var hashPassword = GenerateHashPassword(userLoginRequest.Password);

            if(user is null || user.Password != hashPassword)
            {
                throw new AuthenticationException("Invalid User or Password.");
            }

            return new UserLoginResponseContract {
                Id = user.Id,
                Email = user.Email,
                Token = _tokenService.GenerateToken(_mapper.Map<User>(user))
            };        
        }
        public async Task<UserResponseContract> Post(UserRequestContract entidade, long idUser)
        {
            var user = _mapper.Map<User>(entidade);

            user.Password = GenerateHashPassword(user.Password);
            user.CreatedAt = DateTime.Now;

            user = await _userRepository.Post(user);

            return _mapper.Map<UserResponseContract>(user);
        }

        public async Task<UserResponseContract> Put(long id, UserRequestContract entidade, long idUser)
        {
            _ = await Get(id) ?? throw new NotFoundException("User não encontrado para atualização.");

            var user = _mapper.Map<User>(entidade);
            user.Id = id;
            user.Password = GenerateHashPassword(entidade.Password);

            user = await _userRepository.Put(user);

            return _mapper.Map<UserResponseContract>(user);
        }

        public async Task Inactivation(long id, long idUser)
        {
            var user = await _userRepository.Get(id) ?? throw new NotFoundException("User não encontrado para inativação.");
            
            await _userRepository.Delete(_mapper.Map<User>(user));
        }

        public async Task<IEnumerable<UserResponseContract>> Get(long idUser)
        {
            var users = await _userRepository.Get();

            return users.Select(user => _mapper.Map<UserResponseContract>(user));
        }

        public async Task<UserResponseContract> Get(long id, long idUser)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<UserResponseContract>(user);
        }

        public async Task<UserResponseContract> Get(string email)
        {
            var user = await _userRepository.Get(email);
            return _mapper.Map<UserResponseContract>(user);
        }

        private string GenerateHashPassword(string senha)
        {
            string hashPassword;

            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesPassword = Encoding.UTF8.GetBytes(senha);
                byte[] bytesHashPassword = sha256.ComputeHash(bytesPassword);
                hashPassword = BitConverter.ToString(bytesHashPassword).Replace("-","").Replace("-","").ToLower();
            }
            
            return hashPassword;
        }
    }
}