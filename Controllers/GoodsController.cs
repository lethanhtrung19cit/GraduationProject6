using GraduationProject.Models.DAO;
using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class GoodsController : Controller
    {
       
         public ActionResult Room(string id)
        {
            ViewBag.listQuality = new GoodsDao().listQuality();
             ViewBag.listGLR = new GoodsDao().listGoodsRoom(id);
            ViewBag.listProduct = new GoodsDao().listGoodsRoom(id);
            Session["Id"] = id;
            return  View();
        }
        public ActionResult Search(int nameSearch, string nameRoom)
        {
            ViewBag.listQuality = new GoodsDao().listQuality();
            ViewBag.listProduct = new GoodsDao().listGoodsRoom(nameRoom);
            ViewBag.listGLR = new GoodsDao().searchMenuGoods(nameRoom, nameSearch);
            return View("Room");
        }
         public ActionResult SearchPrice(string room,string fromPrice , string toPrice)
        {
            
            ViewBag.listProduct =  new GoodsDao().listGoodsRoom(room);
            ViewBag.listQuality = new GoodsDao().listQuality();

            ViewBag.listGLR = new GoodsDao().searchPriceGoods(room, fromPrice, toPrice);
            return View("Room");
        }
        public ActionResult DetailGoods(string id)
        {
            ViewBag.listCommentProduct = new GoodsDao().listCommentProduct(id);
            ViewBag.qualityCus = new GoodsDao().qualityCus(Session["IdCu"].ToString(), id);
            ViewBag.DetailGoods = new GoodsDao().detailGoods(id);
            ViewBag.SubImageGoods = new GoodsDao().subImageGoods(id);
            return View();
        }
        public ActionResult DisCount()
        {

            ViewBag.listDisCountLR = new GoodsDao().DisCount("LR").ToList();
            ViewBag.listDisCountWR = new GoodsDao().DisCount("WR").ToList();
            ViewBag.listDisCountDR = new GoodsDao().DisCount("DR").ToList();
            ViewBag.listDisCountBR = new GoodsDao().DisCount("BR").ToList();
            return View("DisCount");
        }
       
        public ActionResult ViewSearch(string nameProduct)
        {
            ViewBag.nameProduct = nameProduct;
            ViewBag.searchProduct = new GoodsDao().searchProduct(nameProduct);
            return View();
        }
        public ActionResult myComment()
        {
            ViewBag.listQuality = new GoodsDao().listQuality();

            ViewBag.myComment = new GoodsDao().listComment(Session["IdCu"].ToString());
            return View();
        }
        public ActionResult addCommentView(string IdGoods, string IdCu)
        {
            ViewBag.IdGoods = IdGoods;
            ViewBag.IdCu = IdCu;
            return View();
        }
        public ActionResult addComment(TableComment tableComment)
        {
            new GoodsDao().addComment(tableComment);
            return View("myComment");
        }

    }
}