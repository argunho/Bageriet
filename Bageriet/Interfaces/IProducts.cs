using Bageriet.Models;
using System.Collections.Generic;

namespace Bageriet.Intefaces
{
    public interface IProducts
    {
        IEnumerable<Products> AllProducts { get; }
        Products GetProduct(int id);
        void Add(Products product);
        void AddRating(Ratings rating);
        void Edit(Products product);
        void Delete(int id);
        bool Save();
    }
}