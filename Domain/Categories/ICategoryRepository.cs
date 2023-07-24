using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Categories
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int id);
    }
}
