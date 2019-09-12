namespace Armut.Iyzipay.Model
{
    public sealed class Status
    {
        private readonly string value;

        public static readonly Status SUCCESS = new Status("success");
        public static readonly Status FAILURE = new Status("failure");

        private Status(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        } 
    }
}
