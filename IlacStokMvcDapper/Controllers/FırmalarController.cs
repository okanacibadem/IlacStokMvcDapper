using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using IlacStokMvcDapper.Models;

namespace IlacStokMvcDapper.Controllers
{
    public class FırmalarController : Controller
    {
        // GET: Fırmalar
        public ActionResult Index()
        {
            return View(DP.ReturnList<FIRMALARTBLMODEL>("FIRMALARTBLLISTELE"));
        }


        [HttpGet]
        public ActionResult EYF(int id = 0)
        {
            if (id == 0)
            {
                return View();

            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@FIRMANO", id);
                return View(DP.ReturnList<FIRMALARTBLMODEL>("FIRMALARTBLSIRALA", param).FirstOrDefault<FIRMALARTBLMODEL>());
            }
        }
        [HttpPost]
        public ActionResult EYF(FIRMALARTBLMODEL mus)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@FIRMANO", mus.FIRMANO);
            param.Add("@FIRMAADI", mus.FIRMAADI);
            param.Add("@FIRMACIRO", mus.FIRMACIRO);
            param.Add("@FIRMAADRES", mus.FIRMAADRES);
            param.Add("@FIRMATELEFON", mus.FIRMATELEFON);
            param.Add("@FIRMAFAKS", mus.FIRMAFAKS);
            DP.ExecuteWithoutReturn("FIRMALARTBLEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@FIRMANO", id);
            DP.ExecuteWithoutReturn("FIRMALARTBLSIL", param);
            return RedirectToAction("Index");
        }

    }
}