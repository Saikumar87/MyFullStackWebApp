using System;
using System.ComponentModel.DataAnnotations;

namespace MyFullStackWebApp.Business.Entities
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
     

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
