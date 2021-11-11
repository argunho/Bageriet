using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bageriet.Intefaces;
using Bageriet.Interfaces;
using Bageriet.Models;
using Bageriet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bageriet.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IComments _comment;
        private readonly IProducts _product;
        private readonly UserManager<Users> _userManager;

        public CommentsController(IComments comment, IProducts product, UserManager<Users> userManager)
        {
            _comment = comment;
            _product = product;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public JsonResult AddComments(CommentsViewModel model)
        {
            if (model.Text != null)
            {
                var user = _userManager.GetUserAsync(User).Result;
                var product = _product.GetProduct(model.ProductId) ?? null;
                var comment = new Comments
                {
                    User = user,
                    Text = model.Text,
                    Product = product
                };
                _comment.Add(comment);
                return Json(_comment.Save());
            }

            return Json(false);
        }
    }
}