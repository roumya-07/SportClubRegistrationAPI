using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsClubRegistration.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SportClubRegistration.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SportsClubRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        Uri baseAdd = new Uri("http://localhost:14655/api");

        HttpClient client;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }

        public async Task<IActionResult> ViewPage()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<JsonResult> GetClub()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ClubAPI/").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        public async Task<JsonResult> GetSports(int club_id)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SportsAPI/" + club_id).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(SportsClubEntity CE)
        {
            string[] files = CE.image_path.Split('\\');
            CE.image_path = "File/" + files[files.Length - 1];
            string data = JsonConvert.SerializeObject(CE);
            HttpResponseMessage response;
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            response = client.PutAsync(client.BaseAddress + "/SportsClubAPI/" + CE.registration_id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "File");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }
        public async Task<JsonResult> Edit(int registration_id)
        {
            SportsClubEntity schlst = new SportsClubEntity();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SportsClubAPI/" + registration_id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                schlst = JsonConvert.DeserializeObject<SportsClubEntity>(data);
            }
            var jsonres = JsonConvert.SerializeObject(schlst);
            return Json(jsonres);
        }

        public async Task<JsonResult> ViewAll()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SportsClubAPI/").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }
    }
}
