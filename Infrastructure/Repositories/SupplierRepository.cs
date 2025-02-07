using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly InventoryContext _context;

        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierById(int id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task AddSupplier(Supplier supplier)
        {
           await _context.Suppliers.AddAsync(supplier);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
          _context.Entry(supplier).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
               await _context.SaveChangesAsync();
            }
        }






    }
}
