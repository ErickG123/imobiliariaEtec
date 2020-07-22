using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaEtec.Models
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Por favor, informe o Nome da Cidade")]
        [Display(Name = "Nome da Cidade")]
        [StringLength(50, ErrorMessage = "O Nome da Cidade deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Estado")]
        [StringLength(2, ErrorMessage = "O Estado da Cidade deve possuir no máximo 2 caracteres", MinimumLength = 2)]
        public string UF { get; set; }

        [NotMapped]
        public string NomeCompleto { get => Nome + " (" + UF + ")"; }

    }
}
