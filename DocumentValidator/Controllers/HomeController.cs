using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.RegularExpressions;
using Tesseract;
using DocumentValidator.Models;

namespace DocumentValidator.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(DocumentViewModel model)
        {
            if (model.File == null || model.File.Length == 0)
            {
                ViewBag.Message = "❌ Please upload a document image.";
                return View();
            }

            var tempPath = Path.GetTempFileName();
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }

            // OCR
            string extractedText = ExtractText(tempPath);
            string detectedDoc = DetectDocumentType(extractedText);

            if (model.ExpectedDocumentType != detectedDoc)
            {
                ViewBag.Message = $"❌ Uploaded document is a {detectedDoc}. Please upload a valid {model.ExpectedDocumentType}.";
                System.IO.File.Delete(tempPath);
                return View();
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedDocs");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, model.File.FileName);
            System.IO.File.Copy(tempPath, filePath, true);
            System.IO.File.Delete(tempPath);

            ViewBag.Message = $"✅ Valid {detectedDoc} uploaded successfully!";
            return View();
        }


        private string ExtractText(string imagePath)
        {
           
            using var engine = new TesseractEngine(@"C:\Program Files\Tesseract-OCR\tessdata", "eng", EngineMode.Default);
            using var img = Pix.LoadFromFile(imagePath);
            using var page = engine.Process(img);
            return page.GetText();
        }

        private string DetectDocumentType(string text)
        {
            
            text = text.ToLower();

            if (Regex.IsMatch(text, @"\b\d{4}\s\d{4}\s\d{4}\b")) return "Aadhaar Card";
            if (Regex.IsMatch(text, @"[a-z]{5}[0-9]{4}[a-z]", RegexOptions.IgnoreCase)) return "PAN Card";
            if (text.Contains("passport") || Regex.IsMatch(text, @"[a-z][0-9]{7}", RegexOptions.IgnoreCase)) return "Passport";
            if (Regex.IsMatch(text, @"[a-z]{3}[0-9]{7}", RegexOptions.IgnoreCase)) return "Voter ID";
            if (Regex.IsMatch(text, @"[a-z]{2}[0-9]{13}", RegexOptions.IgnoreCase)) return "Driving License";
            if (text.Contains("ration card")) return "Ration Card";
            if (text.Contains("bank") && text.Contains("account")) return "Bank Passbook";
            if (text.Contains("birth certificate")) return "Birth Certificate";
            if (text.Contains("death certificate")) return "Death Certificate";
            if (text.Contains("caste validity certificate")) return "Caste Validity Certificate";
            if (text.Contains("caste certificate")) return "Caste Certificate";
            if (text.Contains("income certificate")) return "Income Certificate";
            if (text.Contains("domicile certificate")) return "Domicile Certificate";
            if (text.Contains("electricity bill")) return "Electricity Bill";
            if (text.Contains("secondary school certificate") || text.Contains("ssc") || text.Contains("statement of marks"))
                return "SSC Marksheet";
            if (text.Contains("higher secondary certificate") || text.Contains("hsc"))
                return "HSC Marksheet";
            if (text.Contains("school leaving certificate")) return "School Leaving Certificate";
            if (text.Contains("transfer certificate")) return "Transfer Certificate";
            if (text.Contains("bonafide certificate")) return "Bonafide Certificate";
            if (text.Contains("employment card")) return "Employment Card";
            if (text.Contains("disability certificate")) return "Disability Certificate";

            return "Other";
        }

    }
}
