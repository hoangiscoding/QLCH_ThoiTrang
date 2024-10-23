using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Models
{
    public class Product
    {
        private static int AutoId { get; set; } = 1;
        public string Id { get; set; }
        public int IdInt { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string PriceStr { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Info { get; set; }
        public string AvatarPath { get; set; }
        public Product() { }
        public Product(string id, string name, int price, string type,
            int quantity, string size, string info, string avatarPath)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            Name = name;
            Price = price;
            PriceStr = GetPriceStr(Price);
            Type = type;
            Quantity = quantity;
            Size = size;
            Info = info;
            AvatarPath = avatarPath;
        }
        public Product(int currId, string name, int price, string type,
            int quantity, string size, string info, string avatarPath)
        {
            AutoId = currId;
            Id = "SP" + AutoId++;
            IdInt = GetIdInt(Id);
            IdInt = GetIdInt(Id);
            Name = name;
            Price = price;
            PriceStr = GetPriceStr(Price);
            Type = type;
            Quantity = quantity;
            Size = size;
            Info = info;
            AvatarPath = avatarPath;
        }
        public int GetIdInt(string idStr)
        {
            var idInt = int.Parse(idStr.Substring(2));
            return idInt;
        }
        public string GetPriceStr(int price)
        {
            var priceStr = price.ToString();
            decimal number = decimal.Parse(priceStr);
            CultureInfo cultureInfo = new CultureInfo("vi-VN"); // Chọn ngôn ngữ Việt Nam để hiển thị định dạng tiền tệ
            string priceFormatted = string.Format(cultureInfo, "{0:C}", number); // Sử dụng định dạng tiền tệ
            return priceFormatted;
        }

    }
}
