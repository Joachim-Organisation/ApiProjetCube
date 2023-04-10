using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetCube.Models
{
    public partial class Ressource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }

        public string TypeRelation { get; set; }
        public string Title { get; set; }
        public string contents { get; set; }

        public virtual Category Category { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public virtual List<DocumentImage> ?DocumentImages { get; set; }

        public virtual List<DocumentPdf> ?DocumentPdfs { get; set; }

    }
}
