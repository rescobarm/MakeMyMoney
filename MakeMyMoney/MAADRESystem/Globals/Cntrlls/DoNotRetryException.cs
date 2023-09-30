namespace MakeMyMoney.MAADRESystem.Globals.Cntrlls
{
    public class DoNotRetryException : Exception
    {
        public DoNotRetryException(string message) : base(message)
        {
            message = "Error controlado...";
        }
    }
}
