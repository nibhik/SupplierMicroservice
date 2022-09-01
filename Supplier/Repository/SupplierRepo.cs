using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supplier.Repository;
using SupplierMicroservice;

namespace Supplier.Repository
{
    public class SupplierRepo :ISupplierRepo
    {
        private readonly MyContext _context;
        //private ISupplierRepo _con;
        public SupplierRepo(MyContext myContext)
        {
            _context = myContext;
        }
        public Task<List<Supplier_data>> AddSupplier(Supplier_data sup)
        {
            _context.Suppliers.Add(sup);
            _context.SaveChangesAsync();
            return (_context.Suppliers.ToListAsync());

        }

        public async Task<List<Supplier_Part>> AddPart(Supplier_Part sup)
        {
            _context.Supplier_Parts.Add(sup);
            await _context.SaveChangesAsync();
            return (await _context.Supplier_Parts.ToListAsync());

        }

        public async Task<List<Supplier_data>> UpdateFeedback(Supplier_data request)
        {
            var dbSup = await _context.Suppliers.FindAsync(request.supplier_id);
            //if (dbSup == null)
            //    return BadRequest("Hero not found.");

            dbSup.feedback = request.feedback;
            await _context.SaveChangesAsync();
            return (await _context.Suppliers.ToListAsync());
        }

        public async Task<List<Supplier_data>> UpdateSupplier(Supplier_data request)
        {
            var dbSup = await _context.Suppliers.FindAsync(request.supplier_id);
            if (dbSup != null)
            {
                //return NotFound("Hero not found.");
                dbSup.name = request.name;
                dbSup.location = request.location;
                dbSup.feedback = request.feedback;
                dbSup.email = request.email;
                dbSup.phone = request.phone;
                await _context.SaveChangesAsync();
                return (await _context.Suppliers.ToListAsync());
            }
            return new List<Supplier_data>();

        }

        public Task<List<Supplier_data>> GetSupplierOfPart(int id)
        {
            List<Supplier_data> lsupplier = _context.Suppliers.ToList();
            List<Supplier_Part> lsupplier_part = _context.Supplier_Parts.ToList();
            var query = from s in lsupplier
                        join sp in lsupplier_part on s.supplier_id equals sp.sid
                        where sp.partid == id
                        select new { s.supplier_id, s.name, s.location, sp.quantity, sp.timeperiod };
            return ((Task<List<Supplier_data>>)query);
        }

        Task<List<Supplier_data>> ISupplierRepo.GetSupplierOfPart(int id)
        {
            List<Supplier_data> lsupplier = _context.Suppliers.ToList();
            List<Supplier_Part> lsupplier_part = _context.Supplier_Parts.ToList();
            var query = from s in lsupplier
                        join sp in lsupplier_part on s.supplier_id equals sp.sid
                        where sp.partid == id
                        select new { s.supplier_id, s.name, s.location, sp.quantity, sp.timeperiod };
            return ((Task<List<Supplier_data>>)query);
        }
    }
}
