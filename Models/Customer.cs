using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Person
    {
        private static int AutoId { get; set; } = 1;
        public int IdInt {  get; set; }
        public int Revenue { get; set; } //doanh thu
        public string Rank { get; set; }

        public Customer(int curId, string username, string password, string name,
            string gender, DateTime birthdate, string phoneNumber,
            string email, string address, string avatarPath, int revenue, string rank) : 
            base(username, password,name,gender,birthdate,phoneNumber,email,
                address,avatarPath) 
        {
            AutoId = curId;
            Id = "KH" +AutoId++;
            IdInt = GetIdInt(Id);
        }
        public Customer(string id, string username, string password, string name,
            string gender, DateTime birthdate, string phoneNumber,
            string email, string address, string avatarPath, int revenue,string rank) :
            base(username, password, name, gender, birthdate, phoneNumber, email,
                address, avatarPath)
        {
            Id = id;
            IdInt = GetIdInt(Id);
            Revenue = revenue; 
            Rank = rank;
        }

        /// <summary>
        /// Phương thức set Rank cho người dùng
        /// </summary>
        public void SetRank()
        {
            if (Revenue < 5_000_000)
                Rank = "ĐỒNG";
            else if (Revenue < 10_000_000)
                Rank = "BẠC";
            else if (Revenue < 20_000_000)
                Rank = "VÀNG";
            else if (Revenue < 50_000_000)
                Rank = "KIM CƯƠNG";
        }

        
    }
}
