using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SimpleCQRS.Command;
using SimpleCQRS.Query.Models;
using SimpleCQRS.Command.Models;
using SimpleCQRS.Query;
using SimpleCQRS.Query.DataAccess;
using SimpleCQRS.Command.DataAccess;


namespace CQRSGui.Controllers
{      
    public class HomeController : Controller
    {
        private ICommandSender _bus;
        private ReadModel _readmodel; 
        
        public HomeController(ICommandSender bus, InventoryQueryContext queryContext)
        {
            _bus = bus;
            _readmodel = new ReadModel(queryContext);
        }

        public IActionResult Index()
        {
            ViewData.Model = _readmodel.GetInventoryItems();

            return View();
        }

        public ActionResult Details(Guid id)
        {
            var model = _readmodel.GetInventoryItemDetails(id);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            _bus.Send(new CreateInventoryItem(Guid.NewGuid(), name));

            return RedirectToAction("Index");
        }

        public ActionResult ChangeName(Guid id)
        {
            var model = _readmodel.GetInventoryItemDetails(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeName(Guid id, string name, int version)
        {
            var command = new RenameInventoryItem(id, name, version);
            _bus.Send(command);

            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(Guid id)
        {
            var model = _readmodel.GetInventoryItemDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Deactivate(Guid id, int version)
        {
            _bus.Send(new DeactivateInventoryItem(id, version));
            return RedirectToAction("Index");
        }

        public ActionResult CheckIn(Guid id)
        {
            var model = _readmodel.GetInventoryItemDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckIn(Guid id, int currentCount, int version)
        {
            _bus.Send(new CheckInItemsToInventory(id, currentCount, version));
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Guid id)
        {
            var model = _readmodel.GetInventoryItemDetails(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Remove(Guid id, int currentCount, int version)
        {
            _bus.Send(new RemoveItemsFromInventory(id, currentCount, version));
            return RedirectToAction("Index");
        }
    }
}
