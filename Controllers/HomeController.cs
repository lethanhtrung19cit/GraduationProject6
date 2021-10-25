using GraduationProject.Models.DAO;
using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
         public ActionResult Index()
        {
             
            ViewBag.EsGoods = new GoodsDao().listSpecial();
            return View();
        }
        
        public ActionResult About()
        {
 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
             return View();
        }
        public ActionResult ContactDesign(ListRequest request, string canho, string bietthu, string nhao, string thietkenoithat, string thicongnoithat)
        {
            
            request.TypeProject = canho + " "+ bietthu+" " + nhao;
            request.Service = thietkenoithat + " " + thicongnoithat;
            request.DateRe = DateTime.Now;
             new DesignFurnitureDao().RequestDesign(request);
            ViewBag.Message = "Yêu cầu đã được gửi đi";
             return View("Contact", request);
        }
    }
}