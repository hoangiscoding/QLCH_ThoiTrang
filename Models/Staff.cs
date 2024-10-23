using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Staff : Person
    {
        private static int AutoId { get; set; } = 1;
        public string Role { get; set; }
        public int IdInt { get; set; }

        public Staff(int currId,string username, string password, string name,
            string gender, DateTime birthdate, string phoneNumber,
            string email, string address, string avatarPath, string role):
            base(username, password, name, gender, 
                birthdate, phoneNumber, email,
                address, avatarPath)
        {
            AutoId = currId;
            Id = "NV" + AutoId++;
            Role = role;
            IdInt = GetIdInt(Id);
        }
        public Staff(string id, string username, string password, string name,
            string gender, DateTime birthdate, string phoneNumber,
            string email, string address, string avatarPath, string role) :
            base(username, password, name, gender,
                birthdate, phoneNumber, email,
                address, avatarPath)
        {
            Id = id;
            Role = role;
            IdInt = GetIdInt(Id);
        }

    }
}
