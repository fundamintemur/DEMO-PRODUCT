using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //data access tarafındaki değerleine erişim sağlamam gerekiyor
    //data access tarafındaki repository lere yada entity framework değerlirine erişim sağlamam lazım.
    public class ProductManager : IGenericService<Product>
    {
        //burda IProductDal dan değer türettik.
        IProductDal _productDal;
        //bunu product reposiotry haberleştirmem gerekiyor
        //ben şimdi generic repositorydeki işlemleri _productdal tarafından yapacağım.
        public ProductManager(IProductDal productDal)
        //classla aynı isimle metod oluşturduk buna constructor deriz yani yapıcı metod.

        {
            _productDal = productDal;
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);

        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public void TInsert(Product t)
        {
            _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
