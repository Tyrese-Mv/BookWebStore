using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db) :base(db)
        {
            this.db = db;
        }


        public void Update(Product product)
        {
            //db.Products.Update(product);
            var objFromDb=db.Products.FirstOrDefault(u=>u.id==product.id);
            if (objFromDb != null)
            {
                objFromDb.Title = product.Title;
                objFromDb.ISBN = product.ISBN;
                objFromDb.Price=product.Price;
                objFromDb.Price50=product.Price50;
                objFromDb.ListPrice=product.ListPrice;
                objFromDb.Price100=product.Price100;
                objFromDb.Description=product.Description;
                objFromDb.CategoryId=product.CategoryId;
                objFromDb.Author=product.Author;
                objFromDb.CoverTypeId=product.CoverTypeId;
                if (product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
