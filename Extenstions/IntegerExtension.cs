namespace Extenstions
{
    public static class IntegerExtension
    {
        public static bool IsWithin(this int value, int medium, int scope)
        {
            return value >= medium-scope && value <= medium+scope;
        }

        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}
