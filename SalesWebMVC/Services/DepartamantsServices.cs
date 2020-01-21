using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartamantsServices
    {
        private readonly SalesWebMVCContext _context;
        //O readonly faz com que a dependencia não possa ser alterado este elemento
        public DepartamantsServices(SalesWebMVCContext context)
        {
            _context = context;
        }
        public async Task <List<Departamants>> FindAllAsync()
        {
            return await _context.Departamants.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
