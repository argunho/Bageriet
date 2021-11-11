using Bageriet.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Components
{
    public class Ratings : ViewComponent
    {
        private readonly DBContext _db;

        public Ratings(DBContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke(int? id)
        {
            var _ratings = _db.rating.Include(p => p.Product).Include(u => u.User).Where(x => x.Product.Id == id)
                .OrderByDescending(x => x.Rating).ToList() ?? null;
            if(_ratings.Count > 0)
            {
                var ratings = 0;
                var rating = _ratings[0];
                for(var i = 0;i < _ratings.Count; i++)
                {
                    var _rating = _ratings[i].Rating;
                    var count = _ratings.Count(x => x.Rating == _rating);
                    if (count > ratings)
                    {
                        rating = _ratings[i];
                        ratings = count;
                    }
                }
                return View(rating);
            }
            return View(default(Ratings));
        }
    }
}
