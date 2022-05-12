using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class Order
    {
        public Order()
        {
            this.CreationDate = DateTime.Now;
        }
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public double TotalPrice { get; set; }
        public bool IsCash { get; set; }
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
