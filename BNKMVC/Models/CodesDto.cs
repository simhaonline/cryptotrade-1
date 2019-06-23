using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BNKMVC.Models
{
    public enum CodeStatus
    {
        USED, UNUSED
    }
    public class CodesDto
    {

        [Required( ErrorMessage ="Account no required")]
        public string accountNo { get; set; }

        [Required(ErrorMessage = "CTO required")]
        public string cto { get; set; }
        public string tax { get; set; }
        public string imf { get; set; }


    }
}