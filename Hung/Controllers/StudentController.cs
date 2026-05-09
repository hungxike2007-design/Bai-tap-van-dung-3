using Microsoft.AspNetCore.Mvc;
using Hung.Models;

namespace Hung.Controllers;

public class StudentController : Controller
{
    private static readonly string[] Majors = new[] { "CNPM", "HTTT", "ANM", "TTNT", "MMT" };

    private static readonly List<StudentViewModel> RegisteredStudents = new()
    {
        new StudentViewModel { MSSV = "SV001", HoTen = "Nguyễn Văn A", DiemTB = 8.2m, ChuyenNganh = "CNPM" },
        new StudentViewModel { MSSV = "SV002", HoTen = "Trần Thị B", DiemTB = 7.5m, ChuyenNganh = "HTTT" },
        new StudentViewModel { MSSV = "SV003", HoTen = "Lê Văn C", DiemTB = 8.0m, ChuyenNganh = "CNPM" },
        new StudentViewModel { MSSV = "SV004", HoTen = "Phạm Thị D", DiemTB = 9.0m, ChuyenNganh = "TTNT" },
        new StudentViewModel { MSSV = "SV005", HoTen = "Ngô Văn E", DiemTB = 7.8m, ChuyenNganh = "MMT" }
    };

    public IActionResult Index()
    {
        ViewData["Majors"] = Majors;
        return View(new StudentViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ShowKQ(StudentViewModel student)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Majors"] = Majors;
            return View("Index", student);
        }

        var sameMajorCount = RegisteredStudents.Count(s => s.ChuyenNganh == student.ChuyenNganh) + 1;

        var model = new StudentResultViewModel
        {
            Student = student,
            SoLuongCungNganh = sameMajorCount
        };

        return View(model);
    }
}
