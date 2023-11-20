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
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Perfil == Perfil.Candidato && string.IsNullOrWhiteSpace(Candidato?.Nome))
            {
                yield return new ValidationResult("Obrigatório Informar o nome do candidato!", new[] { "Candidato.Nome" });
            }
            else if (Perfil == Perfil.Empresa && string.IsNullOrWhiteSpace(Empresa?.NomeDaEmpresa))
            {
                yield return new ValidationResult("Obrigatório Informar o nome da empresa!", new[] { "Empresa.NomeDaEmpresa" });
            }
            // Add other conditional validations here
        }
    }
}
