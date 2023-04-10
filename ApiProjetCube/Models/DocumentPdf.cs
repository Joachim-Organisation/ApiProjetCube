using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetCube.Models
{
    public class DocumentPdf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Ressource")]
        public int IdRessource { get; set; }
        public string LienPdf { get; set; }
        public virtual Ressource Ressource { get; set; }

    }
}
