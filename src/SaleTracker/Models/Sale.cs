using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleTracker.Models
{
    [Table("Sales")]
    public class Sale
    {
        public Sale(string name, float price, int qty, float total, int stockId, ApplicationUser user)
        {
            ItemName = name;
            SalePrice = price;
            SaleQty = qty;
            TotalSale = total;
            StockId = stockId;
            User = user;
        }

        [Key]
        public int SaleId { get; set; }
        public string ItemName { get; set; }
        public float SalePrice { get; set; }
        public int SaleQty { get; set; }
        public float TotalSale { get; set; }
        public int StockId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
