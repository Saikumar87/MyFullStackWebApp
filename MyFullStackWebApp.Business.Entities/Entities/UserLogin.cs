using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Text;

namespace MyFullStackWebApp.Business.Entities
{
    public class UserLogin
    {
        public int UserLoginID { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
      
        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }


    }
}
