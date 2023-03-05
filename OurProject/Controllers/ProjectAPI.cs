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
        [HttpPost]
        [Route("[Action]")]
        public IActionResult GetSpecificUser(Usernameonly u1)
        {
            var val = _repo.DatafromUserTable(u1);
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
        [HttpPost]
        [Route("[Action]")]
        public IActionResult UpdateProfile(Changes c1)
        {
            string s = _repo.UpdateUsersTable(c1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult UpdateGarbageData(Garbages g1)
        {
            var s = _repo.InsertWasteData(g1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAverage()
        {
            var s = _repo.getaverage();
            return Ok(s);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult CheckEmail(Emailonly e1)
        {
            string s = _repo.CheckEmail(e1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult SendEmail(Emailonly e1)
        {
            var s = _repo.sendemail(e1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult ResetPassword(ResetPassword p1)
        {
            string s = _repo.ResetPassword(p1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult HistoryTable(Usernameonly u1)
        {
            var s = _repo.Extractdata(u1);
            return Ok(s);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult GetImage(Usernameonly u1)
        {
            string s = _repo.GetImage(u1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
        [HttpPost]
        [Route("[Action]")]
        public IActionResult InsertImage(UsernameAndImage u1)
        {
            string s = _repo.InsertImage(u1);
            JsonResult jsonresult = Json(new { Result = s });
            return Ok(jsonresult.Value);
        }
    }
}
