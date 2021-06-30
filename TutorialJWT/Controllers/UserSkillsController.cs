using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialJWT.Model;

namespace TutorialJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUserSkill()
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var data = db.UserSkills.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Create(UserSkill userSkill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();

            db.UserSkills.Add(userSkill);
            db.SaveChanges();
            return new JsonResult("Add sukses");
        }

        [HttpPatch]
        public JsonResult Update(UserSkill userSkill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Entry(userSkill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return new JsonResult("Berhasil update");
        }

        [HttpDelete]
        public JsonResult Delete(int idUserSkill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Remove(db.UserSkills.Where(e => e.UserSkillId == idUserSkill).FirstOrDefault());
            db.SaveChanges();
            return new JsonResult("Berhasil delete");
        }

        [HttpGet]
        public JsonResult Detail(int idSkillLevel)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var data = db.SkillLevels.Where(e => e.SkillLevelId == idSkillLevel).FirstOrDefault();
            return new JsonResult(data);
        }
    }
}
