using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual List<Mission>? Missions { get; set; }


    }
}
