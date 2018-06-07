using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repositiry;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<Products> prodRepo;
        private IRepository<Categories> cateRepo;
        private IRepository<Suppliers> suppRepo;

        public IEnumerable<Categories> Categories
        {
            get
            {
                return cateRepo.GetAll();
            }
        }

        public IEnumerable<Suppliers> Suppliers
        {
            get
            {
                return suppRepo.GetAll();
            }
        }

        public ProductsController()
        {
            prodRepo = new GenericRepository<Products>();
            cateRepo = new GenericRepository<Categories>();
            suppRepo = new GenericRepository<Suppliers>();
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = prodRepo.GetAll();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = prodRepo.Get(a => a.CategoryID == id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                prodRepo.Create(products);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = prodRepo.Get(a => a.CategoryID == id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                prodRepo.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(Suppliers, "SupplierID", "CompanyName", products.SupplierID);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = prodRepo.Get(a => a.CategoryID == id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = prodRepo.Get(a => a.CategoryID == id);
            prodRepo.Delete(products);
            return RedirectToAction("Index");
        }
    }
}
