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

    private static readonly List<TodoItem> _todos = new()
    {
        new TodoItem { Id = 1, MaCongViec = "1", TenCongViec = "Đi chợ", TrangThaiHoanThanh = false },
        new TodoItem { Id = 2, MaCongViec = "2", TenCongViec = "Chơi thể thao", TrangThaiHoanThanh = false },
        new TodoItem { Id = 3, MaCongViec = "3", TenCongViec = "Chơi game", TrangThaiHoanThanh = false },
        new TodoItem { Id = 4, MaCongViec = "4", TenCongViec = "Học bài", TrangThaiHoanThanh = false }
    };

    private static int _nextTodoId = 5;

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

    public IActionResult ActorDemo()
    {
        return View();
    }

    public IActionResult TodoList()
    {
        return View(_todos);
    }

    public IActionResult TodoDetails(int id)
    {
        var todo = _todos.FirstOrDefault(x => x.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    public IActionResult TodoCreate()
    {
        return View(new TodoItem());
    }

    [HttpPost]
    public IActionResult TodoCreate(TodoItem model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = _nextTodoId++;
        _todos.Add(model);
        return RedirectToAction("TodoList");
    }

    public IActionResult TodoEdit(int id)
    {
        var todo = _todos.FirstOrDefault(x => x.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    [HttpPost]
    public IActionResult TodoEdit(TodoItem model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var todo = _todos.FirstOrDefault(x => x.Id == model.Id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.MaCongViec = model.MaCongViec;
        todo.TenCongViec = model.TenCongViec;
        todo.TrangThaiHoanThanh = model.TrangThaiHoanThanh;

        return RedirectToAction("TodoList");
    }

    public IActionResult TodoDelete(int id)
    {
        var todo = _todos.FirstOrDefault(x => x.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
        return RedirectToAction("TodoList");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
