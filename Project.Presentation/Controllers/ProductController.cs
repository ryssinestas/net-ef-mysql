using Project.Data;
using Project.Data.Repositories;
using Project.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork<Product> UowProduct { get; set; }
        private IUnitOfWork<Barcode> UowBarcode { get; set; }

        public ProductController()
        {
            this.UowProduct = new ProductRepository();
            this.UowBarcode = new BarcodeRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Product> list = UowProduct.GetAll().ToList();

            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = UowProduct.GetById(id);
            product.BarCodeList = UowBarcode.GetAll().Where(x => x.ProductId == id).ToList();

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                UowProduct.Save(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = UowProduct.GetById(id);

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = UowProduct.GetById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product product = UowProduct.GetById(id);
                UowProduct.Delete(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
