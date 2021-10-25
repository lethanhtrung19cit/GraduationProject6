using GraduationProject.Models;
using GraduationProject.Models.DAO;
using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class DesignFurnitureController : Controller
    {
        // GET: DesignFurniture
       
        public ActionResult DesignFurniture()
        {
            ViewBag.designFurniture = new DesignFurnitureDao().DesignFurniture();
            ViewBag.Message = "";
            return View();
        }
        public ActionResult RequestDesign(ListRequest request)
        {
            request.DateRe = DateTime.Now;
            new DesignFurnitureDao().RequestDesign(request);
            ViewBag.Message = "Yêu cầu đã được gửi đi";

            ViewBag.designFurniture = new DesignFurnitureDao().DesignFurniture();
            return View("DesignFurniture");
        }
        public ActionResult DetailDesign(int id)
        {
            ViewBag.designFurniture = new DesignFurnitureDao().DesignFurniture();
            ViewBag.listRefe = new DesignFurnitureDao().ListReferences(id);
            ViewBag.SubImageDesign = new DesignFurnitureDao().DetailDesign(id);
            return View();
        }
    }
}