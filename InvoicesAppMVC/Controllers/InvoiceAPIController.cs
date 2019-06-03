using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using InvoicesAppMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace InvoicesAppMVC.Controllers
{
    [ApiController]
    [Route("api")]
    public class ItemAPIController : ControllerBase
    {
        // TODO: Access to API should be restricted by a secret key which is sent as a header value in the request. 
        private readonly IDocumentDBRepository<Invoice> Repository;
        public ItemAPIController(IDocumentDBRepository<Invoice> Repository)
        {
            this.Repository = Repository;
        }

        //[Authorize(Policy = "ApiKeyPolicy")]
        [HttpGet]
        [Route("GetUnpaidInvoices")]
        public async Task<IEnumerable<Invoice>> GetUnpaidInvoices()
        {
            var items = await Repository.GetItemsAsync(d => !d.Paid);
            return items;
        }

        [Authorize(Policy = "ApiKeyPolicy")]
        [HttpPut]
        [Route("PayInvoice")]
        public async Task<IActionResult> PayInvoice([FromQuery]string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                Invoice invoice = await Repository.GetItemAsync(id);
                invoice.Paid = true;
                await Repository.UpdateItemAsync(id, invoice);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Policy = "ApiKeyPolicy")]
        [HttpPatch]
        [Route("JsonPatchWithModelState")]
        public async Task<IActionResult> JsonPatchWithModelState([FromBody] JsonPatchDocument<Invoice> patchDoc)
        {
            if (patchDoc != null)
            {
                Invoice invoice = new Invoice();

                patchDoc.ApplyTo(invoice, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await Repository.UpdateItemAsync(invoice.Id, invoice);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}