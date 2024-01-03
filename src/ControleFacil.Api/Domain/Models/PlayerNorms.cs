using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class PlayerNorms
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The 'Norm' field is required.")]
        public string Norm { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public long UserId { get; set; }

        public required User User { get; set; }
    }
}

