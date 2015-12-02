using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace WebShop.Models
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            // Добавление items
            Item item1 = new Item { Name = "Item one", Description = "empy", Category = "1", ForSale = true, Price = 100500 };
            Item item2 = new Item { Name = "Second item", Category = "3", ForSale = false, Price = 1 };
            db.Items.Add(item1);
            db.Items.Add(item2);
            // Role of admin
            db.Roles.Add(new IdentityRole { Name = "admin" });
            db.Users.Add(new ApplicationUser { UserName = "dmitry.zvonorev@phystech.edu", Email = "dmitry.zvonorev@phystech.edu", PasswordHash = "ANovDGhQpsUEdeuiT1rV / 2zhxplX9dG1Ceu4FZsNVY80WizK / SmtHS7R9LgU + 52U + A ==" });
            db.SaveChanges();
        }
    }
}