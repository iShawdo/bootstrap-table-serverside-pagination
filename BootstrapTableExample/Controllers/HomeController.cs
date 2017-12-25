using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTableExample.Controllers
{
    public class HomeController : Controller
    {
        public List<Row> data = new List<Row>();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(string order, int offset, int limit)
        {
            if (data.Count == 0)
            {
                for (int i = 1; i <= 100; i++)
                {
                    Row item = new Row()
                    {
                        Id = i,
                        Name = "Item " + i,
                        Price = "$" + i
                    };
                    data.Add(item);
                }
            }

            JsonResult response = new JsonResult()
            {
                Data = new { total = data.Count, rows = data.Select(x => x).Skip(offset).Take(limit).ToList() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return response;
        }

        public class Row
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
        }

    }
}