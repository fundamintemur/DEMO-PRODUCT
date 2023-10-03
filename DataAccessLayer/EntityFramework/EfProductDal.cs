using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal:GenericRepository<Product>,IProductDal
    {
        ///generic repository miras alacaksn ve entity bekliyor buraya
        ///product yazdık
        ///aynı zamanda interfaceden miras aldık.

        //sadece bu entity ait metolar tanımalayabileceğim zamann kullanacağım
    }
}
