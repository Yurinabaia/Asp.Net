using SalesWebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordsServices
    {
        private readonly SalesWebMVCContext _context;
        //O readonly faz com que a dependencia não possa ser alterado este elemento
        public SalesRecordsServices(SalesWebMVCContext context)
        {
            _context = context;
        }
        public async Task <List<SellerReacts>> FindByDateAsync(DateTime ? minDate, DateTime ? maxDate) 
        {
            var result = from obj in _context.SellerRecord select obj;
            if(minDate.HasValue) //Se eu informei uma data minima
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if(maxDate.HasValue) 
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.sellers)
                .Include(x => x.sellers.dep)
                .OrderByDescending(x => x.Data)
                .ToListAsync();             
        }
        public async Task<List<IGrouping<Departamants, SellerReacts>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SellerRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.sellers)
                .Include(x => x.sellers.dep)
                .OrderByDescending(x => x.Data)
                .GroupBy(x=> x.sellers.dep)
                .ToListAsync();
        }
    }
}
