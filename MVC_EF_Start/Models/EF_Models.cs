using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
 public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public List<Detail> DetailOrders { get; set; }
    }

   public class Order
    {
        public int OrderID { get; set; }
        public string Customer { get; set; }
        public List<Detail> DetailProducts { get; set; }
        
    }

  public  class Detail
    {
        public int ID { get; set; }

        public Product ProductDetail { get; set; }
        public Order OrderDetail { get; set; }
        public DateTime Time { get; set; }
    }

}