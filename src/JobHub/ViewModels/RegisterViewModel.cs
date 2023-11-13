using JobHub.Models;
using System.ComponentModel.DataAnnotations;

namespace JobHub.ViewModels
{
    public class RegisterViewModel
    {
        public CandidatoViewModel Candidato { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public Perfil Perfil { get; set; }
        [Required(ErrorMessage = "Obrigatório Informar o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
