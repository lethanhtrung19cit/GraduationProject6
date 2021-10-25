using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class GoodsModel
    {
        public TypeGood typeModel { get; set; }
        public ListTypeGood productModel { get; set; }
        public Good goodsModel { get; set; }
        public SubImage subGoodsModel { get; set; }
        public DesignFurniture designFurnitureModel { get; set; }
        public SubImgDesign subImgModel { get; set; }
        public Cart cartModel { get; set; }
        public DetailCart detailCartModel { get; set; }
        public Account accountModel { get; set; }
        public Customer customerModel { get; set; }
        public DetailOrder orderModel { get; set; }
        public TableComment tableCommentModel { get; set; }

    }
}