using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    //generic repository amaç yazdığımız metodların içini doldurmak..
    public class GenericRepository<T> : IGenericDal<T> where T : class
        //generic repository dışardan bir entity almalı
        //ıgenericdaldan kalıtım almalı 
        //ıgenericdal dışardan t entity alıyordu ve bu entity bir classdan almalı
        //yazdığımız where şartı
    {
        //Context c = new Context();
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
            //set entity göre ayarlama yaptık.
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
