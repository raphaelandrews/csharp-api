namespace ControleFacil.Api.Contract
{
    public class ModelErrorContract
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}