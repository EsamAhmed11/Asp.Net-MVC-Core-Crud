using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_1._0.Models;
using Task_1._0.Repository;
using Task_1._0.ViewModel;

namespace Task_1._0.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly SupplierRepository supplierRepository;

        public ProductController(ProductRepository productRepository , SupplierRepository supplierRepository)
        {
            this.productRepository = productRepository;
            this.supplierRepository = supplierRepository;
        }

        //Action to Get and Show All  Product  in page
        public async Task<IActionResult> ShowAll()
        {
            return View(await productRepository.GetAllAsync());
        }

        //Action to Show Create Page
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //Get All Supplier To Select one When Create New Product
            ViewBag.supplier = new SelectList(await supplierRepository.GetAllAsync(), "SupplierID", "SupplierName");
            return View();
        }

        ////Action to Get Product and save it to DB
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(ProductVM NewProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    ProductName = NewProduct.ProductName,
                    QuantityPerUnit = NewProduct.QuantityPerUnit,
                    UnitPrice = NewProduct.UnitPrice,
                    ReorderLevel = NewProduct.ReorderLevel,
                    UnitsOnOrder = NewProduct.UnitsOnOrder,
                    UnitsInStock = NewProduct.UnitsInStock,
                    SupplierID = NewProduct.SupplierID,
                };
                await productRepository.AddAsync(product);
                await productRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));
            }
            else
            {
                ViewBag.supplier = new SelectList(await supplierRepository.GetAllAsync(), "SupplierID", "SupplierName");
                return View(NewProduct);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edite(int id)
        {
            ViewBag.supplier = new SelectList(await supplierRepository.GetAllAsync(), "SupplierID", "SupplierName");
            Product p = await productRepository.GetByIdAsync(id);
            return View(p);
        }


        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Edite(ProductVM productModfied)
        {
            Product product = new Product()
            {
                ProductID = productModfied.ProductID,
                ProductName = productModfied.ProductName,
                QuantityPerUnit = productModfied.QuantityPerUnit,
                UnitPrice = productModfied.UnitPrice,
                ReorderLevel = productModfied.ReorderLevel,
                UnitsOnOrder = productModfied.UnitsOnOrder,
                UnitsInStock = productModfied.UnitsInStock,
                SupplierID = productModfied.SupplierID,
            };
            if (ModelState.IsValid)
            {     
                await productRepository.UpdateAsync(product);
                await productRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));
            }
            ViewBag.supplier = new SelectList(await supplierRepository.GetAllAsync(), "SupplierID", "SupplierName");
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id! > 0)
            {
                await productRepository.DeleteAsync(id);
                await productRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));
            }
            return RedirectToAction(nameof(ShowAll));
        }

    }
}
