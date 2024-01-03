using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class PlayerPodiums
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The 'Place' field is required.")]
        public int Place { get; set; }

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public long UserId { get; set; }

        public required User User { get; set; }

        [Required(ErrorMessage = "The 'TournamentId' field is required.")]
        public long TournamentId { get; set; }

        public required Tournament Tournament { get; set; }
    }
}
