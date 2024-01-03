using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class PlayerTournaments
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The 'RatingType' field is required.")]
        public string RatingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'OldRating' field is required.")]

        public int OldRating { get; set; }

        [Required(ErrorMessage = "The 'Variation' field is required.")]
        public int Variation { get; set; }

        [Required(ErrorMessage = "The 'UserId' field is required.")]
        public long UserId { get; set; }

        public required User User { get; set; }

        [Required(ErrorMessage = "The 'TournamentId' field is required.")]
        public long TournamentId { get; set; }

        public required Tournament Tournament { get; set; }
    }
}
