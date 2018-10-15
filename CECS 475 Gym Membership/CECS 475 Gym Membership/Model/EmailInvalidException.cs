using System;
using System.Runtime.Serialization;

namespace CECS_475_Gym_Membership.Model
{
    [Serializable]
    internal class EmailInvalidException : Exception
    {
        public EmailInvalidException()
        {
        }

        public EmailInvalidException(string message) : base(message)
        {
        }

        public EmailInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}