using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  interface IBlogService
    {
        Task<Blog> CreateAsync(Blog blog);

        Task<List<Blog>> GetAllAsync();
        Task<List<Blog>> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id,Blog blog);
        Task<int> DeleteAsync(int id);

    }
}
