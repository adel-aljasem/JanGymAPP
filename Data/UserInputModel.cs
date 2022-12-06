using System.ComponentModel.DataAnnotations;

namespace JanGym.Data
{
    public class UserInputModel
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="الرجاء الادخال")]
        public string UserName { get; set; }
    }
}
