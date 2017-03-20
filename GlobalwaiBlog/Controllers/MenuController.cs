using GlobalwaiBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalwaiBlog.Controllers
{
    public class MenuController : Controller
    {
        globalwaiBlogEntities db = new globalwaiBlogEntities();

        // GET: Menu
        public ActionResult Index(int id = 1)
        {
            ObjectParameter pageCount = new ObjectParameter("PageCount", typeof(Int32));
            
            ViewBag.PageIndex = id;
            var data = db.postLista_Obtener(id, 2.0, pageCount).ToList();
            ViewBag.PageCount = pageCount.Value;
            return View(data);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Post(int id = 0)
        {
            return View(db.postPorId_Obtener(id).ToList());
        }

        [HttpPost]
        public ActionResult EnviarMensaje()
        {
            return null;
        }
    }
}