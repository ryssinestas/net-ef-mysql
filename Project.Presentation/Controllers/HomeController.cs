using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Data;
using Project.Data.Repositories;
using Project.Domain.Entities;

namespace Project.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork<Product> UowProduct { get; set; }

        public HomeController()
        {
            this.UowProduct = new ProductRepository();
        }

        public ActionResult Index()
        {
            List<Product> list = UowProduct.GetAll().ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}