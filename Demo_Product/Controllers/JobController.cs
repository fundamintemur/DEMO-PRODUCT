using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = jobManager.TGetList();
            return View(values);
        }
        [HttpGet]
        //sayfa ilk açıldığında verilerin yüklenmesi içinn..
        public IActionResult AddJob()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            //validator sınıfını kullanmak  için productvalitor sınıfını çağırdık.
            //ProductValidator validationRules = new ProductValidator();
            //ValidationResult results = validationRules.Validate(p);
            //if (results != null)
            //{
                jobManager.TInsert(p);

                return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }


        public IActionResult DeleteJob(int id)
        {
            var value = jobManager.TGetById(id);
            jobManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            //ilk başta güncelleme yapacağımız alanıı bulduk.
            //Update product ıd gönderdik.
            var value = jobManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {

            jobManager.TUpdate(p);
            return RedirectToAction("Index");



        }
    }
}

