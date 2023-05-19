using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetCube.Models
{
    public class SubjectForum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int IdCategorie { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }


        public DateTime DateCreation { get; set; }
        public string Title { get; set; }
        public string text { get; set; }
        public virtual Category ?Category { get; set; }
        public virtual Utilisateur ?Utilisateur { get; set; }
        public virtual List<MessageForum> ?MessageForums { get; set; }
    }
}
