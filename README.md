# 🧾 DocumentValidator

**DocumentValidator** is an intelligent ASP.NET Core application powered by **Tesseract OCR** that automatically validates uploaded documents such as Aadhar, PAN, and other identity proofs.  
It extracts and analyzes text from uploaded files to confirm whether the document matches the expected type — ensuring accurate and error-free submissions.

---

## 🚀 Project Overview

In real-world online applications or KYC processes, users often upload the **wrong document type** (e.g., uploading a PAN Card instead of an Aadhar Card).  
This project solves that problem by **extracting text using OCR** and automatically **validating** whether the uploaded file is indeed the requested document.

---

## 🧠 Key Features

- ✅ **OCR-Based Text Extraction** — Reads text from image or PDF files using Tesseract OCR.  
- ✅ **Smart Document Validation** — Detects document type (Aadhar, PAN, etc.) through text pattern analysis.  
- ✅ **Automatic Approval/Rejection** — Approves correct document types and rejects mismatched ones.  
- ✅ **Fast & Efficient** — Built with ASP.NET Core for high performance and scalability.  
- ✅ **User-Friendly Interface** — Simple and guided upload process for end users.

---

## 🏗️ Tech Stack

| Component | Technology Used |
|------------|----------------|
| **Frontend** | ASP.NET Core Razor Pages / MVC |
| **Backend** | C# (.NET 6 / .NET 7) |
| **OCR Engine** | [Tesseract OCR](https://github.com/tesseract-ocr/tesseract) |
| **Database** | SQL Server / SQLite |
| **IDE** | Visual Studio 2022 |
| **Version Control** | Git & GitHub |

---

## ⚙️ How It Works

1. **User Uploads Document** (e.g., Aadhar card image in JPG, PNG).  
2. **Tesseract OCR Engine Extracts Text** from the document.  
3. **Validation Logic** checks for unique identifiers (like “Aadhar”, “Government of India”, “XXXX-XXXX-XXXX”).  
4. If it **matches** the expected document type → **Approved** ✅  
5. If not → **Rejected** ❌ with a message “Invalid Document Type.”

---

## 🖼️ Example Scenarios

| Scenario | Expected Outcome |
|-----------|------------------|
| Upload Aadhar Card when Aadhar is requested | ✅ Approved |
| Upload PAN Card when Aadhar is requested | ❌ Rejected |
| Upload any unrelated document | ❌ Rejected |

---

## 🧰 Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/AmbadasGanapa/DocumentValidator.git
   cd DocumentValidator

   Open the project in Visual Studio

Restore dependencies

`dotnet restore`


Run the application

`dotnet run`


Open in browser

`https://localhost:5001/`


🧩 Folder Structure
DocumentValidator/
│
├── Controllers/
├── Models/
├── Views/
├── Services/
│   └── OCRService.cs
├── wwwroot/
├── appsettings.json
├── Program.cs
└── README.md

📊 Future Enhancements

🔍 AI-based classification for multilingual documents.

📱 Mobile upload and camera capture support.

📤 Integration with government APIs for real-time verification.

📑 Admin dashboard for viewing upload logs and validation reports.

👨‍💻 Developed By

Ambadas Mohan Ganapa
🎓 BCA (Final Year) | Software Developer Intern at Lemonade Software Developers

📧 ambadasganapa31@gmail.com

🔗 LinkedIn – Ambadas Ganapa

[🌐 Portfolio Website:](https://ambadasganapa.github.io)
