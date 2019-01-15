using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models.DataModels
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
