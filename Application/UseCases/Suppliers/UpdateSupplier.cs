using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Suppliers
{
    public class UpdateSupplier
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplier(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void Execute(Supplier supplier)
        {
            _supplierRepository.UpdateSupplier(supplier);
        }
    }
}
