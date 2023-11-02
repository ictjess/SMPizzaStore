using SMPizzaStore.DAL;
using SMPizzaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace SMPizzaStore.Controllers
{
    public class PizzaController : Controller
    {
        ErrorModel errorModel = new ErrorModel();

        // GET: Pizza
        public ActionResult Index()
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Load Pizzas";
            try
            {
                List<PizzaModel> pizzas = new List<PizzaModel>();
                PizzaDAL dal = new PizzaDAL();

                pizzas = dal.LoadRecords();

                return View("View", pizzas);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
           
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            errorModel.Page = "Manage Toppings";
            errorModel.Activity = "Pizza Details";
            try
            {
                PizzaModel pizza = new PizzaModel();
                PizzaDAL dal = new PizzaDAL();

                pizza = dal.LoadRecordsById(id);

                return View("Details", pizza);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Save(PizzaModel pizza)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Create Pizzas";
            try
            {
                if (pizza.Name == null)
                {
                    errorModel.Prompt = "Name must not be empty.";
                    return RedirectToAction("Error", errorModel);
                }
                // TODO: Add insert logic here
                PizzaDAL dal = new PizzaDAL();
                dal.Create(pizza);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Edit Pizzas";
            try
            {
                PizzaModel pizza = new PizzaModel();
                PizzaDAL dal = new PizzaDAL();
                pizza = dal.LoadRecordsById(id);
                return View("Edit", pizza);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }

        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Update(int id, PizzaModel pizza)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Update Pizzas";
            try
            {
                if (pizza.Name == null)
                {
                    errorModel.Prompt = "Name must not be empty.";
                    return RedirectToAction("Error", errorModel);
                }
                // TODO: Add update logic here
                PizzaDAL dal = new PizzaDAL();
                dal.Update(id, pizza);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Delete Pizzas";
            try
            {
                PizzaModel pizza = new PizzaModel();
                PizzaDAL dal = new PizzaDAL();
                pizza = dal.LoadRecordsById(id);
                return View("Delete", pizza);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
            
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Remove(int id, PizzaModel pizza)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Remove Toppings from Pizza";
            try
            {
                // TODO: Add delete logic here
                PizzaDAL dal = new PizzaDAL();
                dal.Remove(id, pizza);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }

        public ActionResult Manage(int id, string name)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Manage Pizzass";
            try
            {
                ToppingDAL dal = new ToppingDAL();

                #region -- LOAD AVAILABLE TOPPINGS NOT YET ADDED TO SELECTED PIZZA --
                List<ToppingModel> availableToppings = new List<ToppingModel>();
                availableToppings = dal.LoadAvailableToppings(id);
                #endregion -- LOAD AVAILABLE TOPPINGS NOT YET ADDED TO SELECTED PIZZA --

                #region -- LOAD ADDED TOPPINGS FROM SELECTED PIZZA --
                List<ToppingModel> addedToppings = new List<ToppingModel>();
                addedToppings = dal.LoadAddedToppings(id);
                #endregion -- LOAD ADDED TOPPINGS FROM SELECTED PIZZA --

                var model = new Tuple<List<ToppingModel>, List<ToppingModel>>(availableToppings, addedToppings);

                TempData["PizzaId"] = id.ToString();
                TempData["PizzaName"] = name;
                ViewBag.PizzaName = name;
                return View(model);
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
            
        }

        public ActionResult AddToppingToPizza(int id, ToppingModel topping)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Add Topping to Pizza";
            try
            {
                string pizzaId = TempData["PizzaId"] as string;
                string pizzaName = TempData["PizzaName"] as string;
                ViewBag.PizzaName = pizzaName;
                //int pizzaId =  Convert.ToInt32(Session["PizzaId"]);
                //string pizzaName = Session["PizzaName"] as string;

                // TODO: Add delete logic here
                ToppingDAL dal = new ToppingDAL();
                dal.AddToppingToPizza(Convert.ToInt32(pizzaId), topping);

                #region --REFRESH LIST --
                List<ToppingModel> availableToppings = new List<ToppingModel>();

                availableToppings = dal.LoadAvailableToppings(Convert.ToInt32(pizzaId));


                List<ToppingModel> addedToppings = new List<ToppingModel>();

                addedToppings = dal.LoadAddedToppings(Convert.ToInt32(pizzaId));

                var model = new Tuple<List<ToppingModel>, List<ToppingModel>>(availableToppings, addedToppings);

                #endregion --REFRESH LIST --

                return RedirectToAction("Manage", new { id = pizzaId, name = pizzaName });
            }
            catch (Exception ex)
            {
                errorModel.Prompt = ex.Message;
                return RedirectToAction("Error", errorModel);
            }
        }


        public ActionResult RemoveToppingFromPizza(int id, ToppingModel topping)
        {
            errorModel.Page = "Manage Pizzas";
            errorModel.Activity = "Remove Topping from Pizza";
            try
            {
                string pizzaId = TempData["PizzaId"] as string;
                string pizzaName = TempData["PizzaName"] as string;
                ViewBag.PizzaName = pizzaName;

                // TODO: Add delete logic here
                ToppingDAL dal = new ToppingDAL();
                dal.RemoveToppingFromPizza(Convert.ToInt32(pizzaId), topping);

                #region --REFRESH LIST --
                List<ToppingModel> availableToppings = new List<ToppingModel>();

                availableToppings = dal.LoadAvailableToppings(id);


                List<ToppingModel> addedToppings = new List<ToppingModel>();

                addedToppings = dal.LoadAddedToppings(Convert.ToInt32(pizzaId));

                var model = new Tuple<List<ToppingModel>, List<ToppingModel>>(availableToppings, addedToppings);

                #endregion --REFRESH LIST --

                return RedirectToAction("Manage", new { id = pizzaId, name = pizzaName });
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
