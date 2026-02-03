using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCapp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MVCapp.DAL.Store;

namespace MVCapp.DAL.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(Guid id);
    }


    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task Delete(Guid id)
        {
            var pro = await _context.Products.FindAsync(id);
            if (pro != null)
            {
                _context.Products.Remove(pro);
                await _context.SaveChangesAsync();
            }
        }
    }
}