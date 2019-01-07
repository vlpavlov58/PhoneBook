using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Required Name")]
        public string Name { get; set; }
    }
}