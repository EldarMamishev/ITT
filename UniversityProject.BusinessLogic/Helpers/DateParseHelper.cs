using System;
using System.Globalization;
using UniversityProject.BusinessLogic.Helpers.Interfaces;
using UniversityProject.Shared.Constants;
using UniversityProject.Shared.Exceptions.BusinessLogicExceptions;

namespace UniversityProject.BusinessLogic.Helpers
{
    public class DateParseHelper : IDateParseHelper
    {
        private static string _defaultDatetimeFormat;
        private static string _defaultTimeFormat;

        public DateParseHelper()
        {
            _defaultDatetimeFormat = "yyyy";
            //_defaultTimeFormat = ApplicationConstants.DEFAULT_TIME_FORMAT;
        }

        public DateTime? ParseStringToOnlyYearDatetime(string stringDateValue)
        {
            if (String.IsNullOrEmpty(stringDateValue))
            {
                throw new DateParseException("Error date parse.");
            }

            var provider = CultureInfo.InvariantCulture;
            var dateResult = new DateTime();
            
            DateTime.TryParseExact(stringDateValue, _defaultDatetimeFormat, provider, DateTimeStyles.None, out dateResult);

            if (dateResult.Equals(default(DateTime)))
            {
                throw new DateParseException("Error date parse.");
            }

            return dateResult;
        }

        public string ParseDateToString(DateTime dateTimeValue)
        {
            string result = dateTimeValue.ToString(_defaultDatetimeFormat);

            return result;
        }

        public string ParseStringToDatetimeToString(string dateForParsing)
        {
            if (String.IsNullOrEmpty(dateForParsing))
            {
                throw new DateParseException("Error date parse.");
            }

            var provider = CultureInfo.InvariantCulture;
            var dateResult = new DateTime();

            DateTime.TryParseExact(dateForParsing, _defaultDatetimeFormat, provider, DateTimeStyles.None, out dateResult);

            if (dateResult.Equals(default(DateTime)))
            {
                throw new DateParseException("Error date parse.");
            }

            var dateStringResult = dateResult.ToString(_defaultDatetimeFormat);

            return dateStringResult;
        }
    }
}