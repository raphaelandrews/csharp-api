namespace ControleFacil.Api.Contract.PlayerTournaments
{
    public class PlayerTournamentsRequestContract
    {
        public string RatingType { get; set; } = string.Empty;

        public int OldRating { get; set; }

        public int Variation { get; set; }

        public long UserId { get; set; }

        public long TournamentId { get; set; }
    }
}