﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            this.db = db;
            Category = new CategoryRepository(db);
            CoverType = new CoverTypeRepository(db);
            Product = new ProductRepository(db);
        }

        public ICategoryRepository Category { get; private set; }


        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }

        

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
