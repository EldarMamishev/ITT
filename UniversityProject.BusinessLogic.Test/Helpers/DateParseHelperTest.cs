using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.BusinessLogic.Helpers;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;

namespace UniversityProject.BusinessLogic.Test.Helpers
{
    [TestFixture]
    class DateParseHelperTest
    {
        private DateParseHelper helper;

        [SetUp]
        public void SetUp()
        {
            helper = new DateParseHelper();
        }

        [Test]
        public void ParseDateToString_InputIsDate_ReturnsDateToString()
        {
            DateTime date = new DateTime(2000, 4, 13);

            var result = helper.ParseDateToString(date);

            Assert.AreEqual(result, date.ToString("MM/dd/yyyy"));
        }

        [Test]
        public void ParseStringToOnlyYearDatetime_InputIsNull_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToOnlyYearDatetime(null));
        }

        [Test]
        public void ParseStringToOnlyYearDatetime_InputIsEmptyString_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToOnlyYearDatetime(string.Empty));
        }

        [Test]
        public void ParseStringToDatetimeToString_InputIsNull_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToDatetimeToString(null));
        }

        [Test]
        public void ParseStringToDatetimeToString_InputIsEmptyString_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToDatetimeToString(string.Empty));
        }

        [Test]
        public void ParseStringToDatetime_InputIsNull_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToDatetime(null));
        }

        [Test]
        public void ParseStringToDatetime_InputIsEmptyString_ThrowsDateParseException()
        {
            Assert.Throws<DateParseException>(() => helper.ParseStringToDatetime(string.Empty));
        }
    }
}
