using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowballersV2.Controllers;
using LowballersV2.Models;
using System.Linq;

namespace LowballersTest
{
    [TestClass]
    public class ProductControllerTest 
    {
        // db context in moemory for dependencty injection
        private lowballersContext _context;
        ProductsController productsController;
        List<Products> products;

        // adding this anotation automatically runs this method before every test
        [TestInitialize]
        public void TestInitialize()
        {
            // create in-memory context and inject to controller instance
            var options = new DbContextOptionsBuilder<lowballersContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var category = new Categories
            {
                CategoryId = 10,
                Name = "Some Category"
            };

            products.Add(new Products
            {
                ProductId = 10,
                Name = "Prod",
                Price = 10,
                Category = category
            });
            products.Add(new Products
            {
                ProductId = 20,
                Name = "Prod",
                Price = 10,
                Category = category
            });
            products.Add(new Products
            {
                ProductId = 30,
                Name = "Prod",
                Price = 10,
                Category = category
            });
            products.Add(new Products
            {
                ProductId = 40,
                Name = "Prod",
                Price = 10,
                Category = category
            });

            foreach (var p in products)
            {
                _context.Products.Add(p);
            }
            productsController = new ProductsController(options);



            //pruductsController = new ProductsController(_context);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
            var homeController = new ProductsController();

            // act
            var result = (ViewResult)homeController.Index();

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsProducts()
        {
            //arrange

            // act
            var result = productsController.Index();
            var viewResult = (viewResult)result.Result;
            List<Products> model = (List<Products>)viewResult.Model;

            // assert
            CollectionAssert.AreEqual(products.OrderBy(p => p.Name).ToList, model);
        }
    }
}
