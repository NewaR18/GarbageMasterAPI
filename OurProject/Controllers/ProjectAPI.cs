using Microsoft.AspNetCore.Mvc;
using OurProject.Model;
using OurProject.Repository;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectAPI : Controller
    {
        private readonly MyRepo _repo;
        public ProjectAPI()
        {
            _repo = new MyRepo();
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult RegisterUser(Register r1)
        {
            string s=_repo.RegisterUser(r1);
            JsonResult jsonresult=Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult LoginUser(Login l1)
        {
            string s=_repo.LoginUser(l1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetUsers()
        {
            var val = _repo.Users();
            return Ok(val);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetSpecificUser(string Username)
        {
            var val = _repo.DatafromUserTable(Username);
            return Ok(val);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult InsertMessage(Messages m1)
        {
            string s = _repo.InsertMessage(m1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
    }
}
