using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    /// <summary>
    /// New format for string representation.
    /// </summary>
    public class NewFormat : IFormatProvider, ICustomFormatter
    {
        #region ICustomFormatter's method
        /// <summary>
        /// Method implements a string representation of Custumer's object.
        /// </summary>
        /// <param name="format">Format defines a string representation.</param>
        /// <param name="arg">Type of object which is used for new string representation.</param>
        /// <param name="formatProvider">FormatProvider defines culture.</param>
        /// <returns>A string representation of Custumer's object.</returns>
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
                return customer.ToString(format, CultureInfo.CreateSpecificCulture("en-US"));

            return string.Format($"{customer.Name} - {customer.Revenue.ToString("C", formatProvider)} - {customer.ContactPhone}");
        }
        #endregion

        #region IFormatProvider's method
        /// <summary>
        /// Method defines if you can create new format.
        /// </summary>
        /// <param name="formatType">Type of format.</param>
        /// <returns>Data about format.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }
        #endregion
    }
}
