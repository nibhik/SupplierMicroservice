using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Supplier.Model;
using Supplier.Repository;
using SupplierMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Supplier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class SupplierController : ControllerBase
    {
        private IGenericRepo<Supplier_data,Supplier_Part> repository;
        private readonly ILogger<SupplierController> logger;



        public SupplierController(IGenericRepo<Supplier_data,Supplier_Part> genericRepo, ILogger<SupplierController> logger)
        {
            repository = genericRepo;
            this.logger = logger;
        }

        //working
        [HttpGet("GetAllSuppliers")]
        public IActionResult GetAllSupplier()
        {
            logger.LogInformation("Getting all the suppliers", DateTime.Now);
            return Ok(repository.GetAllSupplierData());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSupplierOfPart")]
        public IActionResult GetSupplierOfPart(int id)
        {
            var result = repository.GetSupplierByPartsAsync(id);
            if (result == null)
            {
                logger.LogWarning("Part Id not found{0}", DateTime.Now);
                return NotFound();
            }
               
            return Ok(result);
        }



        // this end point sends all suppliers if parts or
        //working
        [HttpGet("GetAllSupplierOfPart")]
        public async Task<ActionResult<List<Supplier_data>>> GetAllSupplierOfPart()
        {
            var result = repository.GetAllSupplierByPartsAsync();
            if (result == null)
            {
                logger.LogWarning("All supplier of part details not found", DateTime.Now);
                return NotFound();
            }
            return Ok(result);
        }

        //working
        [Authorize(Roles = "Admin")]
        [HttpPost("addSupplier")]
        public async Task<IActionResult> AddSupplier(SPView sup)
        {
            bool response = await repository.AddSupplier(sup);
            if (response == true)
            {
                logger.LogInformation("Supplier and part details added successfully", DateTime.Now);
                return Ok("Success");
            }
            else
            {
                logger.LogWarning("Supplier not added", DateTime.Now);
                return BadRequest("Error , All fields are required ");
            }
                
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier(SPView request)
        {
            bool response = await repository.UpdateSupplier(request);
            if (response == true)
            {
                logger.LogInformation("Supplier and part details updated.", DateTime.Now);
                return Ok("Updated");
            }     
            else
            {
                logger.LogWarning("Details not updated", DateTime.Now);
                return BadRequest("Error");
            }
                
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateFeedback")]

        public async Task<IActionResult> UpdateFeedback(Supplier_data request)
        {
            bool response = await repository.UpdateFeedback(request);
            if (response == true)
            {
                logger.LogInformation("Feedback updated.", DateTime.Now);
                return Ok("Updated");
            }
            else
            {
                logger.LogWarning("Feedback not updated", DateTime.Now);
                return BadRequest("Error, All fields Required .");
            }
        }

    }
}
