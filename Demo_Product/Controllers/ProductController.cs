using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        //business tarafından nesne türetmemiz gerekiyor
        //bunuda productmanager çağırarak yaptık
        //neden productmanager çağırdık sınfları
        //çağırıp newleyebiliriz.

        ProductManager productManager=new ProductManager(new EfProductDal());
        //productmanager Iproductdal karşılayacak değer istiyor bunuda 
        //efproductdal karşılayarak yaptık.

        public IActionResult Index()
        {
            var values = productManager.TGetList();
            return View(values);
        }
        [HttpGet]
        //sayfa ilk açıldığında verilerin yüklenmesi içinn..
        public IActionResult AddProduct()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            //validator sınıfını kullanmak  için productvalitor sınıfını çağırdık.
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results != null)
            {
                productManager.TInsert(p);

                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.TGetById(id);
            productManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            //ilk başta güncelleme yapacağımız alanıı bulduk.
            //Update product ıd gönderdik.
            var value = productManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {

            productManager.TUpdate(p);
            return RedirectToAction("Index");
          

           
        }
    }
}
