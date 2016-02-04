using _02.WebCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<string> bitList = new List<string>()
        {
           "bit - b",
           "Byte - B",
           "Kilobit - Kb",
           "Kilobyte - KB",
           "Megabit - Mb",
           "Megabyte - MB",
           "Gigabit - Gb",
           "Gigabyte - GB",
           "Terabit - Tb",
           "Terabyte - TB",
           "Petabit - Pb",
           "Petabyte - PB",
           "Exabit - Eb",
           "Exabyte - EB",
           "Zettabit - Zb",
           "Zettabyte - ZB",
           "Yottabit - Yb",
           "Yottabyte - YB"
        };


        public HomeController()
        {
            this.Types = new List<SelectListItem>();
            this.Kilos = new List<SelectListItem>();

            for (int i = 0; i < bitList.Count; i++)
            {
                this.Types.Add(new SelectListItem() { Text = bitList[i], Value = i.ToString() });
            }

            this.Kilos.Add(new SelectListItem() { Text = "1024", Value = "1024" });
            this.Kilos.Add(new SelectListItem() { Text = "1000", Value = "1000" });
        }

        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> Kilos { get; set; }


        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Kilo = this.Kilos;
            ViewBag.Types = this.Types;
            ViewBag.Storage = "Storage(Kilo = 1024 bits)";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Quantity, string Types, string Kilo)
        {
            int index = int.Parse(Types);
            int currentMultiply;

            if (Kilo == "1000")
            {
                ViewBag.Storage = "Bandwidth (Kilo = 1000 bits)";
                currentMultiply = 1000;
            }
            else
            {
                ViewBag.Storage = "Storage(Kilo = 1024 bits)";
                currentMultiply = 1024;
            }

            ViewBag.Kilo = this.Kilos;
            ViewBag.Types = this.Types;
            List<TableDataModel> results = new List<TableDataModel>(this.Types.Count);
            for (int i = 0; i < bitList.Count; i++)
            {
                results.Add(new TableDataModel()
                {
                    Name = bitList[i].Substring(0, bitList[i].IndexOf("-") - 1)
                });
            }

            double quantity = Convert.ToDouble(Quantity);
            double tempQuantity = quantity;

            results[index].Size = quantity;

            for (int i = index; ;)
            {
                i -= 2;

                if (i < 0)
                {
                    break;
                }

                tempQuantity *= currentMultiply;

                results[i].Size = tempQuantity;

                if (results[i].Name.IndexOf("bit") >= 0)
                {
                    results[i + 1].Size = results[i].Size / 8;
                }
                else
                {
                    results[i + 1].Size = results[i + 2].Size * 8;
                }
            }

            if (results[0].Size == 0)
            {
                results[0].Size = results[1].Size * 8;
            }

            tempQuantity = quantity;


            for (int i = index; ;)
            {
                i += 2;

                if (i >= results.Count)
                {
                    break;
                }

                tempQuantity /= currentMultiply;

                results[i].Size = tempQuantity;

                if (results[i].Name.IndexOf("bit") >= 0)
                {
                    results[i - 1].Size = results[i - 2].Size / 8;
                }
                else
                {
                    results[i - 1].Size = results[i].Size * 8;
                }
            }

            if (results[results.Count - 1].Size == 0)
            {
                results[results.Count - 1].Size = results[results.Count - 2].Size / 8;
            }


            ViewBag.Result = results;
            return View();
        }
    }
}