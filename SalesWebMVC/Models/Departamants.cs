using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Departamants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departamants()
        {
        }

        public Departamants(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void AddSeller (Seller  sell) 
        {
            Sellers.Add(sell);
        }
        public double TotalDaY(DateTime inition, DateTime end) 
        {

            return Sellers.Sum(seller => seller.TotalSailes(inition, end));
        }
    }
}
