using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Damain.Models
{
    public abstract class Titulo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUser { get; set; }

        public User User { get; set; }

        [Required]
        public long IdNaturezaDeLancamento { get; set; }

        public NaturezaDeLancamento NaturezaDeLancamento { get; set; }

        [Required(ErrorMessage = "O campo de Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo de ValorOriginal é obrigatório.")]
        public double ValorOriginal { get; set; }
        
        public string? Observacao { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set;} 
        
        [Required(ErrorMessage = "O campo de DataVencimento é obrigatório.")]
        public DateTime DataVencimento { get; set;} 

        public DateTime? DataInativacao { get; set; }

        public DateTime? DataReferencia { get; set; }

    }
}