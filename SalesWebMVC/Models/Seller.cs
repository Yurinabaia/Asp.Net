using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} é o campo de nome deve conter no minimo {2} e maximo {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
       [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
       [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
       [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        public Departamants dep { get; set; }
        public int DepartamantsId { get; set; }
        public ICollection<SellerReacts> Sales { get; set; } = new List<SellerReacts>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Departamants dep)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            this.dep = dep;
        }
        public void AddSales(SellerReacts sr ) 
        {
            Sales.Add(sr);
        }
        public void RemovSales(SellerReacts sr) 
        {
            Sales.Remove(sr);
        }
        public double TotalSailes (DateTime Initial, DateTime End) 
        {
            return Sales.Where(sr => sr.Data >= Initial && sr.Data <= End).Sum(sr => sr.Amount);
        }
    }
}
