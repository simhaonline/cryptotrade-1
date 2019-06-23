
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Models;
using BNKMVC.Entities;
namespace BNKMVC.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperController : Controller
    {
        // GET: Super
        public ActionResult Index()
        {
            var db = new mbankEntities();
            var list = db.AspNetUsers.ToList();
            return View(list);
      
        }
        
        //ApplicationDbContext context = new ApplicationDbContext();
        //UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        [HttpGet]
        public ActionResult DeleteUser(string id)
        {
            var db = new mbankEntities(); ;
            //find Users

            var findUser = db.AspNetUsers.Find(id);
            if (findUser != null)
            {
                //Delete User

                db.AspNetUsers.Remove(findUser);
                db.SaveChanges();
                return Json(new { value = 200, message = "User Deleted" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { value = 0, message = "Something Went wrong" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult MakeAdmin(string id)
        {
            Reusable.RoleCreator roleHandle = new Reusable.RoleCreator();

            if (roleHandle.MakeUserAdmin(id))
            {
                return Json(new { value = 200, message = "User have been added to admin role" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { value = 0, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveUserFromAdmin(string id)
        {
            Reusable.RoleCreator roleHandle = new Reusable.RoleCreator();

            if (roleHandle.RemoveUserFromAdmin(id))
            {
                return Json(new { value = 200, message = "User have been removed from admin role" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { value = 0, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }
    }
}