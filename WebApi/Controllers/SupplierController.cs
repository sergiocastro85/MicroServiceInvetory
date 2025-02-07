using Application.UseCases.Suppliers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly GetAllSuppliers _getAllSuppliers;

        private readonly GetSupplierById _getSupplierById;

        private readonly AddSupplier _addSupplier;

        private readonly UpdateSupplier _updateSupplier;

        private readonly DeleteSupplier _deleteSupplier;


        public SupplierController(GetAllSuppliers getAllSuppliers, GetSupplierById getSupplierById,
                                  AddSupplier addSupplier, UpdateSupplier updateSupplier, DeleteSupplier deleteSupplier)
        {
            _getAllSuppliers = getAllSuppliers;
            _getSupplierById = getSupplierById;
            _addSupplier = addSupplier;
            _updateSupplier = updateSupplier;
            _deleteSupplier = deleteSupplier;

        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get()
        {
            return await _getAllSuppliers.Execute();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _getSupplierById.Execute(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Post([FromBody] Supplier supplier)
        {
            await _addSupplier.Execute(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Supplier supplier)
        {
            if(id != supplier.Id)
            {
                return BadRequest();
            }
            await _updateSupplier.Execute(supplier);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _deleteSupplier.Execute(id);
            return NoContent();
        }
    }
}
