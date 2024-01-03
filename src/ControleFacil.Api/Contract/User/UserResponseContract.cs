namespace ControleFacil.Api.Contract.User
{
    public class UserResponseContract : UserRequestContract
    {
        public long Id { get; set; }

        public int Blitz { get; set; }

        public int Rapid { get; set; }

        public int Classic { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}