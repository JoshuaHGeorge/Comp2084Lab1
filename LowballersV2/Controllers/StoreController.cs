using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LowballersV2.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Models.Category>();

            // create 10 mock categories
            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Models.Category { Name = "Category " + i.ToString() });
            }
            // when returning the view, also return the list
            return View(categories);
        }

        public IActionResult Browse(string category)
        {
            // add selected category to VIewBag to display the brose page
            ViewBag.category = category;
            return View();
        }
    }
}