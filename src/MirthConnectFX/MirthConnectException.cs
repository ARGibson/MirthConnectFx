using System;
using System.Runtime.Serialization;

namespace MirthConnectFX
{
    [Serializable]
    public class MirthConnectException : Exception
    {
        public MirthConnectException()
        {
        }

        public MirthConnectException(string message) : base(message)
        {
        }

        public MirthConnectException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MirthConnectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}