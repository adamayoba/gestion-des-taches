using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.API.Models
{
    public class User
    {
        public int Id{get;set;}
        public string Username{get;set;} = string.Empty;
        public Byte[] PasswordHash{get;set;} 
        public Byte[] PasswordSalt{get;set;}  
        public string Role { get; set; } = "User"; // Default: User

    }
}
 