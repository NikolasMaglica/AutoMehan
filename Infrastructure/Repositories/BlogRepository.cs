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
        private readonly DbContextCl _dbContext;
        public BlogRepository(DbContextCl dbContextCl) 
        {
            _dbContext = dbContextCl;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dbContext.Blogs
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
         }

        public Task<List<Blog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
