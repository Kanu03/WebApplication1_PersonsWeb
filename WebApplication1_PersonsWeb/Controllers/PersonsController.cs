using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_PersonsWeb.Utilities;
using PersonsModels;

namespace WebApplication1_PersonsWeb.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetPersons()
        {
            List<Person> s = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Common.Instance.ApiPersonsControllerName);
                //HTTP GET
                var responseTask = client.GetAsync(Common.Instance.ApiPersonsGetPersons);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Person>>();
                    readTask.Wait();

                    s = readTask.Result;
                }
            }

            return Json(s);

        }

        public ActionResult AddPerson(Person Person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Common.Instance.ApiPersonsControllerName);

                var responseTask = client.PostAsJsonAsync(Common.Instance.ApiPersonsAddPerson, Person);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var rs = result.Content.ReadAsAsync<bool>().Result;
                    if (rs == true)
                    {
                        return Content("1");
                    }
                    else
                    {
                        return Content("");
                    }
                }
                return Content("");
            }
        }

        public ActionResult UpdatePerson(Person Person)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Common.Instance.ApiPersonsControllerName);

                var responseTask = client.PutAsJsonAsync(Common.Instance.ApiPersonsUpdatePerson, Person);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var rs = result.Content.ReadAsAsync<bool>().Result;
                    if (rs == true)
                    {
                        return Content("1");
                    }
                    else
                    {
                        return Content("");
                    }
                }
                return Content("");
            }
        }

        public ActionResult DeletePerson(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Common.Instance.ApiPersonsControllerName);

                //var responseTask = client.DeleteAsync(Common.Instance.ApiPersonsDeletePerson + id.ToString());
                var responseTask = client.GetAsync(Common.Instance.ApiPersonsDeletePerson + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var rs = result.Content.ReadAsAsync<bool>().Result;
                    if (rs == true)
                    {
                        return Content("1");
                    }
                    else
                    {
                        return Content("");
                    }
                }
                return Content("");
            }
        }

    }

}
