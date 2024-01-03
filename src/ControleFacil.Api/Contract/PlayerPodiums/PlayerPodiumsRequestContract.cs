namespace ControleFacil.Api.Contract.PlayerPodiums
{
    public class PlayerPodiumsRequestContract
    {
        public int Place { get; set; }

        public long UserId { get; set; }

        public long TournamentId { get; set; }
    }
}