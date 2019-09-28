using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeFitness.Models.Entities
{
    public class Account
    {
        [Required(ErrorMessage = "* Vui lòng nhập username.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "* Vui lòng nhập passwrod")]
        public string Password { get; set; }
    }
}