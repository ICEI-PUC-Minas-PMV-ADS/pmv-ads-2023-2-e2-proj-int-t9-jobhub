using JobHub.Models;
using System.ComponentModel.DataAnnotations;

namespace JobHub.ViewModels
{
    public class EmpresaViewModel
    {
        [Required(ErrorMessage = "Obrigatório Informar o nome da empresa!")]
        public string NomeDaEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string SobreEmpresa { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }

        public ICollection<Vaga> VagasCriadas { get; set; }
    }
}
