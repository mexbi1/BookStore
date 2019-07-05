using System;
using System.Globalization;

namespace BookStore.Shared
{
    public class BusinessLogicException:Exception
    {
        public BusinessLogicException() : base() { }

        public BusinessLogicException(string message) : base(message) { }

        public BusinessLogicException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
