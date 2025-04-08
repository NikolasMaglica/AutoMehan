using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DbContextCl _blogDbContext;

        public BlogRepository(DbContextCl blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
               .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                  .Where(model => model.Id == id)
                  .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, blog.Id)
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.Author, blog.Author)
                    .SetProperty(m => m.ImageUrl, blog.ImageUrl)
                  );
        }
    }
}