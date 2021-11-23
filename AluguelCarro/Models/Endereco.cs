using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Use menos caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Valor inválido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Estado { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}