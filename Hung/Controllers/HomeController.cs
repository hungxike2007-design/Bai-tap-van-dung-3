using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hung.Models;

namespace Hung.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult BaiTap2()
    {
        var sanpham = new SanPhamViewModel()
        {
            TenSanPham = "Zenith Horizon Smartwatch",
            GiaBan = 299.99m,
            AnhMoTa = "/images/smartwatch.png"
        };
        return View(sanpham);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
