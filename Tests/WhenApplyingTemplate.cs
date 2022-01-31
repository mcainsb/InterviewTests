using Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class WhenApplyingTemplate
    {
        [Test]
        public void ShouldApplyTemplate()
        {
            string template = "We have recently found out that we owe you {sum}. Could you please give us your bank account number in {country} so that the funds can be disbursed.";
            string expected = "We have recently found out that we owe you $100. Could you please give us your bank account number in US so that the funds can be disbursed.";

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"country" ,"US" },
                {"sum", "$100" },
                {"date", "today" },  //unused
            };

            Assert.AreEqual(expected,
                TemplateExpander.PopulateTemplate(template, values));
        }

        [Test]
        public void ShouldApplyTemplateAtStartAndEnd()
        {
            string template = "{salutation}, we have recently found out that we owe you {sum}";
            string expected = "Dear Mr. Smith, we have recently found out that we owe you $100";

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"salutation" ,"Dear Mr. Smith" },
                {"sum", "$100" },
                {"date", "today" },  //unused
            };

            Assert.AreEqual(expected,
                TemplateExpander.PopulateTemplate(template, values));
        }

        [Test]
        public void ShouldApplyTemplateWithMultipleUsesOfKey()
        {
            string template = "We have recently found out that we owe you {sum}. Please give us your bank account number so that we can give you {sum}. This is not suspicious at all.";
            string expected = "We have recently found out that we owe you $100. Please give us your bank account number so that we can give you $100. This is not suspicious at all.";

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                {"sum", "$100" },
                {"date", "today" },  //unused
            };

            Assert.AreEqual(expected,
                TemplateExpander.PopulateTemplate(template, values));
        }
    }
}
