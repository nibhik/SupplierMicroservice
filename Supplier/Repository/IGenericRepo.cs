using Supplier.Model;
using SupplierMicroservice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Repository
{
    public interface IGenericRepo<TEntity,T> where TEntity : class
    {
        TEntity Add(TEntity item);
        TEntity Update(TEntity item);
        TEntity Remove(TEntity item);
        IReadOnlyCollection<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
        Task<int> SaveAsync();

        IEnumerable GetSupplierByPartsAsync(int id);
        IReadOnlyCollection<Supplier_data> GetAllSupplierData();
        IEnumerable GetAllSupplierByPartsAsync();
        Task<bool> AddSupplier(SPView sp);
        Task<bool> UpdateSupplier(SPView request);
        Task<bool> UpdateFeedback(Supplier_data request);
    }

}
