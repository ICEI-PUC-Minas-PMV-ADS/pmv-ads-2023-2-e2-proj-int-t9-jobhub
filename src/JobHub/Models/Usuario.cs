using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace JobHub.Models

{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Candidato,
        Empresa
    }

    public class Candidato : Usuario
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

    public class Empresa : Usuario
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
