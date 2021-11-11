using Bageriet.Context;
using Bageriet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Components
{
    public class RatingsList : ViewComponent
    {
        private readonly DBContext _db;

        public RatingsList(DBContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke(int? id)
        {
 
            var ratings = _db.rating.Include(p => p.Product).Include(u => u.User)
                                .Where(x => x.Product.Id == id).ToList() ?? null;

            return View(ratings);
        }
    }
}
