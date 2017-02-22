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
        [Key]
        public int SaleId { get; set; }
        public string ItemName { get; set; }
        public float SalePrice { get; set; }
        public int SaleQty { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
