using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using PhotoWebApp;

namespace PhotoWebApp.Controllers
{
    [SessionAuthorize]
    public class VideoController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Path.GetTempPath(), file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

                TempData["Message"] = $"Dosya yüklendi: {file.FileName}";
            }
            else
            {
                TempData["Message"] = "Lütfen dosya seçin.";
            }

            return RedirectToAction("Index");
        }
    }
}