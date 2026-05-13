using System.ComponentModel.DataAnnotations;

namespace Hung.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Display(Name = "Mã công việc")]
        [Required(ErrorMessage = "Mã công việc không được để trống")]
        public string MaCongViec { get; set; } = string.Empty;

        [Display(Name = "Tên công việc")]
        [Required(ErrorMessage = "Tên công việc không được để trống")]
        public string TenCongViec { get; set; } = string.Empty;

        [Display(Name = "Trạng thái hoàn thành")]
        public bool TrangThaiHoanThanh { get; set; }
    }
}
