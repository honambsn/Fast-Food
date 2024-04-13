using FastFood.Models;
using FastFood.Repository;
using FastFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/Categories")]
    public class CategoriesController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listFromDb = _context.Categories.ToList().Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            return View();
        }


        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            CategoryViewModel category = new CategoryViewModel();
            return View(category);
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create(CategoryViewModel vm)
        {
            Category model = new Category();
            model.Title = vm.Title;
            _context.Categories.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            var viewModel = _context.Categories.Where(x => x.Id == id).Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).FirstOrDefault();
            
            return View(viewModel);
        }


        [HttpPost]
        [Route("edit")]
        public IActionResult Edit(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _context.Categories.FirstOrDefault(x=>x.Id== vm.Id);
                if(categoryFromDb != null)
                {
                    categoryFromDb.Title = vm.Title;
                    _context.Categories.Update(categoryFromDb);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            var category= _context.Categories.Where(x => x.Id == id).FirstOrDefault();
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
