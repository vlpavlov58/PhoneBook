using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PhoneBook.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReverseAttribute : Attribute
    {
        private string _value { get; set; }

        public ReverseAttribute(string value)
        {
            _value = value;
        }

        public string Reverse (string value)
        {
            char[] arr = value.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}