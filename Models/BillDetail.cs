using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BillDetail
    {
        public string Id { get; set; }
        public int IdInt {  get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        public BillDetail() { }
        public BillDetail(string id, Product product, int quantity, float total)
        {
            Id = id;
            IdInt = GetIdInt(id);
            Product = product;
            Quantity = quantity;
            Total = total;
        }
        public BillDetail(string id, string productId, int quantity, float total)
        {
            Id = id;
            IdInt = GetIdInt(id);
            ProductId = productId;
            Quantity = quantity;
            Total = total;
        }
        public int GetIdInt(string idStr)
        {
            var idInt = int.Parse(idStr.Substring(2));
            return idInt;
        }
    }
}
