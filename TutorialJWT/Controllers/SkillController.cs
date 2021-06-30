using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialJWT.Model;

namespace TutorialJWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        [HttpGet]
        public JsonResult GetSkills()
        {
                db_latihan_gunawanContext db = new db_latihan_gunawanContext();
                var data = db.Skills.ToList();
                return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Create(Skill skill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();

            db.Skills.Add(skill);
            db.SaveChanges();
            return new JsonResult("Add sukses");
        }

        [HttpPatch]
        public JsonResult Update(Skill skill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return new JsonResult("Berhasil update");
        }

        [HttpDelete]
        public JsonResult Delete(int idSkill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Remove(db.Skills.Where(e => e.SkillId == idSkill).FirstOrDefault());
            db.SaveChanges();
            return new JsonResult("Berhasil delete");
        }

        [HttpGet]
        public JsonResult Detail(int idSkill)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var data = db.Skills.Where(e => e.SkillId == idSkill).FirstOrDefault();
            return new JsonResult(data);
        }
    }
}
