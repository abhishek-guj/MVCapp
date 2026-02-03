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
        // Task<List<Product>> GetAllProductsAsync();
        Task<bool> GetAllProductsAsync();
        // Task AddProductAsync(Product product);
    }


    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<> GetAllProductsAsync()
        {
            return true;
            // return await _context.Users.ToListAsync();
        }
        // Task AddProductAsync(Product product);

    }
}