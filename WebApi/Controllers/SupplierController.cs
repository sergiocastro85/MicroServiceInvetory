using Application.UseCases.DTOs;
using Application.UseCases.Suppliers;
using AutoMapper;
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

        private readonly IMapper _mapper;


        public SupplierController(GetAllSuppliers getAllSuppliers, GetSupplierById getSupplierById,
                                  AddSupplier addSupplier, UpdateSupplier updateSupplier, DeleteSupplier deleteSupplier, IMapper mapper)
        {
            _getAllSuppliers = getAllSuppliers;
            _getSupplierById = getSupplierById;
            _addSupplier = addSupplier;
            _updateSupplier = updateSupplier;
            _deleteSupplier = deleteSupplier;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<SupplierDto>> Get()
        {
            var suppliers = await _getAllSuppliers.Execute();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id)
        {
            var supplier = await _getSupplierById.Execute(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return _mapper.Map<SupplierDto>(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Post([FromBody] Supplier supplier)
        {
            await _addSupplier.Execute(supplier);
            return CreatedAtAction(nameof(GetById), new { id = supplier.IdSupplier }, supplier);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Supplier supplier)
        {
            if(id != supplier.IdSupplier)
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
