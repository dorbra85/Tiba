using System;
using System.ComponentModel.DataAnnotations;

namespace TibaApi.Model
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string Token { get; set; }
    }
}
