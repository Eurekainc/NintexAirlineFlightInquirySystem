using NintexAirlineFlightInquirySystem.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NintexAirlineFlightInquirySystem.Controllers
{
    public class AirlineInquiryController : Controller
    {
        // GET: AirlineInquiry
        public async Task<ActionResult> Index()
        {
            AirlineInquiryProxeyRequest request = new AirlineInquiryProxeyRequest();
            AirlineInquiryProxeyResponse response = await new AirlineInquiryCallInvoker().Call(request);
            if (response.ResponseCode == (int)HttpStatusCode.OK)
            {

            }

            return View();
        }

        // GET: AirlineInquiry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AirlineInquiry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirlineInquiry/Create
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

        // GET: AirlineInquiry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirlineInquiry/Edit/5
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

        // GET: AirlineInquiry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirlineInquiry/Delete/5
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
    }
}
