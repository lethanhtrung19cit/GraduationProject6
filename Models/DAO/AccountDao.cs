using GraduationProject.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GraduationProject.Models.DAO
{
    public class AccountDao
    {
        FurnitureEntities furnitureEntities = new FurnitureEntities();
        List<Account> accounts = new FurnitureEntities().Accounts.ToList();
        List<Customer> customers = new FurnitureEntities().Customers.ToList();
        public void editInfo(Customer customer)
        {
            var cus = furnitureEntities.Customers.Find(customer.IdCu);
            cus.NameCu = customer.NameCu;
            cus.DateOfBirth = customer.DateOfBirth;
            cus.Phone = customer.Phone;
            cus.Address = customer.Address;
            
            furnitureEntities.Entry(cus).State = EntityState.Modified;
            furnitureEntities.SaveChanges();
        }
        public string PassWord(string Email)
        {
            return furnitureEntities.Accounts.Where(x=>x.Email==Email).Select(x=>x.PassWord).FirstOrDefault(); 
        }
         
        public List<GoodsModel> listInformation(string IdCu)
        {
            return (from a in accounts join c in customers 
                    on a.Email equals c.Email
                    where c.IdCu==IdCu
                    select new GoodsModel
                    {
                        accountModel=a,
                        customerModel=c
                    }).ToList();
        }
    }
}