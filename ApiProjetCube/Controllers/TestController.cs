using ApiProjetCube.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageForum>>> GetTest()
        {
            var messageA = new MessageForum { Id = 1, Content = "Test A", DateCreation = DateTimeOffset.Now, IdSubjectForum = 0, IdUtilisateur = 0 };

            var messageB = new MessageForum { Id = 2, Content = "Test B", DateCreation = DateTimeOffset.Now, IdSubjectForum = 1, IdUtilisateur = 1 };

            var list = new List<MessageForum> { messageA, messageB };

            return list;
        }
    }
}
