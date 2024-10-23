using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string Id {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string AvatarPath { get; set; }


        public Person(string username, string password, string name,
            string gender, DateTime birthdate, string phoneNumber,
            string email, string address, string avatarPath)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.AvatarPath = avatarPath;
        }
        public int GetIdInt(string idStr)
        {
            var idInt = int.Parse(idStr.Substring(2));
            return idInt;
        }

    }
}
