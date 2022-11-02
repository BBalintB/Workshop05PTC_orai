using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Workshop05PTC_orai.Data;
using Workshop05PTC_orai.Models;

namespace Workshop05PTC_orai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        BlobServiceClient serviceClient;
        BlobContainerClient containerClient;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;
            serviceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=oenikka;AccountKey=SPAYDIlI2xaxhp4jhdQ6PIWaQ5UvNSvuUzLyP3E4TanfqPiuh2YO0ixQ9Re06TP0N20cf1cMbiGI+AStil1KqA==;EndpointSuffix=core.windows.net");
            containerClient = serviceClient.GetBlobContainerClient("photos");
        }

        public IActionResult Index()
        {
            return View(_db.Cars);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Car c, [FromForm] IFormFile photoUpload)
        {
            ;
            c.UserId = _userManager.GetUserId(this.User);
            
            BlobClient blobClient = containerClient.GetBlobClient(c.UserId + "_" + c.Type.Replace(" ", "").ToLower());
            using (var uploadFileStream = photoUpload.OpenReadStream())
            {
                await blobClient.UploadAsync(uploadFileStream, true);
            }
            blobClient.SetAccessTier(AccessTier.Cool);
            c.PhotoUrl = blobClient.Uri.AbsoluteUri;

            _db.Cars.Add(c);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
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
