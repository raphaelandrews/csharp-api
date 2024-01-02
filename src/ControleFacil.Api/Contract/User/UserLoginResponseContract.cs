namespace ControleFacil.Api.Contract.User
{
    public class UserLoginResponseContract
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; }  = string.Empty;
    }
}