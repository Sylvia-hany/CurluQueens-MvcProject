<<<<<<< HEAD
﻿
using AutoMapper;
=======
﻿using AutoMapper;
>>>>>>> main
using CurlyQueens.Models;
using CurlyQueens.Services;
using CurlyQueens.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Http;
using System.IO;
>>>>>>> main

namespace CurlyQueens.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        //inject
        public ProductController(IProductService productService, IMapper mapper, IWebHostEnvironment env)
        {
            _productService = productService;
            _mapper = mapper;
            _env = env;
        }

        //Get  /Product/Index
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: /Products/Search?term=curly
        public async Task<IActionResult> Search(string term)
        {
            var products = await _productService.SearchProductsAsync(term);
<<<<<<< HEAD
            return View("Index",products);
        }

        // GET: /Products/Create
        [Authorize(Roles = "Admin")]
=======
            return View("Index", products);
        }

        // GET: /Products/Create
        //[Authorize(Roles = "Admin")]
>>>>>>> main
        [HttpGet]
        public IActionResult Create()
        {
            return View("AddNew");
        }

        // POST: /Product/Create
<<<<<<< HEAD
        [Authorize(Roles ="Admin")]
=======
       // [Authorize(Roles = "Admin")]
>>>>>>> main
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model, IFormFile ImageFile)
        {
            //if (!ModelState.IsValid)
            //    return View("AddNew", model);

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "Images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                model.ImageUrl = "/Images/" + uniqueFileName;
            }

            await _productService.AddProductAsync(model);

            return RedirectToAction("Index");
        }

    }
<<<<<<< HEAD
}



=======
}
>>>>>>> main
