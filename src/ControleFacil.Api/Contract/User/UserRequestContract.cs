namespace ControleFacil.Api.Contract.User
{
    public class UserRequestContract : UserLoginRequestContract
    {
        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Nickname { get; set; } = string.Empty;

        public string? Avatar { get; set; } = string.Empty;

        public string? Role { get; set; } = string.Empty;

        public string? Title { get; set; } = string.Empty;

        public string? ShortTitle { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public DateTime Birth { get; set; }

        public int? CbxId { get; set; }

        public int? FideId { get; set; }

        public bool Active { get; set; }
    }
}