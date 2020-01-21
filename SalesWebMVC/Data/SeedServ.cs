using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedServ
    {
        private SalesWebMVCContext _context;

        public SeedServ(SalesWebMVCContext context)
        {
            _context = context;
        }
        public void seed() 
        {
            if(_context.Departamants.Any()||_context.Seller.Any() || _context.SellerRecord.Any()) 
                //Com isso aqui é para saber se tem alguma informação no banco de dados
            {
                return;
            }
            Departamants d1 = new Departamants(1, "Eletronics");
            Departamants d2 = new Departamants(2, "Fashion");
            Departamants d3 = new Departamants(3, "Books");
            Departamants d4 = new Departamants(4, "Computer");

            Seller ved1 = new Seller(1, "Bob brow", "bob@casacaiur.tk", 100.0, new DateTime(1998, 01, 20), d1);
            Seller ved2 = new Seller(2, "kaka", "kaka@casacaiur.tk", 200.0, new DateTime(1998, 09, 12), d2);
            Seller ved3 = new Seller(3, "Cristiano Ronaldo", "Cr7@casacaiur.tk", 900.0, new DateTime(1991, 07, 14), d3);
            Seller ved4 = new Seller(4, "Neymar", "neymar@casacaiur.tk", 300.0, new DateTime(1994, 06, 23), d4);

            SellerReacts r1 = new SellerReacts(1, new DateTime(2019, 09, 25), 1100, Status.Bilder, ved1);
            SellerReacts r2 = new SellerReacts(2, new DateTime(2019, 08, 22), 2100, Status.Bilder, ved2);
            SellerReacts r3 = new SellerReacts(3, new DateTime(2019, 07, 21), 1200, Status.Bilder, ved3);
            SellerReacts r4 = new SellerReacts(4, new DateTime(2019, 09, 21), 1500, Status.Bilder, ved2);
            SellerReacts r5 = new SellerReacts(5, new DateTime(2019, 10, 23), 1900, Status.Bilder, ved3);
            SellerReacts r6 = new SellerReacts(6, new DateTime(2019, 11, 25), 1500, Status.Bilder, ved1);
            SellerReacts r7 = new SellerReacts(7, new DateTime(2019, 12, 29), 1350, Status.Bilder, ved4);
            SellerReacts r8 = new SellerReacts(8, new DateTime(2019, 01, 24), 1220, Status.Bilder, ved4);
            SellerReacts r9 = new SellerReacts(9, new DateTime(2019, 02, 21), 1200, Status.Bilder, ved3);
            SellerReacts r10 = new SellerReacts(10, new DateTime(2019, 03, 30), 1300, Status.Bilder, ved2);
            SellerReacts r11 = new SellerReacts(11, new DateTime(2019, 04, 21), 1500, Status.Bilder, ved1);
            SellerReacts r12 = new SellerReacts(12, new DateTime(2019, 02, 22), 1600, Status.Bilder, ved3);
            SellerReacts r13 = new SellerReacts(13, new DateTime(2019, 06, 25), 1800, Status.Bilder, ved2);
            SellerReacts r14 = new SellerReacts(14, new DateTime(2019, 09, 21), 1900, Status.Bilder, ved4);
            SellerReacts r15 = new SellerReacts(15, new DateTime(2019, 04, 20), 1400, Status.Bilder, ved3);
            SellerReacts r16 = new SellerReacts(16, new DateTime(2019, 06, 22), 1200, Status.Bilder, ved2);
            SellerReacts r17 = new SellerReacts(17, new DateTime(2019, 03, 23), 1100, Status.Bilder, ved3);
            SellerReacts r18 = new SellerReacts(18, new DateTime(2019, 08, 24), 1300, Status.Bilder, ved4);
            SellerReacts r19 = new SellerReacts(19, new DateTime(2019, 02, 26), 1600, Status.Bilder, ved2);
            SellerReacts r20 = new SellerReacts(20, new DateTime(2019, 03, 28), 1800, Status.Bilder, ved3);
            SellerReacts r21 = new SellerReacts(21, new DateTime(2019, 05, 29), 1900, Status.Bilder, ved1);
            SellerReacts r22 = new SellerReacts(22, new DateTime(2019, 04, 30), 1200, Status.Bilder, ved3);
            SellerReacts r23 = new SellerReacts(23, new DateTime(2019, 06, 15), 1600, Status.Bilder, ved4);
            SellerReacts r24 = new SellerReacts(24, new DateTime(2019, 04, 12), 5100, Status.Bilder, ved2);
            SellerReacts r25 = new SellerReacts(25, new DateTime(2019, 08, 13), 6100, Status.Bilder, ved1);
            SellerReacts r26 = new SellerReacts(26, new DateTime(2019, 10, 22), 9100, Status.Bilder, ved1);
            SellerReacts r27 = new SellerReacts(27, new DateTime(2019, 11, 23), 15000, Status.Bilder, ved1);
            SellerReacts r28 = new SellerReacts(28, new DateTime(2019, 12, 24), 11000, Status.Bilder, ved2);
            SellerReacts r29 = new SellerReacts(29, new DateTime(2019, 11, 25), 16000, Status.Bilder, ved4);
            SellerReacts r30 = new SellerReacts(30, new DateTime(2019, 10, 26), 11000, Status.Bilder, ved4);
            _context.Departamants.AddRange(d1, d2, d3, d4);//Este metodo pertimir que voce selecione varios objetos de uma vez
            _context.Seller.AddRange(ved1, ved2, ved3, ved4);
            _context.SellerRecord.AddRange(r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12,r13,r14,r15,r16,
                r17,r18,r19,r20,r21,r22,r23,r24,r25,r26,r27,r28,r29,r30);
            _context.SaveChanges();//AQUI SALVAR NO BD
        }
    }
}
