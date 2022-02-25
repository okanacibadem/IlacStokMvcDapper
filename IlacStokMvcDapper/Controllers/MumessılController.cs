using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using IlacStokMvcDapper.Models;

namespace IlacStokMvcDapper.Controllers
{
    public class MumessılController : Controller
    {
        // GET: Mumessıl
        public ActionResult Index()
        {
            return View(DP.ReturnList<MUMESSILTBL>("MUMESSILTBLLISTELE"));
        }

        [HttpGet]
        public ActionResult EYM(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MUMESSILNO", id);
                return View(DP.ReturnList<MUMESSILTBL>("MUMESSILTBLSIRALA", param).FirstOrDefault<MUMESSILTBL>());
            }
        }
        [HttpPost]
        public ActionResult EYM(MUMESSILTBL mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MUMESSILNO", mus.MUMESSILNO);
            param.Add("@ADSOYAD", mus.ADSOYAD);
            param.Add("@HEDEFSATIS", mus.HEDEFSATIS);
            param.Add("@BOLGE", mus.BOLGE);
            param.Add("@MUDUR", mus.MUDUR);
            DP.ExecuteWithoutReturn("MUMESSILTBLEY", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@MUMESSILNO", id);
            DP.ExecuteWithoutReturn("MUMESSILTBLSIL", param);
            return RedirectToAction("Index");
        }

    }
}