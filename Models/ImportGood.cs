using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ImportGood
    {
        public string Id { get; set; }
        public int IdInt {  get; set; }
        public Staff Staff {  get; set; }
        public string StaffId { get; set; }
        public Product Product {  get; set; }
        public string ProductId { get; set; }
        public DateTime ImportTime { get; set; }
        public int Quantity { get; set; }
        public ImportGood() { }
        public ImportGood(string id, Staff staff,
            Product product, DateTime importTime, int quantity)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            Staff = staff;
            Product = product;
            ImportTime = importTime;
            Quantity = quantity;
        }
        public ImportGood(string id, string staffId,
            string productId, DateTime importTime, int quantity)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            StaffId = staffId;
            ProductId = productId;
            ImportTime = importTime;
            Quantity = quantity;
        }
        public ImportGood(int currId, string staffId,
            string productId, DateTime importTime, int quantity)
        {
            Id = "IM" + ++currId;
            IdInt = GetIdInt(Id);
            Staff.Id = staffId;
            Product.Id = productId;
            ImportTime = importTime;
            Quantity = quantity;
        }
        public int GetIdInt(string idStr)
        {
            var idInt = int.Parse(idStr.Substring(2));
            return idInt;
        }
    }
}
