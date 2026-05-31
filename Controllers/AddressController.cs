using AddressBookApp.BM.ITF;
using AddressBookApp.UIW.VM;
using AddressBookApp.UIW.VM.EX;
using AddressBookApp.VO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AddressBookApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressBM _bm;

        public AddressController(IAddressBM bm)
        {
            _bm = bm;
        }

        public IActionResult Index()
        {
            var vos = _bm.GetAll() ?? new System.Collections.Generic.List<AddressVO>();
            var vms = vos.Select(AddressViewModel.FromVO).ToList();
            return View(vms);
        }

        public IActionResult Create()
        {
            return View(new AddressViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddressViewModel vm)
        {
            vm.UpdateAge();
            var (ok, msg) = vm.Validate();
            if (!ok)
            {
                ModelState.AddModelError("", msg);
                return View(vm);
            }
            var id = _bm.Create(vm.ToVO());
            if (id > 0) return RedirectToAction("Index");
            ModelState.AddModelError("", "create-failed");
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var vo = _bm.GetById(id);
            var vm = AddressViewModel.FromVO(vo);
            if (vm == null) return NotFound();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddressViewModel vm)
        {
            vm.UpdateAge();
            var (ok, msg) = vm.Validate();
            if (!ok)
            {
                ModelState.AddModelError("", msg);
                return View(vm);
            }
            var success = _bm.Update(vm.ToVO());
            if (success) return RedirectToAction("Index");
            ModelState.AddModelError("", "update-failed");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var success = _bm.Delete(id);
            if (success) return RedirectToAction("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var vo = _bm.GetById(id);
            var vm = AddressViewModel.FromVO(vo);
            if (vm == null) return NotFound();
            return View(vm);
        }
    }
}
