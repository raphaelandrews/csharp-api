using System.ComponentModel.DataAnnotations;

namespace ControleFacil.Api.Damain.Models
{
    public class NaturezaDeLancamento
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUser { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "O campo de Descrição é obrigatório.")]
        public string Descricao { get; set; } = string.Empty;

        public string? Observacao { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set;} 
        public DateTime? DataInativacao { get; set; }

    }
}