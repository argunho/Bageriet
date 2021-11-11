using Bageriet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Interfaces
{
    public interface IComments
    {
        IEnumerable<Comments> AllComments { get; }
        Comments GetComment(int id);
        void Add(Comments comment);
        void Edit(Comments comment);
        void Delete(int id);
        bool Save();
    }
}
