using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery_Management_Application.Models
{
    public class Grocery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemDiscription { get; set; }
        [Required]
        public string ItemType { get; set; }
        public int CategoryId {get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public double ItemPrice { get; set; }
        public string Createdby { get; set; }
    }
}
