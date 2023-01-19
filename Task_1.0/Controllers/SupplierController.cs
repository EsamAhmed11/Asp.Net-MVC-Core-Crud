using Microsoft.AspNetCore.Mvc;
using Task_1._0.Models;
using Task_1._0.Repository;
using Task_1._0.ViewModel;

namespace Task_1._0.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierRepository supplierRepository;

        public SupplierController( SupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public async Task<IActionResult> ShowAll()
        {
            return View(await supplierRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(SupplierVM NewSupplierVM)
        {
            if (ModelState.IsValid)
            {
                Supplier NewSupplier = new Supplier()
                {
                    SupplierName = NewSupplierVM.SupplierName
                };

              await  supplierRepository.AddAsync(NewSupplier);
                await supplierRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));
            }
            return View(NewSupplierVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edite(int id)
        {
            Supplier supplier = await supplierRepository.GetByIdAsync(id);
            SupplierVM supplierVM = new SupplierVM()
            {
                SupplierID = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
            };
            return View(supplierVM);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Edite(SupplierVM  supplierVM_Modefied)
        {
            if (ModelState.IsValid)
            {
                Supplier SupplierModefied = new Supplier()
                {
                    SupplierID=supplierVM_Modefied.SupplierID,
                    SupplierName = supplierVM_Modefied.SupplierName
                };
                await supplierRepository.UpdateAsync(SupplierModefied);
                await supplierRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));
            }
            else
                return View(supplierVM_Modefied);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id > 0)
            {
                await supplierRepository.DeleteAsync(id);
                await supplierRepository.SaveChange_();
                return RedirectToAction(nameof(ShowAll));

            }
            return RedirectToAction(nameof(ShowAll));

        }
    }
}
