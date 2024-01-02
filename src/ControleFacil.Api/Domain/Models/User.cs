using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The 'Email' field is mandatory.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Password' field is mandatory.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Name' field is mandatory.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Username' field is mandatory.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Nickname' field is mandatory.")]
        public string Nickname { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        [DefaultValue(1900)]
        public int Blitz { get; set; }

        [DefaultValue(1900)]
        public int Rapid { get; set; }

        [DefaultValue(1900)]
        public int Classic { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ShortTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'City' field is mandatory.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Birth' field is mandatory.")]
        public DateTime Birth { get; set; }

        public int CbxId { get; set; }

        public int FideId { get; set; }

        public bool Active { get; set; }

        public PlayerNorms PlayerNorms { get; set; }

        public PlayerPodiums PlayerPodiums { get; set; }

        public PlayerTournaments PlayerTournaments { get; set; }
   
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
