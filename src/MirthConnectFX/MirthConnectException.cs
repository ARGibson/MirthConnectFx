using System;
using System.Runtime.Serialization;

namespace MirthConnectFX
{
    [Serializable]
    public class MirthConnectException : Exception
    {
        public string MirthError { get; private set; }
        
        public MirthConnectException()
        {
        }

        public MirthConnectException(string message, string mirthError) : base(message)
        {
            MirthError = mirthError;
        }

        public MirthConnectException(string message, string mirthError, Exception inner) : base(message, inner)
        {
            MirthError = mirthError;
        }

        protected MirthConnectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("MirthError", MirthError);
        }
    }
}