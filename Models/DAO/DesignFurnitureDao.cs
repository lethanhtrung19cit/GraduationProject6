using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationProject.Models.DAO
{
    
    public class DesignFurnitureDao
    {
        FurnitureEntities furnitureEntities = new FurnitureEntities();
        List<DesignFurniture> designFurnitures = new FurnitureEntities().DesignFurnitures.ToList();
        List<SubImgDesign> subImgDesigns = new FurnitureEntities().SubImgDesigns.ToList();

         
        public List<DesignFurniture> DesignFurniture()
        {
            return furnitureEntities.DesignFurnitures.ToList();
        }
        public List<GoodsModel> DetailDesign(int id)
        {
            return (from d in designFurnitures
                    join s in subImgDesigns on d.IdDe equals s.IdDe
                    where d.IdDe == id
                    select new GoodsModel
                    {
                        designFurnitureModel = d,
                        subImgModel = s
                    }).ToList();
        }
        public List<DesignFurniture> ListReferences(int id)
        {
            return furnitureEntities.DesignFurnitures.Where(a => a.IdDe != id).ToList();
        }
        public void RequestDesign(ListRequest re)
        {

            furnitureEntities.ListRequests.Add(re);
            furnitureEntities.SaveChanges();
        }
    }
}