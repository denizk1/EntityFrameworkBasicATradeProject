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
