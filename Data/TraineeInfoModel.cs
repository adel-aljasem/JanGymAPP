using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanGym.Data
{

    public class TraineeInfoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يوجد خانات الزامية فارغة")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يوجد خانات الزامية فارغة")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "يوجد خانات الزامية فارغة")]
        [MinLength(10, ErrorMessage = "رقم الجوال ناقص"),MaxLength(10, ErrorMessage = "رقم الجوال زايد")]
        public string Phone { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public List<SubscribeModel>? SubscribeTrainee { get; set; }
        public string? Note { get; set; }
        public bool UserBlocked { get; set; }
        public bool SubscribeIsActive { get; set; }
        public string Branch { get; set; } = "السلامة";
        public string AddedBy { get; set; }
    }
}
