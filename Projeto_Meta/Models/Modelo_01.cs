using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto_Meta.Models
{
    public class Modelo_01
    {
        public int id { get; set; }

        [Required]
        public string valores { get; set;}
        [Required]
        public int alvo { get; set; }
        public string resultado { get; set; }
    }
}