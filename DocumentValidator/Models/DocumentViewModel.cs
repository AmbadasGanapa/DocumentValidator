using Microsoft.AspNetCore.Http;

namespace DocumentValidator.Models
{
    public class DocumentViewModel
    {
        public string ExpectedDocumentType { get; set; }
        public IFormFile File { get; set; }
    }
}
