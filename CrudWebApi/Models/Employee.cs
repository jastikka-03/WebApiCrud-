﻿using System.ComponentModel.DataAnnotations;

namespace CrudWebApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string EmailID { get; set; }
    }
}
