using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCapp.BLL.Dtos.Req;
using MVCapp.BLL.Services;

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

            return View(products);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(product);
        }


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
    }
}