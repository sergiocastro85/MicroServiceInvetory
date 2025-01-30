﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Suppliers
{
    public class AddSupplier
    {
        private readonly ISupplierRepository _supplierRepository;

        public AddSupplier(ISupplierRepository supplierReposit)
        {
            _supplierRepository = supplierReposit;
            
        }

        public void Execute(Supplier supplier)
        {
            _supplierRepository.AddSupplier(supplier);
        }
    }
}
