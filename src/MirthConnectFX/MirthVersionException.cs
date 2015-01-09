using System;
using System.Runtime.Serialization;

namespace MirthConnectFX
{
    [Serializable]
    public class MirthVersionException : Exception
    {
        public MirthVersionException()
        {
        }

        public MirthVersionException(string message) : base(message)
        {
        }

        public MirthVersionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MirthVersionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}