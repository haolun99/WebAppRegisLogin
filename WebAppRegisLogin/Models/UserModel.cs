using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppRegisLogin.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "UserID is required")]
        [Display(Name = "UserID:")]
        public int UserID { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is required")]
        [Display(Name = "UserName: ")]
        public String UserName { get; set; }

        [Display(Name = "UserEmail: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserEmail is required")]
        public String UserEmail { get; set; }

        [Display(Name = "UserImage: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserImage is required")]
        public String UserImage { get; set; }

        [Display(Name = "UserPassword: ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserPassword is required")]
        [DataType(DataType.Password)]
        public String UserPassword { get; set; }

        public String SuccessMessage { get; set; }

    }

}