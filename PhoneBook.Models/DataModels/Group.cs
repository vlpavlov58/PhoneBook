using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models.DataModels
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Name")]
        public string Name { get; set; }
    }
}
