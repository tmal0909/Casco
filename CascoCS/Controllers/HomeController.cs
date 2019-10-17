using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascoCS.Models;

namespace CascoCS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ReservationMD data = new ReservationMD();

            return View(data);
        }

        [HttpPost]
        public ActionResult CreateReservation(ReservationMD Data)
        {
            DBOperationResult result = RepositoryOrder.Insert(Data);

            return Json(result);
        }
    }
}