using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
       
        [HttpGet]
       
        public IActionResult Index()
        {
            return View();
        }
        //yeni kayıt yapacağımız için post işlemi yaptık..
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model )
        {
            //async yapmamız nedeni ıdentity kütüphanesi kullanmak.
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.SurName,
                UserName = model.UserName,
                Email=model.Mail,
                Gender="Kadın"
            };
            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError(" ", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
