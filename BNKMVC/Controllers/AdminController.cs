using BNKMVC.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BNKMVC.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private mbankEntities _context;
        private string accountNumber;
        private string userId;

        public ActionResult Index1()
        {
            inject();
            var userList = _context.AspNetUsers.ToList().OrderByDescending(d => d.DateStamp);
            var transactions = ViewBag.transactions = _context.ForwardTransfers.Count();
            var pendingTransaction = ViewBag.pendingTransaction = _context.ForwardTransfers.Where(a => a.Status == Services.TransactionStatus.PENDING.ToString()).Count();
            ViewBag.users = _context.AspNetUsers.Count();

            return View("Index1",userList);
        }

        public void inject()
        {
            userId = User.Identity.GetUserId();
            accountNumber = new Services.Account().getAccountNumber(userId);
            _context = new mbankEntities();
        }
        public ActionResult Transactions()
        {
            inject();

            var transactions = _context.ForwardTransfers.OrderByDescending(d => d.Date).ToList();
            return View(transactions);
        }

        // GET: Admin/Create
        public ActionResult Users()
        {
            inject();
            return View(_context.AspNetUsers.ToList());
        }
        public ActionResult CreateAuthorizationCodes(string userid)
        {
            var accountNumb = new Services.Account().getAccountNumber(userid);

            var code = new CodesDto
            {
                accountNo = accountNumb
            };
            return View(code);
        }

        [HttpPost]
        public ActionResult CreateAuthorizationCodes(CodesDto m)
        {
            inject();
            if (ModelState.IsValid)
            {
                _context.TransactionCodes.Add(new TransactionCode
                {
                    AccountNo = m.accountNo,
                    COT = m.cto,
                    IMF = m.imf,
                    TAX = m.tax,
                    Status = CodeStatus.UNUSED.ToString(),
                    DateGenerated = DateTime.UtcNow

                });
                _context.SaveChanges();
                return Json(new { status = 200, message = "Successful" });

            }
            return Json(new { status = 0, message = "Something went wrong with the server" });
            //return View(m);
        }

        public ActionResult DeleteAuthorizationCodes(int id)
        {
            inject();
            var check = _context.TransactionCodes.Find(id);
            if(check == null)
            {
            
            }
            else
            {
                _context.TransactionCodes.Remove(check);
                _context.SaveChanges();
             
            }
            return RedirectToAction("AuthorizationCodes");
        }

        public ActionResult ApproveTransaction(int id)
        {
            inject();
            var check = _context.ForwardTransfers.Find(id);
            
            if (check == null) return RedirectToAction("Transactions");

            var accountService = new Services.Account();

            var balance = Convert.ToDecimal(accountService.GetBalance(check.AccountID));
            var newBalance = Convert.ToDecimal( balance - check.Amount);
            accountService.UpdateAccountBalance(check.AccountID, newBalance);

            check.Status = Services.TransactionStatus.SUCCESSFUL.ToString();
            _context.Entry(check);
            _context.SaveChanges();
            return  RedirectToAction("Transactions");

        }
        public ActionResult DeleteTransaction(int id)
        {
            inject();
            var check = _context.ForwardTransfers.Find(id);
            if (check == null)
            {

            }
            else
            {
                _context.ForwardTransfers.Remove(check);
                _context.SaveChanges();

            }
            return RedirectToAction("Transactions");
        }

        public ActionResult AuthorizationCodes()
        {
            inject();
            var list = _context.TransactionCodes.Include(a=>a.tblAccount).Include(a=>a.tblAccount.AspNetUser).ToList();
            return View(list);
        }

        public  ActionResult User1(string userid)
        {

            ViewBag.userid = userid;
            return View("User");
        }

        public ActionResult UserProfile(string userid)
        {
            inject();
            var user = _context.AspNetUsers.Find(userid);
            return PartialView("_UserProfile", user);
        }

        public ActionResult UserDetail(string userid)
        {
            inject();
            var user = _context.AspNetUsers.Find(userid);
            var userDto = new UserDto()
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                CountryId = user.CountryId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Sex,

            };
            return PartialView("_UserAccountDetail", userDto);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserDto m)
        {
            inject();
            var user = _context.AspNetUsers.Find(m.Id);
            if (user != null)
            {
                user.PhoneNumber = m.PhoneNumber;
                user.Address = m.Address;
                user.CountryId = m.CountryId;
                user.FirstName = m.FirstName;
                user.LastName = m.LastName;
                user.Sex = m.Gender;
            }
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("User1", new { userid = m.Id });
        }

        public ActionResult ChangePicture(string userid)
        {
            inject();
            var user = _context.AspNetUsers.Where(a => a.Id == userid).SingleOrDefault();
            var userPhoto = new UserPhoto()
            {
                Id = user.Id,
                PhotoUrl = user.ImageUrl

            };
            return PartialView("_UserPhoto", userPhoto);
        }

        [HttpPost]
        public ActionResult ChangePicture(UserPhoto userPhoto)
        {
            inject();

            string fileUrl = "https://res.cloudinary.com/votel/image/upload/v1550180723/1.jpg";
            if (userPhoto.ImageData != null)
            {
                //try upload 
                //var imageData = userDto.PictureUrl.Split(',')[1];
                var imageData = userPhoto.ImageData;

                //Remove this part "data:image/jpeg;base64,"
                // Base64String = Base64String.Split(',')[1];
                fileUrl = App.Services.FileUpload.uploadToNet(imageData);
                if (fileUrl == null)
                {
                    fileUrl = "https://res.cloudinary.com/votel/image/upload/v1550180723/1.jpg";
                }
            }
         var user =   _context.AspNetUsers.Where(a => a.Id == userPhoto.Id).SingleOrDefault();
            user.ImageUrl = fileUrl;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("User1", new { userid = userPhoto.Id });
        }

        public ActionResult UpdateBalance(string userid)
        {
            inject();

            var user = _context.tblAccounts.Where(a=>a.userId == userid).SingleOrDefault();
            UserBalance userBalance = new UserBalance
            {
                AccountNo = user.acctNo,
                Balance = Convert.ToDecimal(user.ActiveAmount),
                Id = user.userId
            };

            return PartialView("_UserCredit", userBalance);

        }
        [HttpPost]
        public ActionResult UpdateBalance(UserBalance m)
        {
            inject();

            var update = new Services.Account().UpdateAccountBalance(m.AccountNo, m.Balance);
            return RedirectToAction("User1", new { userid = m.Id });
            return RedirectToAction("User1", new { userid = m.Id });

        }

        public ActionResult CreateUser()
        {
            
            return View("CreateUser");
        }

        [HttpPost]
        public ActionResult CreateUser(UserDto userDto)
        {
            ApplicationDbContext context = new ApplicationDbContext();
         
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            inject();
            if (ModelState.IsValid)
            {
                //check if dto as file data
                string fileUrl = "https://res.cloudinary.com/votel/image/upload/v1550180723/1.jpg";
               if(userDto.PictureUrl != null)
                {
                    //try upload 
                    //var imageData = userDto.PictureUrl.Split(',')[1];
                    var imageData = userDto.PictureUrl;

                    //Remove this part "data:image/jpeg;base64,"
                    // Base64String = Base64String.Split(',')[1];
                    fileUrl = App.Services.FileUpload.uploadToNet(imageData);
                    if (fileUrl == null)
                    {
                        fileUrl = "https://res.cloudinary.com/votel/image/upload/v1550180723/1.jpg";
                    }
                }
                var user = new ApplicationUser {
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    DateStamp = DateTime.UtcNow,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    PhoneNumber = userDto.PhoneNumber,
                    Sex= userDto.Gender,
                    CountryId = userDto.CountryId,
                    ImageUrl = fileUrl,
                };
                var createUser = UserManager.Create(user, userDto.Password);
                if (createUser.Succeeded)
                {
                    new Services.Account().AddAccount(user.Id);
                    return RedirectToAction("Users");
                }

            }
            return View(userDto);
        }

        public ActionResult DeleteUser(string userid)
        {
            inject();
            var check = _context.AspNetUsers.Find(userid);
            if (check == null)
            {

            }
            else
            {
                _context.AspNetUsers.Remove(check);
                _context.SaveChanges();

            }
            return RedirectToAction("Users");
        }

        public ActionResult BlockUser(int userid)
        {
            inject();
            var check = _context.AspNetUsers.Find(userid);
            if (check == null)
            {

            }
            else
            {
                check.LockoutEnabled = true;
              //  check.LockoutEndDateUtc = DateTime.UtcNow;
                _context.Entry(check).State = EntityState.Modified;

                _context.SaveChanges();

            }
            return RedirectToAction("Users");
        }
        public ActionResult UnBlockUser(int userid)
        {
            inject();
            var check = _context.AspNetUsers.Find(userid);
            if (check == null)
            {

            }
            else
            {
                check.LockoutEnabled = false ;
              //  check.LockoutEndDateUtc = DateTime.UtcNow +;
                _context.Entry(check).State = EntityState.Modified;

                _context.SaveChanges();

            }
            return RedirectToAction("Users");
        }

        public ActionResult Feedbacks()
        {
            inject();
            var feeds = _context.tblfeedbacks.ToList().OrderByDescending(a => Convert.ToDateTime(a.datesent));
            return View(feeds);

        }

        public ActionResult DeleteFeed(int id)
        {
            inject();
           var feed = _context.tblfeedbacks.Where(a=>a.id == id).SingleOrDefault();
            _context.tblfeedbacks.Remove(feed);
            _context.SaveChanges();
            return RedirectToAction("Feedbacks");
        }


    }
}
