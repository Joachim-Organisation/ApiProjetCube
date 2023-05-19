using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjetCube.Models
{
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public bool IsActiver { get; set; }
        public string password { get; set; }

        public virtual Role ?Role { get; set; }

        //public virtual List<MessageForum> ?MessagesForums { get; set; }

        public virtual List<Ressource> ?Ressources { get; set; }
        //public virtual List<SubjectForum> ?SubjectsForums { get; set;}

    }
}
