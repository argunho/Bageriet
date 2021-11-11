using Bageriet.Context;
using Bageriet.Intefaces;
using Bageriet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Repositories
{
    public class ProductsRepository : IProducts
    {
        private readonly DBContext db;
        


        public ProductsRepository(DBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Products> AllProducts {
            get
            {
                return db.products.Where(x => x.Visible);
            }
        }

        public Products GetProduct(int id)
        {
            return db.products.Include(r => r.Ratings).Include(c => c.Comments)
                                    .FirstOrDefault(x => x.Id == id && x.Visible);
        }

        public void Add(Products product)
        {
            db.products.Add(product);
        }

        public void Edit(Products product)
        {

        }
        public void Delete(int id)
        {
            
        }

        // Add rating
        public void AddRating(Ratings rating)
        {
            db.rating.Add(rating);
        }


        // Method Save DB
        public bool Save()
        {
            try { db.SaveChanges(); return true; }
            catch (Exception e) { return false; }
        }
    }
}
