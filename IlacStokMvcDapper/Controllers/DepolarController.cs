using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using IlacStokMvcDapper.Models;

namespace IlacStokMvcDapper.Controllers
{
    public class DepolarController : Controller
    {
        // GET: Depolar
        public ActionResult Index()
        {
            return View(DP.ReturnList<DEPOLARTBLMODEL>("DEPOLARTBLLISTELE"));
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DEPONO", id);
                return View(DP.ReturnList<DEPOLARTBLMODEL>("DEPOLARTBLSIRALA", param).FirstOrDefault<DEPOLARTBLMODEL>());
            }
        }

        [HttpPost]
        public ActionResult EY(DEPOLARTBLMODEL mus)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DEPONO", mus.DEPONO);
            param.Add("@DEPOADI", mus.DEPOADI);
            param.Add("@DEPOBOLGE", mus.DEPOBOLGE);
            param.Add("@DEPOSORUMLUSU", mus.DEPOSORUMLUSU);     
            DP.ExecuteWithoutReturn("DEPOLARTBLEY", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DEPONO", id);
            DP.ExecuteWithoutReturn("DEPOLARTBLSIL", param);
            return RedirectToAction("Index");
        }



    }
}