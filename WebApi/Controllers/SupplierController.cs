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
        public IEnumerable<Supplier> Get()
        {
            return _getAllSuppliers.Execute();
        }

        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById(int id)
        {
            var supplier = _getSupplierById.Execute(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return supplier;
        }

        [HttpPost]
        public ActionResult<Supplier> Post([FromBody] Supplier supplier)
        {
            _addSupplier.Execute(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Supplier supplier)
        {
            if(id != supplier.Id)
            {
                return BadRequest();
            }
            _updateSupplier.Execute(supplier);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _deleteSupplier.Execute(id);
            return NoContent();
        }
    }
}
