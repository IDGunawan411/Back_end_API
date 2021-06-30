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
    public class SkillLevelController : ControllerBase
    {

        [HttpGet]
        public JsonResult GetSkillLevel()
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            var data = db.SkillLevels.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Create(SkillLevel skillLevel)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();

            db.SkillLevels.Add(skillLevel);
            db.SaveChanges();
            return new JsonResult("Add sukses");
        }

        [HttpPatch]
        public JsonResult Update(SkillLevel skillLevel)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Entry(skillLevel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return new JsonResult("Berhasil update");
        }

        [HttpDelete]
        public JsonResult Delete(int idSkillLevel)
        {
            db_latihan_gunawanContext db = new db_latihan_gunawanContext();
            db.Remove(db.SkillLevels.Where(e => e.SkillLevelId == idSkillLevel).FirstOrDefault());
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

