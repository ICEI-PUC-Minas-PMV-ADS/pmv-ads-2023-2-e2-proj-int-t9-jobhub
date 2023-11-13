using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace JobHub.Models

{
    [Table("UsuariosEmpresa")]
    public class UsuarioEmpresa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o nome da Empresa!")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o CNPJ!")]
        public int Cnpj { get; set; }


        [Required(ErrorMessage = "Obrigatório Informar o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }




    }
}
