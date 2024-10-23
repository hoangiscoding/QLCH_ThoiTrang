using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;
namespace Controllers
{
    public interface ICheckInput
    {
        bool IsNameValid(string name);
        bool IsUsernameValid(string username);
        bool IsUsernameExist(string username, List<String> usernames);
        bool IsPasswordValid(string password);
        bool IsEmailValid(string email);
        bool IsPhoneValid(string phone);
        bool IsPhoneExist(string phone, List<String> phones);
        bool IsEmailExist(string email, List<String> emails);
    }
    public class CheckInputController : ICheckInput
    {
        public bool IsEmailExist(string email, List<string> emails)
        {
            for (int i = 0; i < emails.Count; i++)
                if (emails[i] == email)
                    return true;
            return false;
        }

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_]+[A-Za-z0-9.-]+\@[a-z0-9]+\.[a-z]{2,4}$");
        }

        public bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, @"^[\p{L} ]{2,40}$");
        }

        public bool IsPasswordValid(string password)
        {
            return Regex.IsMatch(password, @"^(.{0,7}|[^0-9]*|[^A-Z])$");
        }

        public bool IsPhoneExist(string phone, List<string> phones)
        {
            for (int i = 0; i < phones.Count; i++)
                if (phones[i] == phone)
                    return true;
            return false;
        }

        public bool IsPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, @"^0(3|5|8|7|9)\d{8}$");
        }

        public bool IsUsernameExist(string username, List<String> usernames)
        {
            for (int i = 0; i < usernames.Count; i++)
                if (usernames[i] == username)
                    return true;
            return false;
        }

        public bool IsUsernameValid(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z][a-zA-Z0-9]*([._-][a-zA-Z0-9]+)*$");
        }
    }
}
