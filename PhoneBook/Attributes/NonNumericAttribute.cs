using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Attributes
{
    public class NonNumericAttribute : ValidationAttribute
    {
        private ValidateAction _action;

        private delegate bool Validator(string value);

        private Dictionary<ValidateAction, Validator> _validators
            = new Dictionary<ValidateAction, Validator>();

        public NonNumericAttribute (ValidateAction action)
        {
            _action = action;

            _validators.Add(
                ValidateAction.Numbers,
                new Validator(NumberValidator));

            _validators.Add(
               ValidateAction.Cyrilic,
               new Validator(LetterValidator));
        }

        private bool NumberValidator(string value)
        {
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return !numbers.Contains(value[0]);
        }

        private bool LetterValidator(string value)
        {
            char[] letters = new char[] { 'ё', 'ь', 'й', 'ъ' };
            return !letters.Contains(value[0]);
        }

        public override bool IsValid (object value)
        {
            if (value is string strValue)
            {
                if (!string.IsNullOrEmpty(strValue))
                {
                    return _validators[_action].Invoke(strValue);
                }
            }
            return false;
        }

        private bool CompleteValidator(string value)
        {
            return NumberValidator(value) && LetterValidator(value);
        }
       
    }
    public enum ValidateAction
    {
        All = 0,
        Numbers = 1,
        Cyrilic = 2
    }
}