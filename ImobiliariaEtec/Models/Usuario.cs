using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImobiliariaEtec.Models
{
    public class Usuario : IdentityUser
    {
        [StringLength(60)]
        public string Nome { get; set; }

        [NotMapped]
        [Display(Name = "Perfil")]
        public string Perfis { get; set; }

    }
}
