using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCapp.BLL.Dtos.Req;
using MVCapp.BLL.Dtos.Res;
using MVCapp.BLL.Services;
using MVCapp.PL.Filter;
using MVCapp.PL.Models;

namespace MVCapp.PL.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            var ttl = _productService.GetTotalProducts();

            ProductViewModel pvm = new ProductViewModel
            {
                Products = products,
                TotalQty = ttl
            };


            return View(pvm);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }


        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, ProductUpdateDto dto)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            await _productService.UpdateProduct(dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);
            await _productService.CreateProduct(productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet("Filter")]
        public IActionResult Filter()
        {
            throw new UnauthorizedAccessException("Access Denied.......!");
        }
    }
}