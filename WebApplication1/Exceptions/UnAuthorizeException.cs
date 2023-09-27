namespace WebApplication1.Exceptions
{
    public class UnAuthorizeException:Exception
    {
        public UnAuthorizeException() { }
        public UnAuthorizeException(string message) : base(message) { }

    }
}
