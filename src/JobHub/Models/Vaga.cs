using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHub2.Models
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

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
