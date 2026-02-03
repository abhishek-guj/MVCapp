using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MVCapp.BLL.Dtos.Res;
using MVCapp.DAL.Repositories;

namespace MVCapp.BLL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
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
            var prods = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(prods);
        }

    }
}