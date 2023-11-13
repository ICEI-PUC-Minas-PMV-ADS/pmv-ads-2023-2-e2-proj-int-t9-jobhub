using JobHub.Models;
using System.ComponentModel.DataAnnotations;

namespace JobHub.ViewModels
{
    public class CandidatoViewModel
    {
        [Required(ErrorMessage = "Obrigatório Informar o nome!")]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string SobreMim { get; set; }
        public string AreaDeInteresse { get; set; }
        public int Telefone { get; set; }
        public string Habilidades { get; set; }
        public string Experiencia { get; set; }
        public string Formacao { get; set; }
        public string CvURL { get; set; }
        public ICollection<VagaCandidato> VagasAplicadas { get; set; }
    }
}
