using System.ComponentModel.DataAnnotations;

namespace Hung.Models;

public class StudentViewModel
{
    [Required(ErrorMessage = "MSSV là bắt buộc")]
    public string? MSSV { get; set; }

    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    public string? HoTen { get; set; }

    [Required(ErrorMessage = "Điểm TB là bắt buộc")]
    [Range(0, 10, ErrorMessage = "Điểm TB phải nằm trong khoảng 0 - 10")]
    public decimal? DiemTB { get; set; }

    [Required(ErrorMessage = "Chuyên ngành là bắt buộc")]
    public string? ChuyenNganh { get; set; }
}
