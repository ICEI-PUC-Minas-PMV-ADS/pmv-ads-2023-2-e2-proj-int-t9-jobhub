using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHub.Models
{
    [Table("Vagas")]
    public class Vaga
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o título da vaga")]
        [StringLength(100, ErrorMessage ="O tamanho máximo é 100 caracteres")]
        [Display(Name ="Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Informe a descrição da vaga")]
        [StringLength(500, ErrorMessage ="O tamanho máximo é 500 caracteres")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        
        public string Empresa { get; set; }

        
        public string Skills { get; set; }

        
        public string Local { get; set; }

       
        public string FormaDeTrabalho { get; set; }

        
        public string Nivel { get; set; }

        
        public string Salario { get; set; }
        
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        virtual public Categoria Categoria { get; set; }
    }
}
