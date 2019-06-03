using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InvoicesAppMVC.Models;

namespace InvoicesAppMVC.Controllers
{
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IDocumentDBRepository<Invoice> Repository;
        public InvoiceController(IDocumentDBRepository<Invoice> Repository)
        {
            this.Repository = Repository;
        }

        [ActionName("Index")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await Repository.GetItemsAsync();
            return View(items);
        }

#pragma warning disable 1998
        [HttpGet]
        [ActionName("Create")]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            Invoice invoice = new Invoice();
            return View("Create", invoice);
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await Repository.CreateItemAsync(invoice);
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public async Task<ActionResult> EditAsync(Invoice item)
        {
            if (ModelState.IsValid)
            {
                await Repository.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Invoice item = await Repository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Invoice item = await Repository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete")]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await Repository.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        [Route("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Invoice item = await Repository.GetItemAsync(id);
            return View(item);
        }

        //TODO: Maybe move these to separate API

    }
}