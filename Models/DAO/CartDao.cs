using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GraduationProject.Models.DAO
{
    public class CartDao
    {
        FurnitureEntities furnitureEntities = new FurnitureEntities();
        List<Cart> carts = new FurnitureEntities().Carts.ToList();
        List<DetailCart> detailCarts = new FurnitureEntities().DetailCarts.ToList();
        List<DetailOrder> detailOrders = new FurnitureEntities().DetailOrders.ToList();
        List<Good> goods = new FurnitureEntities().Goods.ToList();
        List<Customer> customers = new FurnitureEntities().Customers.ToList();
        public List<GoodsModel> DetailCart(string IdCu)
        {
            return (from c in carts
                              join d in detailCarts on c.IdCart equals d.IdCart
                              join g in goods on d.IdGoods equals g.IdGoods
                                
                              where c.IdCu == IdCu && d.Status=="0"
                              select new GoodsModel
                              {
                                   cartModel = c,
                                  detailCartModel = d,
                                  goodsModel=g
                              }).ToList();
                            
        }
        public void updateStatusCart()
        {
            var detailCarts = furnitureEntities.DetailCarts.ToList().Where(a=>a.ReadyBuy==1);

            foreach (var item in detailCarts)
            {
                item.Status = "1";
            }

            furnitureEntities.SaveChanges();
        }
        public void addReadyBuy(int IdDeCart, int readyBuy)
        {
            var detail = furnitureEntities.DetailCarts.Find(IdDeCart);
            detail.ReadyBuy = readyBuy;
            furnitureEntities.Entry(detail).State = EntityState.Modified;
            furnitureEntities.SaveChanges();
        }
        public void addAllReady()
        {
            var friendsToUpdate = furnitureEntities.DetailCarts.ToList();

            foreach (var item in friendsToUpdate)
            {
                item.ReadyBuy = 1;
            }

            furnitureEntities.SaveChanges();
        }
        public void resetReadyBuy()
        {
            var friendsToUpdate = furnitureEntities.DetailCarts.ToList();

            foreach (var item in friendsToUpdate)
            {
                item.ReadyBuy = 0;
            }
          
            furnitureEntities.SaveChanges();
        }
        public List<GoodsModel> listReadyBuy(string Cu)
        {            
            return (from c in carts
                    join cu in customers on c.IdCu equals cu.IdCu

                    join d in detailCarts on c.IdCart equals d.IdCart
                    join g in goods on d.IdGoods equals g.IdGoods
                    where c.IdCu==Cu && d.ReadyBuy==1 && d.Status=="0"
                    select new GoodsModel
                    {
                        cartModel = c,
                        detailCartModel = d,
                        goodsModel = g,
                        customerModel=cu
                    }).ToList();
        }
        public List<GoodsModel> listOrderAll(string IdCu)
        {
             return (from o in detailOrders 
                    join c in detailCarts on o.IdDeCart equals c.IdDeCart
                    join ca in carts on c.IdCart equals ca.IdCart
                     join cu in customers on ca.IdCu equals cu.IdCu

                     join g in goods on c.IdGoods equals g.IdGoods

                    where ca.IdCu == IdCu && c.Status != "0"
                    select new GoodsModel
                    {
                        cartModel = ca,
                        detailCartModel = c,
                        goodsModel = g,
                        orderModel=o,
                        customerModel=cu
                    }).ToList();
        }
        public List<string> comment(string IdCu)
        {
            return furnitureEntities.TableComments.Where(x => x.IdCu == IdCu).Select(x=>x.IdGoods).ToList();
        }
        public List<GoodsModel> listOrder(string IdCu, string status)
        {
             return (from o in detailOrders 
                    join c in detailCarts on o.IdDeCart equals c.IdDeCart
                    join ca in carts on c.IdCart equals ca.IdCart
                     join cu in customers on ca.IdCu equals cu.IdCu

                     join g in goods on c.IdGoods equals g.IdGoods

                    where ca.IdCu == IdCu && c.Status == status
                    select new GoodsModel
                    {
                        cartModel = ca,
                        detailCartModel = c,
                        goodsModel = g,
                        orderModel=o,
                        customerModel=cu
                    }).ToList();
        }
        public void addDetailOrder(DetailOrder detail)
        {
            furnitureEntities.DetailOrders.Add(detail);
            furnitureEntities.SaveChanges();
        }
        public void addDetailCart(DetailCart detailCart)
        {
            furnitureEntities.DetailCarts.Add(detailCart);
            furnitureEntities.SaveChanges();
        }
        public void addCart(Cart cart)
        {
            furnitureEntities.Carts.Add(cart);
            furnitureEntities.SaveChanges();
        }
        public void updateDetailCart(DetailCart detailCart)
        {
             var detail = furnitureEntities.DetailCarts.Find(detailCart.IdCart);
            detail.Amount = detailCart.Amount;
            detail.SumMoney = detailCart.SumMoney;
             furnitureEntities.Entry(detail).State= EntityState.Modified;
             furnitureEntities.SaveChanges();
        }
        public void deleteCart(DetailCart detailCart)
        {
            var detail = furnitureEntities.DetailCarts.Find(detailCart.IdCart);
            furnitureEntities.Entry(detail).State = EntityState.Deleted;
            furnitureEntities.SaveChanges();
        }
    }
}