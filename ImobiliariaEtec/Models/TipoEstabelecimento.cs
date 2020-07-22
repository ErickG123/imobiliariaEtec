using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaEtec.Models
{
    [Table("TipoEstabelecimento")]
    public class TipoEstabelecimento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Tipo de Estabelecimento")]
        [Required(ErrorMessage = "Por favor, informe o Nome do Tipo de Estabelecimento")]
        [StringLength(50, ErrorMessage = "O Nome do Tipo de Estabelecimento deve possuir no máximo 50 caracteres")]
        public string Nome { get; set; }
    }
}
