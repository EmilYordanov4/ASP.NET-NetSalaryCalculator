namespace NetSalaryCalculator.Data
{
	public class DataConstants
    {

        public class User
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 40;
            public const int MinPasswordLength = 6;
            public const int MaxPasswordLength = 100;
        }

        public class AnnualBasis
        {
            public const int MinYear = 1900;
            public const int MaxYear = 2100;
            public const double MinValue = 1;
            public const double MaxThreshold = 10000;
            public const int MaxPercentage = 100;
        }

    }
}
