using Bageriet.Context;
using Bageriet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Components
{
    public class CommentsList : ViewComponent
    {
        private readonly DBContext _db;

        public CommentsList(DBContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke(int? id)
        {
            var comments = _db.comments.Include(p => p.Product).Include(u => u.User).Where(x => x.Product.Id == id)
                                .OrderByDescending(x => x.Date).ToList() ?? null;

            return View(comments);
        } 
    }
}
