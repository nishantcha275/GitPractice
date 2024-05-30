using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using StudentWebConsumeAPI.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace StudentWebConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7037/api");
        private readonly HttpClient _httpClient;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StudentViewModel> studentslist = new List<StudentViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Student/StudentList").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentslist = JsonConvert.DeserializeObject<List<StudentViewModel>>(data);
            }
            return View(studentslist);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string url = $"{_httpClient.BaseAddress}/Student/StudentByID/{id}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    StudentViewModel student = JsonConvert.DeserializeObject<StudentViewModel>(responseData);

                    return View(student);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Student/EditStudent/{id}", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string url = $"{_httpClient.BaseAddress}/Student/StudentByID/{id}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    StudentViewModel student = JsonConvert.DeserializeObject<StudentViewModel>(responseData);

                    return View(student);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Student/EditStudent", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string url = $"{_httpClient.BaseAddress}/Student/StudentByID/{id}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    StudentViewModel student = JsonConvert.DeserializeObject<StudentViewModel>(responseData);

                    return View(student);
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
              
                HttpResponseMessage response = _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/Student/DeleteStudent/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    return View("Error", errorMessage);
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(StudentViewModel student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Student/Login/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    return RedirectToAction("Login");
                    ViewBag.Student = "Data not matched";
                    //string errorMessage = response.Content.ReadAsStringAsync().Result;
                    //return View("Error", errorMessage);

                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
