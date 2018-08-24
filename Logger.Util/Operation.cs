using System.Collections.Generic;

namespace Logger.Util
{
    public class Operation
    {
        //public T Data { get; set; }
        //public IEnumerable<T> Lista { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }

        public Operation()
        {
            // Prevent outside instantiation
        }

        //private static readonly Operation<T> _operation = new Operation<T>();
        private static readonly Operation _operation = new Operation();

        /*public static Operation<T> GetSingleton()
        {
            return _operation;
        }*/

        public static Operation GetSingleton()
        {
            return _operation;
        }
    }
}
