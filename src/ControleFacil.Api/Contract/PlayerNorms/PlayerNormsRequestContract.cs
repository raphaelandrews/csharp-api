namespace ControleFacil.Api.Contract.PlayerNorms
{
    public class PlayerNormsRequestContract
    {
        public string Norm { get; set; } = string.Empty;

        public long UserId { get; set; }
    }
}