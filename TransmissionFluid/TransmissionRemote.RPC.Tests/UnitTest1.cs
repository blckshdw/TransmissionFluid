using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransmissionRemote.RPC;

namespace TransmissionRemote.RPC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public const string Host = "172.30.0.1";
        [TestMethod]
        public void GetSession()
        {
            var client = new Client(Host);
            var result = client.GetSession();

            Assert.IsTrue(result.RpcVersion >= 8);
        }

        [TestMethod]
        public void GetSessionStats()
        {
            var client = new Client(Host);
            var result = client.GetSessionStats();

            Assert.IsTrue(result.TorrentCount > 0);
        }

    }
}
