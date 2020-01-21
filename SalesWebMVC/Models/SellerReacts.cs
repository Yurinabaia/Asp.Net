using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class SellerReacts
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public Status status { get; set; }
        public Seller sellers { get; set; }

        public SellerReacts()
        {
        }

        public SellerReacts(int id, DateTime data, double amount, Status status, Seller sellers)
        {
            Id = id;
            Data = data;
            Amount = amount;
            this.status = status;
            this.sellers = sellers;
        }
    }
}
