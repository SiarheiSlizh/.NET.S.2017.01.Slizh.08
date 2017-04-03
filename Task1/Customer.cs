using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// This class contains the information about person.
    /// </summary>
    public class Customer: IFormattable
    {
        #region fields
        /// <summary>
        /// Person's name.
        /// </summary>
        private string name;

        /// <summary>
        /// Person's contact phone.
        /// </summary>
        private string contactPhone;

        /// <summary>
        /// Persons's revenue.
        /// </summary>
        private decimal revenue;
        #endregion

        #region properties
        /// <summary>
        /// Property which works with field 'name'.
        /// </summary>
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        /// <summary>
        /// Property which works with field 'contactPhone'.
        /// </summary>
        public string ContactPhone
        {
            get { return contactPhone; }
            private set { contactPhone = value; }
        }

        /// <summary>
        /// Property which works with field 'revenue'.
        /// </summary>
        public decimal Revenue
        {
            get { return revenue; }
            private set {
                if (value < 0)
                    throw new ArgumentException();
                revenue = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor initializes all fields of class.
        /// </summary>
        /// <param name="name">Person's name.</param>
        /// <param name="contactPhone">Person's contact phone.</param>
        /// <param name="revenue">Person's revenue.</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        #endregion

        #region formats
        /// <summary>
        /// Method implements a string representation of Custumer's object.
        /// </summary>
        /// <returns>A string representation of Custumer's object.</returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Method implements a string representation of Custumer's object.
        /// </summary>
        /// <param name="format">Format defines a string representation.</param>
        /// <returns>A string representation of Custumer's object.</returns>
        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Method implements a string representation of Custumer's object.
        /// </summary>
        /// <param name="format">Format defines a string representation.</param>
        /// <param name="formatProvider">FormatProvider defines culture.</param>
        /// <returns>A string representation of Custumer's object.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";

            if (ReferenceEquals(formatProvider,null))
                formatProvider = CultureInfo.CurrentCulture;

            string revenueFormat = Revenue.ToString("N", formatProvider);

            switch (format.ToUpperInvariant())
            {
                case "G":      
                    return string.Format($"{Name}, {revenueFormat}, {ContactPhone}");
                case "N":
                    return Name;
                case "R":
                    return revenueFormat;
                case "C":
                    return ContactPhone;
                case "NR":
                    return string.Format($"{Name}, {revenueFormat}");
                case "NC":
                    return string.Format($"{Name}, {ContactPhone}");
                case "RC":
                    return string.Format($"{revenueFormat}, {ContactPhone}");
                default:
                    throw new ArgumentException(string.Format($"{format} doesn't exist for string."),format);
            }
        }
        #endregion
    }
}