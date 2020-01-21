using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Excpecitons;

namespace SalesWebMVC.Services
{
    public class SellerServices
    {
        private readonly SalesWebMVCContext _context;
        //O readonly faz com que a dependencia não possa ser alterado este elemento
        public SellerServices(SalesWebMVCContext context) 
        {
            _context = context;
        }
        public async Task<List<Seller>>FindAllAsync()
        {
            return await _context.Seller.ToListAsync();//Serve para busca os vendedores do BD
        } 
        public async Task InsertAsync(Seller obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async  Task<Seller> FillByIdAsync(int id) 
        {
            return await _context.Seller.Include(obj => obj.dep).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id) 
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(Exception e) 
            {
                throw  new IntergrationExpetion("Erro " + e.Message);
            } 
        }
        public async Task UpDateAsync(Seller obj) 
        {
            bool teste = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!teste) 
            {
                throw new NotFoundExecption("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DataExcepction e)  
            {
                throw new DataExcepction(e.Message);
            }
        }
    }
}
