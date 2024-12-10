using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Mission
    {
        [Key]
        public  string Name { get; set; }
        [Required]
        public  string Content { get; set; }
        [Required]
        public  DateTime Date { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account? account { get; set; }

    }
}
