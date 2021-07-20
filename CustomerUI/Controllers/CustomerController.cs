using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerUI.Models;
using CustomerUI.Services.Intefaces;

namespace CustomerUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerService.GetCustomers().ToList());
        }
        public IActionResult Create()
        {
            //_customerService.AddCustomer(customer);

            return View("AddCustomer", new Customer());

        }
        public IActionResult Submit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customer);
                return RedirectToAction("Index");

            }
            else
            {
                return View("AddCustomer", customer);
            }

        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            Customer obj = _customerService.GetCustomerById(id);
            return View("ViewCustomer", obj);
        }

        // GET: CustomerController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5

        public ActionResult Edit(int id)
        {
            Customer obj = _customerService.GetCustomerById(id);
                return View("EditCustomer", obj);
        }

        //POST: CustomerController/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerService.UpdateCustomer(obj);
                    return RedirectToAction(nameof(Index));
                }
                else

                    return View("EditCustomer", obj);
            }
            catch
            {
                return View("EditCustomer", obj);
            }

        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
            }
            catch
            {

            }
            return View("Index", _customerService.GetCustomers().ToList());
        }

        // POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
