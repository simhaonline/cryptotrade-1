using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BNKMVC.Models
{
    public class FeedBackDto
    {
        public int id { get; set; }
        [Required (ErrorMessage ="Full Name is Required")]
        public string Clientname { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Message Required")]

        public string Message { get; set; }
        
    }
}