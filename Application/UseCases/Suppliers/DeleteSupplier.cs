using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Suppliers
{
    public class DeleteSupplier
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplier(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Execute(int id)
        {
            await _supplierRepository.DeleteSupplier(id);
        }
    }
}
