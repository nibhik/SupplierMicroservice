using SupplierMicroservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Repository
{
    public interface ISupplierRepo
    {
        Task<List<Supplier_data>> GetSupplierOfPart(int id);
        Task<List<Supplier_data>> AddSupplier(Supplier_data sup);

        Task<List<Supplier_Part>> AddPart(Supplier_Part sup);
        Task<List<Supplier_data>> UpdateSupplier(Supplier_data request);
        Task<List<Supplier_data>> UpdateFeedback(Supplier_data request);

    }
}
