using System.Globalization;

namespace Armut.Iyzipay
{
    public static class PriceExtensions
    {
        private static readonly CultureInfo PriceCulture = new CultureInfo("en-US");

        public static string RemoveTrailingZeros(this string strPrice)
        {
            return strPrice.Contains(".") ? strPrice.TrimEnd('0').TrimEnd('.') : strPrice;
        }

        public static void TryParse(this string strPrice, out decimal price)
        {
            decimal.TryParse(strPrice, NumberStyles.None, PriceCulture, out price);
        }

        public static void TryParse(this string strPrice, out double price)
        {
            double.TryParse(strPrice, NumberStyles.None, PriceCulture, out price);
        }

        public static decimal ParseDecimal(this string strPrice)
        {
            return decimal.Parse(strPrice, PriceCulture);
        }

        public static double ParseDouble(this string strPrice)
        {
            return double.Parse(strPrice, PriceCulture);
        }

        public static string ToPrice(this decimal price)
        {
            return price.ToString(PriceCulture);
        }

        public static string ToPrice(this double price)
        {
            return price.ToString(PriceCulture);
        }
    }
}
