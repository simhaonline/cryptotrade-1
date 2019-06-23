using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BNKMVC.Models
{
    public class UserDto
    {


        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Password does not match")]
        public string PasswordConfirmed { get; set; }


        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string CountryId { get; set; }

        public string PictureUrl { get; set; }

        public decimal ActiveAmount { get; set; }
    }

    public class UserPhoto
    {
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public string ImageData { get; set; }
    }

    public class UserBalance
    {
        public string Id { get; set; }

        public string AccountNo { get; set; }
        public decimal Balance { get; set; }
    }
}