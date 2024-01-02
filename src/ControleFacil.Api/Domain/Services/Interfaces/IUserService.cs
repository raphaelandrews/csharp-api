using ControleFacil.Api.Contract.User;

namespace ControleFacil.Api.Damain.Services.Interfaces
{
    public interface IUserService : IService<UserRequestContract, UserResponseContract, long>
    {
        Task<UserLoginResponseContract> Authenticate(UserLoginRequestContract userLoginRequest);
        Task<UserResponseContract> Get(string email);
    }
}