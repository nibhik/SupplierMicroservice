using Microsoft.EntityFrameworkCore;
using Supplier.Model;
using SupplierMicroservice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier.Repository
{
    public class GenericRepo<TEntity,T> : IGenericRepo<TEntity,T> where TEntity : class
    {
        private readonly MyContext context;
        public GenericRepo(MyContext myContext)
        {
            context = myContext;
        }
        public TEntity Add(TEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddSupplier(SPView sup)
        {
            if(sup.partid == 0 && sup.supplier_id == 0) 
                return false;
            var check =  context.Suppliers.Find(sup.supplier_id);
           
            if (check == null)
            {
                Supplier_data supplier1 = new Supplier_data { email = sup.email, name = sup.name, phone = sup.phone, location = sup.location, feedback = sup.feedback };
                context.Suppliers.Add(supplier1);
                await context.SaveChangesAsync();
                Supplier_data _Data1 = context.Suppliers.ToList().Last();
                Supplier_Part part1 = new Supplier_Part { partid = sup.partid, partname = sup.partname, quantity = sup.quantity, timeperiod = sup.timeperiod, sid = _Data1.supplier_id };
                context.Supplier_Parts.Add(part1);
                await context.SaveChangesAsync();
                Supplier_Part _Part1 = context.Supplier_Parts.ToList().Last();
                JoinTables res1 = new JoinTables { getsupplier = _Data1, getsupplier_part = _Part1 };
                return true;
            }
            else if (check != null)
            {
                Supplier_data _Data2 = context.Suppliers.Find(sup.supplier_id);

                var check_supplierPart = context.Supplier_Parts.Where(s => s.sid == _Data2.supplier_id).OrderByDescending(s => s.partid).First();
                
                if (check_supplierPart != null)
                {
                    Supplier_Part part2 = new Supplier_Part { partid = check_supplierPart.partid + 1 , partname = sup.partname, quantity = sup.quantity, timeperiod = sup.timeperiod, sid = _Data2.supplier_id };
                    context.Supplier_Parts.Add(part2);
                    await context.SaveChangesAsync();
                }
                else
                {
                    Supplier_Part part2 = new Supplier_Part { partid = 1 , partname = sup.partname, quantity = sup.quantity, timeperiod = sup.timeperiod, sid = _Data2.supplier_id };
                    context.Supplier_Parts.Add(part2);
                    await context.SaveChangesAsync();
                }
                
                Supplier_Part _Part2 = context.Supplier_Parts.ToList().Last();
                JoinTables res2 = new JoinTables { getsupplier = _Data2, getsupplier_part = _Part2 };
                return true;
            }
            else
                return false;
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            var Data = context.Set<TEntity>().ToList();
            return Data.AsReadOnly();
        }

        public IEnumerable GetAllSupplierByPartsAsync()
        {
            List<Supplier_data> lsupplier = context.Suppliers.ToList();
            List<Supplier_Part> lsupplier_part = context.Supplier_Parts.ToList();
            var query = from s in lsupplier
                        join sp in lsupplier_part on s.supplier_id equals sp.sid

                        select new { s.supplier_id, s.name, s.location, s.phone , s.email , s.feedback, sp.partid, sp.partname, sp.quantity, sp.timeperiod };
            //select new { s.supplier_id, s.name, s.location, s.email, s.phone, s.feedback };
            if (query.Count() > 0) return query;
            return null;
        }

        public IReadOnlyCollection<Supplier_data> GetAllSupplierData()
        {
            var Data = context.Set<Supplier_data>().ToList();
            return Data.AsReadOnly();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable GetSupplierByPartsAsync(int id)
        {
            List<Supplier_data> lsupplier = context.Suppliers.ToList();
            List<Supplier_Part> lsupplier_part = context.Supplier_Parts.ToList();
            var query = from s in lsupplier
                        join sp in lsupplier_part on s.supplier_id equals sp.sid
                        where sp.partid == id
                        select new { s.supplier_id, s.name, s.location, s.feedback, sp.partid, sp.partname, sp.quantity, sp.timeperiod };
            if (query.Count() > 0) return query;
            return null;
        }

        public TEntity Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateFeedback(Supplier_data request)
        {
            if(request.supplier_id == 0 && request.feedback == 0) 
                return false;
            var dbSup = await context.Suppliers.FindAsync(request.supplier_id);


            dbSup.feedback = request.feedback;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateSupplier(SPView request)
        {
            if (request.supplier_id == null && request.partid == null)
            {
                return false;
            }
            var supplierData = await context.Suppliers.FirstOrDefaultAsync(t => t.supplier_id == request.supplier_id);

            var partData = await context.Supplier_Parts.FirstOrDefaultAsync(t => t.partid == request.partid && t.sid == request.supplier_id);
            if (supplierData == null && partData == null)
            {
                return false;
            }
            supplierData.feedback = request.feedback;
            supplierData.name = request.name;
            supplierData.phone = request.phone;
            supplierData.email = request.email;
            supplierData.location = request.location;
            context.Suppliers.Update(supplierData);
            await context.SaveChangesAsync();
            partData.partname = request.partname;
            partData.timeperiod = request.timeperiod;
            partData.quantity = request.quantity;

            context.Supplier_Parts.Update(partData);
            await context.SaveChangesAsync();
           
            return true;
        }
    }
}
