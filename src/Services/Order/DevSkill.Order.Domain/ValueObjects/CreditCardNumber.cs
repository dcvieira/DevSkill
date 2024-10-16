﻿

using DevSkill.Order.Domain.Common;

namespace DevSkill.Order.Domain.ValueObjects
{
    public class CreditCardNumber : ValueObject
    {
        public string Value { get; private set; }

        private CreditCardNumber(string value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static CreditCardNumber From(string value)
        {
            if (!isValid())
            {
                throw new Exception("Invalid Credit Card Number");
            }          
            return new CreditCardNumber(value); ;
        }

        public static explicit operator CreditCardNumber(string value)
        {
            return From(value);
        }

        private static bool isValid() {
            // Todo Validat CreditCard Number
            return true;
        }
    }
}
