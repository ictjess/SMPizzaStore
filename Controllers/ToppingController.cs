using SMPizzaStore.DAL;
using SMPizzaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SMPizzaStore.Controllers
{
    public class ToppingController : Controller
    {
        ErrorModel errorModel = new ErrorModel();
       
        // GET: Topping
        public ActionResult Index()
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Load Toppings";
            //errorModel.Method = "Index";
            try
            {
                List<ToppingModel> toppings = new List<ToppingModel>();
                ToppingDAL dal = new ToppingDAL();

                toppings = dal.LoadRecords();

                return View("View", toppings);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
          
        }

        // GET: Topping/Details/5
        public ActionResult Details(int id)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Topping Details";
            //errorModel.Method = "Details";
            try
            {
                ToppingModel topping = new ToppingModel();
                ToppingDAL dal = new ToppingDAL();

                topping = dal.LoadRecordsById(id);

                return View("Details", topping);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
           
        }

        // GET: Topping/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Topping/Save
        [HttpPost]
        public ActionResult Save(ToppingModel topping)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Create Toppings";
            //errorModel.Method = "Save";
            try
            {
                if (topping.Name == null)
                {
                    errorModel.Prompt = "Name must not be empty.";
                    return RedirectToAction("Error", errorModel);
                }
                // TODO: Add insert logic here
                ToppingDAL dal = new ToppingDAL();
                dal.Create(topping);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        // GET: Topping/Edit/5
        public ActionResult Edit(int id)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Edit Toppings";
            try
            {
                ToppingModel topping = new ToppingModel();
                ToppingDAL dal = new ToppingDAL();
                topping = dal.LoadRecordsById(id);
                return View("Edit", topping);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
           
        }

        // POST: Topping/Edit/5
        [HttpPost]
        public ActionResult Update(int id, ToppingModel topping)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Update Toppings";
            try
            {
                // TODO: Add update logic here
                ToppingDAL dal = new ToppingDAL();
                dal.Update(id, topping);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        // GET: Topping/Delete/5
        public ActionResult Delete(int id)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Delete Toppings";
            try
            {
                ToppingModel topping = new ToppingModel();
                ToppingDAL dal = new ToppingDAL();
                topping = dal.LoadRecordsById(id);
                return View("Delete", topping);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
           
        }

        // POST: Topping/Delete/5
        [HttpPost]
        public ActionResult Remove(int id, ToppingModel topping)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Create Toppings";
            try
            {
                // TODO: Add delete logic here
                ToppingDAL dal = new ToppingDAL();
                dal.Remove(id, topping);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        public ActionResult Error(ErrorModel error)
        {
            return PartialView("_ErrorCustom", error);
        }
    }
}
