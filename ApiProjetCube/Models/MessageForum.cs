using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetCube.Models
{
    public class MessageForum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        public string Content { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
    }
}
