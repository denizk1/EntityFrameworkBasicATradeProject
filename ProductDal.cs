using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll() //hepsini getir
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }

        }
        public List<Product> GetbyName(string key) //sadece ismi getir
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }

        }
        public Product GetById(int id) //aramak istediğin ürünü getir
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.FirstOrDefault(p => p.Id==id);

            }

        }
        public List<Product> GetbyUnitPrice(decimal min,decimal max) 
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=min && p.UnitPrice<max).ToList();
            }

        }
        public void Add(Product product) //ekle
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product product) //guncelle
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);// gönderilen producttı veritabanındakiyle eslestiriyor
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Product product) //sil
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);// gönderilen producttı veritabanındakiyle eslestiriyor
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
