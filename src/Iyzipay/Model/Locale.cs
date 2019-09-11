namespace Armut.Iyzipay.Model
{
    public sealed class Locale
    {
        private readonly string value;

        public static readonly Locale EN = new Locale("en");
        public static readonly Locale TR = new Locale("tr");

        private Locale(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
