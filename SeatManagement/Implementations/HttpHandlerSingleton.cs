using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Implementations
{
    public static class HttpHandlerSingleton
    {
        private static HttpHandler httpHandlerInstance;
        private static readonly object lockObject = new object();
        public static HttpHandler GetInstance()
        {
            lock (lockObject)
            {
                if (httpHandlerInstance == null)
                    httpHandlerInstance = new HttpHandler();
            }
            return httpHandlerInstance;
        }
    }
}
