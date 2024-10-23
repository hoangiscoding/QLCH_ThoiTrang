using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill
    {
        public string Id { get; set; }
        public int IdInt { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string StaffId { get; set; }
        public Staff Staff { get; set; }
        public DateTime CreationTime { get; set; }
        public float DiscountAmount { get; set; }     //Giá giảm
        public float OriginalAmnount { get; set; }    //Giá gốc
        public float DiscountedPrice { get; set; }   //tổng tiền
        public Bill() { }
        public Bill(string id, Customer customer,
            Staff staff, DateTime creationTime,
            float discountAmount, float originalAmount, float discountedPrice)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            Customer = customer;
            Staff = staff;
            CreationTime = creationTime;
            DiscountedPrice = discountedPrice;
            OriginalAmnount = originalAmount;
            DiscountAmount = discountAmount;
        }
        public Bill(string id, string customerId, string staffId,
            DateTime creationTime, float discountAmount,
            float originalAmnount, float discountedPrice)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            CustomerId = customerId;
            StaffId = staffId;
            CreationTime = creationTime;
            DiscountAmount = discountAmount;
            OriginalAmnount = originalAmnount;
            DiscountedPrice = discountedPrice;
        }
        public int GetIdInt(string idStr)
        {
            var idInt = int.Parse(idStr.Substring(2));
            return idInt;
        }
    }
}
