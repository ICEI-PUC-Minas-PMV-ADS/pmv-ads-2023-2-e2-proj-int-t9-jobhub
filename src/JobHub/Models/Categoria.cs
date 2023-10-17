using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobHub.Models
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
<<<<<<< HEAD

=======
        
>>>>>>> fe9023544c9f8d1030d133478b63aa31666340c1
        public List<Vaga> Vagas { get; set; }
    }
}
