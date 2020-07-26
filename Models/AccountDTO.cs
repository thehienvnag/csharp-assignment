using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models
{
    public class AccountDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int StatusId { get; set; }
        public string Email { get; set; }

        public AccountDTO(int iD, string username, string fullname, int statusId, string email)
        {
            ID = iD;
            Username = username;
            Fullname = fullname;
            StatusId = statusId;
            Email = email;
        }
    }
}