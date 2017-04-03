using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    public class NewFormat : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                throw new ArgumentException(nameof(format));

            if (ReferenceEquals(arg, null) || !(arg is Customer))
                throw new ArgumentException(nameof(arg));

            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            Customer customer = (Customer)arg;

            if (format.ToUpperInvariant() != "Z")
                return customer.ToString("G", CultureInfo.CreateSpecificCulture("en-US"));

            return string.Format($"{customer.Name} - {customer.Revenue.ToString("C", formatProvider)} - {customer.ContactPhone}");
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }
    }
}
