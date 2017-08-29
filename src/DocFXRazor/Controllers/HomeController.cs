using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocFXRazor.Models;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DocFXRazor.Controllers
{
    [Route("")]
    public class HomeController
        : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            Log = logger;
        }

        ILogger Log { get; }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet("site/{*relativePath}")]
        public IActionResult SitePage(string relativePath)
        {
            string jsonFile = Path.Combine("..", "..", "_site",
                Path.ChangeExtension(
                    relativePath.Replace("/", "\\"),
                    ".json"
                )
            );

            Log.LogInformation("'{RelativePath}' -> '{JsonFile}' (Exists: {Exists})",
                relativePath, jsonFile, System.IO.File.Exists(jsonFile)
            );

            JObject model;
            using (TextReader reader = System.IO.File.OpenText(jsonFile))
            using (JsonReader jsonReader = new JsonTextReader(reader))
            {
                model = JObject.Load(jsonReader);
            }

            return View("Conceptual", model);
        }
    }
}
