using System.Runtime.Serialization;

namespace SosuPower.DataAccess
{
    [Serializable]
    internal class UseYourHeadException: Exception
    {
        public UseYourHeadException()
        {
        }

        public UseYourHeadException(string message) : base(message)
        {
        }

        public UseYourHeadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UseYourHeadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}