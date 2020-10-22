using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace MVC.Controllers
{
    public class dashboardPageController : Controller
    {
        // GET: dashboardPageController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Books> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51697/api/BookList/");
                //HTTP GEToks_info/
                var outputTask = await client.GetAsync("FetchBooks");



                if (outputTask.IsSuccessStatusCode)
                {
                    var readTask = outputTask.Content.ReadAsAsync<IList<Books>>();


                    books = readTask.Result;
                }

            }
            return View(books);
        }

        // GET: dashboardPageController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Books book = new Books();


            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:51697/api/BookList/");
                //HTTP GET
                HttpResponseMessage outputTask = await client.GetAsync("FetchBookById?id=" + id.ToString());

                if (outputTask.IsSuccessStatusCode)
                {
                    var readTask = outputTask.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Books>(readTask);
                }

            }
            return View(book);
        }

        // GET: dashboardPageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dashboardPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51697/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync("api/BookList/AddBooks", book);

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(book);
        }

        // GET: dashboardPageController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Books book = new Books();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:51697/api/BookList/");
                //HTTP GET
                HttpResponseMessage outputTask = await client.GetAsync("FetchBookById?id=" + id.ToString());

                if (outputTask.IsSuccessStatusCode)
                {
                    var readTask = outputTask.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<Books>(readTask);
                }
            }

            return View(book);
        }

        // POST: dashboardPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Books book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51697/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync("api/BookList/UpdateBooks?id=" + book.bookId, book);
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        // GET: dashboardPageController/Delete/5
        public IActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51697/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/BookList/RemoveBooks?id=" + id);


                var result = deleteTask.Result;


                return RedirectToAction("Index");

            }

        }
    }
}
    
