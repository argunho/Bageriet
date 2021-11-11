using Bageriet.Context;
using Bageriet.Interfaces;
using Bageriet.Models;
using Bageriet.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Repositories
{
    public class CommentsRepository : IComments
    {
        private readonly DBContext db;

        public CommentsRepository(DBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Comments> AllComments
        {
            get
            {
                return db.comments.ToList();
            }
        }

        public Comments GetComment(int id)
        {
            return db.comments.Include(p => p.Product).Include(u => u.User).FirstOrDefault(x => x.Id == id);
        }

        public void Add(Comments comment)
        {
            db.comments.Add(comment);
        }

        public void Edit(Comments comment)
        {

        }

        public void Delete(int id)
        {

        }

        // Method Save DB
        public bool Save()
        {
            try { db.SaveChanges(); return true; }
            catch (Exception e) { return false; }
        }
    }
}
