using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeFitness.Models.Entities;
using PrimeFitness.Models.Funtions;

namespace PrimeFitness.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = (Cart)Session["CartSession"];

            var list = new List<CartItem>();

            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult UpdateCart(string id, FormCollection fr)
        {

            var product = new SanPhamF().FindEntity(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                int NewQuantity = int.Parse(fr["txtQuantity"].ToString());
                cart.UpdateItem(product, NewQuantity);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");

        }

        // GET: /Cart/Details/5
        public ActionResult RemoveLine(string Id)
        {

            var product = new SanPhamF().FindEntity(Id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.RemoveLine(product);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            return RedirectToAction("Index");
        }


        public ActionResult AddItem(string id, string returnURL)
        {

            var product = new SanPhamF().FindEntity(id);

            var cart = (Cart)Session["CartSession"];

            if (cart != null)
            {
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                cart = new Cart();
                cart.AddItem(product, 1);
                //Gán vào session
                Session["CartSession"] = cart;
            }

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index");

            }

            return Redirect(returnURL);

        }
        //
        //
        // GET: /Cart/Details/5

        //[HttpGet]
        //public ActionResult Payment()
        //{
        //    var cart = (Cart)Session["CartSession"];
        //    var list = new List<CartItem>();
        //    if (cart != null)
        //    {
        //        list = cart.Lines.ToList();
        //    }
        //    return View(list);
        //}


        [HttpPost]
        public ActionResult Index(string name, string phone)
        {
            var order = new HoaDon();
            order.NgayGhiHD = DateTime.Now;
            order.SoDienThoaiKH = phone;
            order.TenKH = name;

            try
            {
                var id = new HOADONF().Insert(order);

                var cart = (Cart)Session["CartSession"];

                var detailDao = new CHITIETHDF();

                foreach (var item in cart.Lines)
                {
                    var orderDetail = new CTHD();
                    orderDetail.MaGT = item.Goitap.MaGT.ToString().Trim();
                    orderDetail.MaHD = id;
                    orderDetail.DonGia = item.Goitap.GiaGT;
                    orderDetail.SoLuong = item.Quantity;

                    detailDao.Insert(orderDetail);

                }

            }
            catch (Exception ex)
            {
                //ghi log

                throw;
            }
            Session["CartSession"] = null;
            return RedirectToAction("Index", "Package");
        }



        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cart/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cart/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cart/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Edit/5

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

        //
        // GET: /Cart/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cart/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string customerName { get; set; }
    }


}
