using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaEtec.Models
{
    [Table("Estabelecimento")]
    public class Estabelecimento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Nome do Estabelecimento")]
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, ErrorMessage = "A Descrição deve possuir no máximo 1000 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(60, ErrorMessage = "O Endereço deve possuir no máximo 60 caracteres")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(60, ErrorMessage = "O Bairro deve possuir no máximo 60 caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = "Por favor, informe o CEP do Estabelecimento")]
        [StringLength(8, ErrorMessage = "O Nome deve possuir no máximo 8 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Metragem do Estabelecimento")]
        public int Metragem { get; set; }

        [Display(Name = "Núm. de Quartos")]
        [Required(ErrorMessage = "Por favor, informe o Número de Quartos do Estabelecimento")]
        public int NumQuartos { get; set; }

        [Display(Name = "Núm. de Banheiros")]
        [Required(ErrorMessage = "Por favor, informe o Número de Banheiros do Estabelecimento")]
        public int NumBanheiros { get; set; }

        [Display(Name = "Valor (em R$)")]
        [Required(ErrorMessage = "Por favor, informe o Valor do Estabelecimento")]
        public decimal Valor { get; set; }

        [Display(Name = "Tipo de Estabelecimento")]
        [Required(ErrorMessage = "Por favor, informe o Tipo de Estabelecimento")]
        public int TipoEstabelecimentoId { get; set; }
        public TipoEstabelecimento TipoEstabelecimento { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Por favor, informe a Cidade do Estabelecimento")]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        [StringLength(300)]
        public string Foto { get; set; }

    }
}
