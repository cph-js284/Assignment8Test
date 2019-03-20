using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mariospizzamongo
{
    public class OrderController : Controller
    {
        IDocumentContext _ctx;
        List<Item> items;
        public OrderController(IDocumentContext ctx)
        {
            _ctx = ctx;

            //This list of items should obviously not be hardcoded, but rather come from API/Database
            items = new List<Item>(){
                new Item(){_HId=1, Text="Pizza type 1", Price=19.99},
                new Item(){_HId=2, Text="Pizza type 2", Price=15.99},
                new Item(){_HId=3, Text="Pizza type 3", Price=21.99},
                new Item(){_HId=4, Text="Pizza type 4", Price=24.99},
                new Item(){_HId=5, Text="Pizza type 5", Price=29.99}
            };

        }

        public IActionResult Index(){
            return View();
        }

        public IActionResult PlaceOrder(){
            ViewBag.itemlist = items;
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(FormOrder formData){
            if(!ModelState.IsValid){
                ViewBag.itemlist = items;
                return View(formData);
            }
                

            var tmpArr = formData.OrderCSV.Split(",");
            //remove last entry 
            tmpArr=tmpArr.Take(tmpArr.Count()-1).ToArray();
            List<Item> itemsOrderedList = new List<Item>();

            foreach (var itemIndex in tmpArr)
            {
                itemsOrderedList.Add(items[(int.Parse(itemIndex))-1]);
            }

            Order order = new Order();
            order.oItems = itemsOrderedList;
            order.CustomerName = formData.CustomerName;
            order.TimeStamp = DateTime.Now;
            order._Hid=1;

            _ctx.AddOrder(order);

            return RedirectToAction("Index");
        }

        public IActionResult ShowAllOrders(){
            var models = _ctx.GetAllOrders();
            return View(models);
        }

        public IActionResult RemoveOrder(string Id){
            _ctx.DeleteOrder(Id);
            return RedirectToAction("ShowAllOrders");
        }

    }
}