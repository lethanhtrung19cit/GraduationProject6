using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GraduationProject.Models.DAO
{
    public class GoodsDao
    {
        FurnitureEntities furnitureEntities = new FurnitureEntities();
        List<Good> goods = new FurnitureEntities().Goods.ToList();
        List<Customer> customers = new FurnitureEntities().Customers.ToList();
        List<TypeGood> type = new FurnitureEntities().TypeGoods.ToList();
        List<ListTypeGood> product = new FurnitureEntities().ListTypeGoods.ToList();
        List<SubImage> subGoods = new FurnitureEntities().SubImages.ToList();
        List<DisCount> disCount = new FurnitureEntities().DisCounts.ToList();
        List<ImportGood> importGoods = new FurnitureEntities().ImportGoods.ToList();
        List<DetailImportGood> detailImportGoods = new FurnitureEntities().DetailImportGoods.ToList();
        List<TableComment> tableComments = new FurnitureEntities().TableComments.ToList();
        List<Cart> carts = new FurnitureEntities().Carts.ToList();
        List<DetailCart> detailCarts = new FurnitureEntities().DetailCarts.ToList();
        public List<GoodsModel> listSpecial()
        {
            var maxDate = furnitureEntities.ImportGoods.Max(a => a.DateCreate);
            var listSpe = (from i in importGoods
                           join d in detailImportGoods on i.IdIm equals d.IdIm
                           join g in goods on d.IdGoods equals g.IdGoods
                           where i.DateCreate <= maxDate
                           select new GoodsModel
                           {
                               goodsModel = g
                           }
                         ).Take(4).ToList();
            return listSpe;
        }
        public List<GoodsModel> listGoodsRoom(string id)
        {
             
             var listProductRoom = (from p in product
                                    join t in type on p.IdRoom equals t.IdType
                                    join g in goods on p.IdTypeG equals g.IdTypeG
                                     where t.IdType == id
                                    select new GoodsModel
                                    {
                                        goodsModel = g,
                                        productModel = p,
                                        typeModel = t
                                    }
                                   ).ToList();
            
            return listProductRoom;
        }
        public List<GoodsModel> searchMenuGoods(string nameRoom, int nameSearch)
        {
             var listProductRoom = (from p in product
                                   join t in type on p.IdRoom equals t.IdType
                                   join g in goods on p.IdTypeG equals g.IdTypeG
                                   where t.IdType == nameRoom && g.IdTypeG == nameSearch
                                   select new GoodsModel
                                   {
                                       goodsModel = g,

                                       productModel = p
                                   }
                                    ).Distinct().ToList();
            return listProductRoom;
        }
        public List<GoodsModel> searchPriceGoods(string room, string fromPrice, string toPrice)
        {
         
            return  (from p in product
                                    join t in type on p.IdRoom equals t.IdType
                                    join g in goods on p.IdTypeG equals g.IdTypeG
                                    where t.IdType == room && g.Price >= float.Parse(fromPrice) && g.Price <= float.Parse(toPrice)
                                    select new GoodsModel
                                    {
                                        goodsModel = g,

                                        productModel = p
                                    }
                                    ).Distinct().ToList();
            
        }
        public List<Good> searchProduct(string nameProduct)
        {

            return furnitureEntities.Goods.Where(x=>x.NameGoods.Contains(nameProduct)).ToList();

        }
        public List<GoodsModel> subImageGoods(string id)
        {
            return (from g in goods
             join s in subGoods on g.IdGoods equals s.IdGoods
             where g.IdGoods == id
             select new GoodsModel
             {
                 goodsModel = g,
                 subGoodsModel = s
             }).ToList();
        }
        public List<Good> detailGoods(string id)
        {
           return new FurnitureEntities().Goods.Where(x => x.IdGoods == id).ToList();
        }
        public List<GoodsModel> DisCount(string Room)
        {
            return (from p in product
             join t in type on p.IdRoom equals t.IdType
             join g in goods on p.IdTypeG equals g.IdTypeG
             where t.IdType == Room
             select new GoodsModel
             {
                 goodsModel = g,

             }
             ).ToList();
        }
        public void updateAmountGooods(string IdGoods, int amount)
        {
            var goods = furnitureEntities.Goods.Find(IdGoods);
            goods.Amount = goods.Amount - amount;
             furnitureEntities.Entry(goods).State = EntityState.Modified;
            furnitureEntities.SaveChanges();
        }
        public List<TableComment> listQuality()
        {
            return furnitureEntities.TableComments.ToList();
             
        }
        public List<TableComment> qualityCus(string IdCu, string IdGoods)
        {
            return furnitureEntities.TableComments.Where(x=>x.IdCu==IdCu && x.IdGoods==IdGoods).ToList();
             
        }
        public List<GoodsModel> listComment(string IdCu)
        {
            return (from t in tableComments join g in goods
                    on t.IdGoods equals g.IdGoods
                    where t.IdCu == IdCu
                    select new GoodsModel
                    {
                        goodsModel = g,
                        tableCommentModel = t
                    }
                    ).ToList();
                    
        }
        public void addComment(TableComment tableComment)
        {
            furnitureEntities.TableComments.Add(tableComment);
            furnitureEntities.SaveChanges();
        }
        public List<GoodsModel> listCommentProduct(string IdGoods)
        {
            return (from c in customers
                    join t in tableComments on c.IdCu equals t.IdCu
                    where t.IdGoods==IdGoods
                    select new GoodsModel
                    {
                        customerModel = c,
                        tableCommentModel = t
                    }).ToList();
                    
        }
    }
}