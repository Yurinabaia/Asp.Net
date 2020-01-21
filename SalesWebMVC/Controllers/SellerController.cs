using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Excpecitons;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SalesWebMVC.Data
{
    public class SellerController : Controller
    {
        private readonly SellerServices _sllerservice;
        //O readonly faz com que a dependencia não possa ser alterado este elemento   
        private readonly DepartamantsServices _departamentsServs;

        public SellerController(SellerServices seller, DepartamantsServices departamantsServices) 
        {
            _sllerservice = seller;
            _departamentsServs = departamantsServices;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _sllerservice.FindAllAsync();//Aqui estamos buscando a lista do SellerServices
            return View(list);//Aqui estamos implementado a lista na pagina seller
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller) //Este metodo criar ação o IActionResult
        {
            if (!ModelState.IsValid)
            {
                var deparataments = await _departamentsServs.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departamants = deparataments };
                return View(viewModel);
            } 
           await _sllerservice.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }    
        public async Task<IActionResult> Create() //Este metodo criar ação o IActionResult
        {
            var departamantss = await _departamentsServs.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departamants = departamantss};
            return View(viewModel);
        }
        public async Task<IActionResult> Delete(int ? id) 
        {
            if(id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id not null" });
            }
            var obj = await _sllerservice.FillByIdAsync(id.Value);
            if(obj == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id not foud" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sllerservice.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e) 
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not foud" });
            }
            var obj = await _sllerservice.FillByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not foud" });
            }
            return View(obj);
        }
        public async Task <IActionResult> Edit(int ? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not foud" });
            }
            var obj = await _sllerservice.FillByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not foud" });
            }
            List<Departamants> depa = await _departamentsServs.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departamants = depa };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller sel) 
        {
            if (!ModelState.IsValid)
            {
                var deparataments = await _departamentsServs.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = sel, Departamants = deparataments };
                return View(viewModel);
            }
            if (id!= sel.Id) 
            {
                return BadRequest();
            }
            try
            {
               await _sllerservice.UpDateAsync(sel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }
        }
        public IActionResult Error(string mensager) 
        {
            var ViewmModel = new ErrorViewModel
            {
                Mensager = mensager,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewmModel);
        }
    }
}