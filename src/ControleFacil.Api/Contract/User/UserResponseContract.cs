namespace ControleFacil.Api.Contract.User
{
    public class UserResponseContract : UserRequestContract
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}