using GraduationProject.Models.DAO;
using GraduationProject.Models.EF;
using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraduationProject.Controllers
{
    public class CartController : Controller
    {
        FurnitureEntities furniture = new FurnitureEntities();
         // GET: Cart
        public ActionResult DetailCart()
        {
            new CartDao().resetReadyBuy();

            ViewBag.detailCart= new CartDao().DetailCart(Session["IdCu"].ToString());
            return View();
        }
        public ActionResult buyProduct(string IdGoods, int Amount, int IdDeCart, string Address)
        {
            DetailOrder detailOrder = new DetailOrder();
            detailOrder.IdDeCart = IdDeCart;
            detailOrder.Address = Address;
            new CartDao().addDetailOrder(detailOrder);
            new CartDao().updateStatusCart();
            //new GoodsDao().updateAmountGooods(IdGoods, Amount);
            ViewBag.detailCart= new CartDao().DetailCart(Session["IdCu"].ToString());

            return View("DetailCart");
        }
        public void addAllReady()
        {
            new CartDao().addAllReady();
        }
        public void addReady(int IdDeCart)
        {
            new CartDao().addReadyBuy(IdDeCart, 1);
            
         }
        public void subReady(int IdDeCart)
        {
            new CartDao().addReadyBuy(IdDeCart, 0);

         }
        public ActionResult listReady()
        {
            var Cu = Session["IdCu"].ToString();
            ViewBag.listReadyBuy = new CartDao().listReadyBuy(Cu); 
            return View();
        }
        
        public ActionResult listOrder()
        {
            string IdCu = Session["IdCu"].ToString();
            ViewBag.myComment = new CartDao().comment(IdCu);
            ViewBag.listOrderAll = new CartDao().listOrderAll(IdCu);
            ViewBag.listOrderPending = new CartDao().listOrder(IdCu, "1");
            ViewBag.listOrderDelivering = new CartDao().listOrder(IdCu, "2");
            ViewBag.listOrderDelivered = new CartDao().listOrder(IdCu, "3");
            ViewBag.listOrderCancelled = new CartDao().listOrder(IdCu, "4");
            return View();
        }
        public void updateCart(string IdGoods, string Amount, string SumMoney)
        {
            DetailCart detailCart = new DetailCart();
            detailCart.IdCart = furniture.DetailCarts.Where(a => a.IdGoods == IdGoods).Select(x => x.IdDeCart).FirstOrDefault();
            detailCart.Amount = int.Parse(Amount);
            detailCart.SumMoney = float.Parse(SumMoney);
            new CartDao().updateDetailCart(detailCart);
        }
        public void addCart(string IdGoods, string Amount)
        {
            var IdCu = Session["IdCu"].ToString();
            float price= furniture.Goods.Where(a => a.IdGoods == IdGoods).Select(x=>x.Price).FirstOrDefault();
            var IdCart=furniture.Carts.Where(x=>x.IdCu== IdCu).Select(x=>x.IdCart).FirstOrDefault();
            if (IdCart == 0)
            {
                Cart cart = new Cart();
                cart.IdCu = Session["IdCu"].ToString();
                new CartDao().addCart(cart);
            }
            DetailCart detailCart = new DetailCart();
            int idCart= furniture.Carts.Where(a => a.IdCu == IdCu).Select(x=>x.IdCart).FirstOrDefault();
            string idGoods = furniture.DetailCarts.Where(a => a.IdGoods == IdGoods && a.IdCart==IdCart).Select(x => x.IdGoods).FirstOrDefault();
            if (idGoods!=IdGoods)
            {
                detailCart.IdCart = idCart;
                detailCart.IdGoods = IdGoods;
                detailCart.Amount = int.Parse(Amount);
                detailCart.SumMoney = detailCart.Amount * price;
                detailCart.Status = "0";
                new CartDao().addDetailCart(detailCart);
            }
            else
            {
                detailCart.IdCart = furniture.DetailCarts.Where(a => a.IdGoods == IdGoods).Select(x => x.IdDeCart).FirstOrDefault();
                detailCart.Amount = int.Parse(Amount)+ furniture.DetailCarts.Where(a => a.IdGoods == IdGoods).Select(x => x.Amount).FirstOrDefault();
                detailCart.SumMoney = detailCart.Amount * price;
                new CartDao().updateDetailCart(detailCart);
            }
             
        }
        public void deleteCart(string IdDeCart)
        {
            DetailCart detail = new DetailCart();
            detail.IdCart = int.Parse(IdDeCart);
 
            new CartDao().deleteCart(detail);
        }
    }
}