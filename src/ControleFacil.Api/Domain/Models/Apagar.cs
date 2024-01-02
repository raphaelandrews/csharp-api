using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Damain.Models
{
    public class Apagar : Titulo
    {
        [Required(ErrorMessage = "O campo de ValorPago é obrigatório.")]
        public double ValorPago { get; set; }

        public DateTime? DataPagamento { get; set; }
    }
}