using System.ComponentModel.DataAnnotations;

namespace MediRed.Models
{
    public class Person
    {
        [Key]
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone{ get; set; }
    }
}