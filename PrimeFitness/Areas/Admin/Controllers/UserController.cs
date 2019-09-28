using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeFitness.Models.Entities;
using PrimeFitness.Models.Funtions;


namespace PrimeFitness.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/

        public ActionResult Index()
        {
            var model = new NguoiDungF().DSNguoiDung.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NguoiDung model)
        {
            try
            {
                // TODO: Add update logic here
                if (new NguoiDungF().Insert(model))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(String id)
        {
            var model = new NguoiDungF().FindEntity(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NguoiDung model)
        {
            try
            {
                // TODO: Add update logic here
                if (new NguoiDungF().Update(model))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(String id)
        {
            var model = new NguoiDungF().FindEntity(id);
            return View("Edit", model);

        }

        //
        // POST: /Admin/DanhMucAd/Delete/5

        [HttpPost]
        public ActionResult Delete(NguoiDung model)
        {
            try
            {
                if (new NguoiDungF().Delete(model.UserName))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
