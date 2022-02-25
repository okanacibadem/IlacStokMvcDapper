using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using IlacStokMvcDapper.Models;

namespace IlacStokMvcDapper.Controllers
{
    public class IlaclarController : Controller
    {
        // GET: Ilaclar
        // GET: Fırmalar
        public ActionResult Index()
        {
            return View(DP.ReturnList<ILACLARTBLMODEL>("ILACLARTBLLISTELE"));
        }
        [HttpGet]
        public ActionResult EYI(int id = 0)
        {
            if (id == 0)
            {
                return View();

            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ILACNO", id);
                return View(DP.ReturnList<ILACLARTBLMODEL>("ILACLARTBLSIRALA", param).FirstOrDefault<ILACLARTBLMODEL>());
            }
        }
        [HttpPost]
        public ActionResult EYI(ILACLARTBLMODEL mus)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@ILACNO", mus.ILACNO);
            param.Add("@ILACADI", mus.ILACADI);
            param.Add("@ILACFIYAT", mus.ILACFIYAT);
            param.Add("@ILACADET", mus.ILACADET);

            DP.ExecuteWithoutReturn("ILACLARTBLEY", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ILACNO", id);
            DP.ExecuteWithoutReturn("ILACLARTBLSIL", param);
            return RedirectToAction("Index");
        }

    }
}