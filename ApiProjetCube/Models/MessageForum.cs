using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProjetCube.Models
{
    public class MessageForum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }

        [ForeignKey("SubjectForum")]
        public int IdSubjectForum { get; set; }

        public string Content { get; set; }
        public DateTimeOffset? DateCreation { get; set; }

        public virtual Utilisateur ?Utilisateur { get; set; }

        [JsonIgnore]
        public virtual SubjectForum ?SubjectForum { get; set; }
    }
}
