using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
 
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        public DashboardController(IProductService productService)
        {
            _productService = productService;
        }


        //  public IActionResult Privacy() => View();
       
        public async Task<IActionResult> Index()
        {
            
            var Products = await _productService.GetCatalogItems();
            foreach (var item in Products)
            {
                item.PictureUrl = string.Format("data:image/png;base64,{0}", item.PictureUrl);
                if (item.Id % 2 == 0)
                    item.isDisabled = "disabled";
            }
              return View(Products);
        }

        
        public async Task<IActionResult> AddCart(int id)
        {

            return RedirectToAction("Index");
        }
    }
}
