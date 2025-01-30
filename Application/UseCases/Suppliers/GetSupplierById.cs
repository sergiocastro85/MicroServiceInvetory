using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Suppliers
{
    public class GetSupplierById
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierById(ISupplierRepository supplierRepository)
        {
           _supplierRepository = supplierRepository;
            
        }

        public Supplier Execute(int id)
        {
            return _supplierRepository.GetSupplierById(id);
        }
    }
}
