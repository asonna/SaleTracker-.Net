using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleTracker.Models
{
    [Table("Stocks")]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public string ItemName { get; set; }
        public float Cost{ get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
