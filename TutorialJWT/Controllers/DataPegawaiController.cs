using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorialJWT.Model;
using TutorialJWT.Models;

namespace TutorialJWT.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataPegawaiController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string Show()
        {
            return "hello world";
        }

        [HttpGet]
        public JsonResult ShowJson()
        {

            db_gunawanContext db = new db_gunawanContext();
            var data = db.TblPegawai.Where(e => e.Alamat.Contains("Depo")).ToList();
            return new JsonResult(data);
        }

        [HttpGet]
        public JsonResult Pegawai_List()
        {
            List<Pegawai> pegawais = new List<Pegawai>();

            for (int i = 0; i < 5; i++)
            {
                pegawais.Add(new Pegawai() { Nama = "Alif", Alamat = "Depok" });
            }

            return new JsonResult(pegawais);
        }


        [HttpGet]
        public JsonResult Add_json(string nama, string alamat)
        {
            List<Pegawai> pegawais = new List<Pegawai>();

            Pegawai pegawai1 = new Pegawai();
            pegawai1.Nama = "aa";
            pegawai1.Alamat = "xxxzz";

            return new JsonResult(pegawais);
        }

        [HttpPost]
        public JsonResult add_json2(Pegawai pegawai)
        {

            return new JsonResult("Add sukses");
        }

        [HttpGet]
        public JsonResult DataList()
        {
            db_gunawanContext db = new db_gunawanContext();
            var data = db.TblPegawai.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult DataAdd(TblPegawai tblpegawai)
        {
            db_gunawanContext db = new db_gunawanContext();

            db.TblPegawai.Add(tblpegawai);
            db.SaveChanges();
            return new JsonResult("Add sukses");
        }

        [HttpPatch]
        public JsonResult DataUpdate(TblPegawai tblpegawai)
        {
            db_gunawanContext db = new db_gunawanContext() ;
            db.Entry(tblpegawai).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return new JsonResult("Berhasil update");
        }

        [HttpDelete]
        public JsonResult DataDelete(int idPegawai)
        {
            db_gunawanContext db = new db_gunawanContext();
            db.Remove(db.TblPegawai.Where(e => e.Idpegawai == idPegawai).FirstOrDefault());
            return new JsonResult("Berhasil delete");
        }

        [HttpGet]
        public JsonResult DataDetail(int idPegawai)
        {
            db_gunawanContext db = new db_gunawanContext();
            var data = db.TblPegawai.Where(e => e.Idpegawai == idPegawai).FirstOrDefault();
            return new JsonResult(data);
        }


    }
}
