using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Domain.Models
{
    public class Tournament
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The 'Name' field is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'ChessResults' field is required.")]
        public string ChessResults { get; set; } = string.Empty;

        [Required(ErrorMessage = "The 'Date' field is required.")]
        public DateTime Date { get; set; }

        public virtual ICollection<PlayerPodiums>? PlayerPodiums { get; set; }

        public virtual ICollection<PlayerTournaments>? PlayerTournaments { get; set; }
    }
}
