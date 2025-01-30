using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Suppliers
{
    public class GetAllSuppliers
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSuppliers(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> Execute()
        {
            return _supplierRepository.GetSuppliers();
        }
    }
}
