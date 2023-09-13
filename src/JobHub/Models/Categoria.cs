using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHub2.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [StringLength(100, ErrorMessage ="O tamanho máximo é 100 caracteres")]
        [Display(Name ="Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Informe a descrição da categoria")]
        [StringLength(500, ErrorMessage ="O tamanho máximo é 500 caracteres")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        public List<Vaga> Vagas { get; set; }
    }
}
