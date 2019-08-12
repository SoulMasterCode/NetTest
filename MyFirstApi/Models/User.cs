using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MyFirstApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15), Required]
        public String Username { get; set; }
        [DataType(DataType.Password), Required]
        public String Password { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public int Age { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }
    }
}