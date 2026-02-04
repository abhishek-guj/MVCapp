using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCapp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MVCapp.DAL.Store;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MVCapp.DAL.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Add(Product product);
        // Task<Product> Update(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
        int GetTotalProducts();
    }


    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public readonly string? _connectionString;

        public ProductRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
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

        public async Task Update(Product product)
        {
            // return product;
            Product prod = await _context.Products.FindAsync(product.Id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Category = product.Category;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                _context.SaveChanges();
            }

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
        public int GetTotalProducts()
        {
            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new("SELECT COUNT(*) FROM Products", connection);
            connection.Open();
            return (int)command.ExecuteScalar();
        }
    }
}