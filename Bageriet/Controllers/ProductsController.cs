using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bageriet.Context;
using Bageriet.Intefaces;
using Bageriet.Models;
using Bageriet.Repositories;
using Bageriet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bageriet.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProducts _products;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<Users> _userManager;

        public ProductsController(
                        IProducts products,
                        IWebHostEnvironment hosting = null,
                        UserManager<Users> userManager = null
            )
        {
            _products = products;
            _hosting = hosting;
            _userManager = userManager;
        }


        [Route("Products")]
        [Route("Products/Products")]
        public IActionResult Products()
        {
            ViewBag.PageTitle = "Våra produkter";
            return View(_products.AllProducts);
        }

        [Authorize(Roles = "Admin")]
        [Route("NewProduct")]
        [Route("Products/NewProduct")]
        public IActionResult NewProduct()
        {
            ViewBag.PageTitle = "Nya Produkt";
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult SaveNewProduct(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imgName = null;
                if (model.Image != null)
                {
                    if (model.Image.ContentType.IndexOf("image") == -1)
                        return Json(new
                        {
                            error = true,
                            msg = "Fel format på filen ... "
                        });
                    try
                    {
                        imgName = model.Name.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + model.Image.ContentType.Substring(model.Image.ContentType.IndexOf("/") + 1);
                        string imgPath = Path.Combine(_hosting.WebRootPath, "images/products/" + imgName);
                        model.Image.CopyTo(new FileStream(imgPath, FileMode.Create));
                    }
                    catch (Exception e)
                    {
                        return Json(new
                        {
                            error = true,
                            msg = "Något har gått snett ... Var vänlig kontrolera bilden och fösök igen .."
                        });
                    }

                }

                var product = new Products
                {
                    Name = model.Name,
                    Description = model.Description,
                    Visible = model.Visible,
                    Image = "/images/products/" + imgName
                };
                _products.Add(product);
                return Json(new { success = _products.Save() });
            }
            return Json(false);
        }



        [Route("ViewProduct/{id}")]
        [Route("Products/ViewProduct/{id}")]
        public IActionResult ViewProduct(int id)
        {
            var product = _products.GetProduct(id);
            if (product == null)
                return RedirectToAction("Products", "Products");
            ViewBag.PageTitle = product.Name;

            return View(product);
        }

        // Add rating to product
        [Authorize]
        [HttpPost]
        public JsonResult AddRatingToProduct(RatingsViewModel model)
        {
            if (model.ProductId > 0)
            {
                var product = _products.GetProduct(model.ProductId);
                if (product != null)
                {
                    var user = _userManager.GetUserAsync(User).Result;
                    var rating = new Ratings
                    {
                        Rating = model.Rating,
                        Product = product,
                        User = user
                    };

                    _products.AddRating(rating);
                    return Json(_products.Save());
                }
            }

            return Json(false);
        }

    }
}