using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MVCapp.BLL.Dtos.Req;
using MVCapp.BLL.Dtos.Res;
using MVCapp.DAL.Entities;
using MVCapp.DAL.Repositories;

namespace MVCapp.BLL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductById(Guid id);
        Task UpdateProduct(ProductUpdateDto productDto);
    }
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var prods = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(prods);
        }
        public async Task<ProductDto> GetProductById(Guid id)
        {
            var prod = await _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(prod);
        }

        public async Task UpdateProduct(ProductUpdateDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            await _productRepository.Update(product);
        }

    }
}