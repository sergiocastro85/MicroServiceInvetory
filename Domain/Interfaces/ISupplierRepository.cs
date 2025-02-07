using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();

        Task<Supplier> GetSupplierById(int id);

        Task AddSupplier(Supplier supplier);

        Task UpdateSupplier(Supplier supplier);

        Task DeleteSupplier(int id);
    }
}
