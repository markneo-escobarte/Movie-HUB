
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_HUB.Models;
using Newtonsoft.Json;

namespace Movie_HUB.Controllers
{
    public class YoutubeController : Controller
    {
        // GET: YoutubeController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "http://localhost:5295/api/Youtube?maxResult=50";
            List<VideoDetails> videos = new List<VideoDetails>();

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    videos = JsonConvert.DeserializeObject<List<VideoDetails>>(result);
                }
            }

            return View(videos);
        }

        // GET: YoutubeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: YoutubeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YoutubeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: YoutubeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: YoutubeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: YoutubeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: YoutubeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
