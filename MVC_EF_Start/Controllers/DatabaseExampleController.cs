using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    
        {
            Product Product1 = new Product();
            Product1.Name = "Soccer Ball";
            Product1.Price = 10;

            Product Product2 = new Product();
            Product2.Name = "Basketball";
            Product2.Price = 15;

            Product Product3 = new Product();
            Product3.Name = "Baseball";
            Product3.Price = 5;

            Order Order1 = new Order();
            Order1.Customer = "James";

            Detail Detail1 = new Detail();
            Detail1.OrderDetail = Order1;
            Detail1.ProductDetail = Product1;

            Detail Detail2 = new Detail();
            Detail2.OrderDetail = Order1;
            Detail2.ProductDetail = Product2;

            Detail Detail3 = new Detail();
            Detail3.OrderDetail = Order1;
            Detail3.ProductDetail = Product2;

            Order Order2 = new Order();
            Order2.Customer = "Dylan";

            Detail Detail4 = new Detail();
            Detail4.OrderDetail = Order2;
            Detail4.ProductDetail = Product3;

            Detail Detail5 = new Detail();
            Detail5.OrderDetail = Order2;
            Detail5.ProductDetail = Product3;


            Detail Detail6 = new Detail();
            Detail6.OrderDetail = Order2;
            Detail6.ProductDetail = Product1;

            Detail Detail7 = new Detail();
            Detail7.OrderDetail = Order2;
            Detail7.ProductDetail = Product1;





      //      dbContext.Products.Add(Product1);
      //dbContext.Products.Add(Product2);
      //      dbContext.Products.Add(Product3);
      //      dbContext.Orders.Add(Order1);
      //      dbContext.Orders.Add(Order2);
      //      dbContext.Details.Add(Detail1);
      //      dbContext.Details.Add(Detail2);
      //      dbContext.Details.Add(Detail3);
      //      dbContext.Details.Add(Detail4);
      //      dbContext.Details.Add(Detail5);
      //      dbContext.Details.Add(Detail6);
      //      dbContext.Details.Add(Detail7);
            




            dbContext.SaveChanges();
      
    
    
      dbContext.SaveChanges();
      await dbContext.SaveChangesAsync();
      


      return View();
    }

    public ViewResult LINQOperations()
    {
            //Order OrderCheck = dbContext.Orders
            //    .Include(c => c.DetailProducts)
            //    .Where(c => c.DetailProducts != null)

            //Detail max = dbContext.Products
            //    .Include(c => c.DetailOrders)
            //    .Include(p => p.Name)
            //    .Where(c => c.DetailOrders.Max().Count());


            var check = dbContext.Orders
               .Include(c => c.DetailProducts)
               .Where(c => c.DetailProducts.Count != 0);



            


            //Product output2 = dbContext.Details
            //    .Include(c => c.ProductDetail)
            //  .Where(c => c.OrderDetail.Customer == "Dylan")
            //  .Select(c => c.ProductDetail)
            //  .OrderByDescending(c => c.Price);
              

            //Product ou = dbContext.Products
            //     .Where(c => c.Name == "Soccer Ball")
            //     .FirstOrDefault();




            Order output = dbContext.Details
                .Include(c=>c.ProductDetail)
                .Where(c => c.ProductDetail.Name == "Soccer Ball")
                .Select(c => c.OrderDetail)
                .OrderByDescending(c => c.DetailProducts.Count)
                .FirstOrDefault();

            Product output2 = dbContext.Details
                .Where(c => c.OrderDetail.Customer == "Dylan")
                .Select(c => c.ProductDetail)
                .FirstOrDefault();






            return View();
    }

  }
}