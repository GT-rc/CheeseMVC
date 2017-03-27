using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Models.Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(string[] cheeseIds)
        {
            foreach (string cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }

        [HttpGet]
        [Route("/Cheese/Edit/{cheeseId}")]
        public IActionResult Edit(string cheeseId)
        {
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel();
            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        [Route("/Cheese/Edit/{cheeseId}")]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            // How do you pull the object from the ViewModel?
            Cheese editedCheese = Cheese.Find(addEditCheeseViewModel.CheeseId);
            CheeseData.Save(editedCheese);
            
            return Redirect("/");
        }
    }
}
