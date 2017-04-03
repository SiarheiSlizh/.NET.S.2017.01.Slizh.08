using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100")]
        public void Customer_ArgumentException(string name, decimal revenue, string contactPhone)
        {
            Assert.Throws<ArgumentException>(() => new Customer(name, contactPhone, revenue).ToString("AA"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100")]
        public void NewFormat_ArgumentException(string name, decimal revenue, string contactPhone)
        {
            Assert.Throws<ArgumentException>(() => new NewFormat().Format("AA", new Customer(name, contactPhone, revenue), null));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string Customer_G_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("g", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "Jeffrey Richter")]
        public string Customer_N_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("n", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "1,000,000.00")]
        public string Customer_R_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("r", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "+1 (425) 555-0100")]
        public string Customer_C_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "Jeffrey Richter, 1,000,000.00")]
        public string Customer_NR_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("nr", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "Jeffrey Richter, +1 (425) 555-0100")]
        public string Customer_NC_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("nc", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "1,000,000.00, +1 (425) 555-0100")]
        public string Customer_RC_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new Customer(name, contactPhone, revenue).ToString("rc", CultureInfo.CreateSpecificCulture("en-US"));
        }

        [TestCase("Jeffrey Richter", 1000000, "+1 (425) 555-0100", ExpectedResult = "Jeffrey Richter - $1,000,000.00 - +1 (425) 555-0100")]
        public string NewCustomer_PositiveTests(string name, decimal revenue, string contactPhone)
        {
            return new NewFormat().Format("z", new Customer(name, contactPhone, revenue), CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}