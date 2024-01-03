namespace ControleFacil.Api.Contract.Tournament
{
    public class TournamentRequestContract
    {
        public string Name { get; set; } = string.Empty;

        public string ChessResults { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}