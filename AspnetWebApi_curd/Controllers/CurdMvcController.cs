using AspnetWebApi_curd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspnetWebApi_curd.Controllers
{
    public class CurdMvcController : Controller
    {
        // GET: CurdMvc

        HttpClient clinet = new HttpClient();
        public ActionResult Index()
        {
            List<employee> list = new List<employee>();
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.GetAsync("CurdApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<employee>>();
                display.Wait();
                list = display.Result;
            }

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee emp)
        {
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.PostAsJsonAsync("CurdApi", emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");

        }
        public ActionResult Details(int id)
        {
            employee e = null;
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.GetAsync("CurdApi?id="+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        public ActionResult Edit(int id)
        {
            employee e = null;
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.GetAsync("CurdApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.PutAsJsonAsync("CurdApi", emp);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            employee e = null;
            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.GetAsync("CurdApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<employee>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeletedConformed(int id)
        {

            clinet.BaseAddress = new Uri("https://localhost:44385/api/CurdApi");
            var response = clinet.DeleteAsync("CurdApi/"+id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}