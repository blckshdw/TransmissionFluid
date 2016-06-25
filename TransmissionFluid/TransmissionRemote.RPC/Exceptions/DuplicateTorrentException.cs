using System;
using System.Runtime.Serialization;

namespace TransmissionRemote.RPC.Exceptions
{
    [Serializable]
    internal class DuplicateTorrentException : Exception
    {
        public DuplicateTorrentException()
        {
        }

        public DuplicateTorrentException(string message) : base(message)
        {
        }

        public DuplicateTorrentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTorrentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}