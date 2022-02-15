using Microsoft.VisualStudio.TestTools.UnitTesting;
using JudgeGuiSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace JudgeGuiSDK.Tests
{
    [TestClass()]
    public class JudgeSessionTests
    {
        private JudgeSession _session;
        [TestMethod()]
        public void JudgeSessionTest()
        {
            _session = new JudgeSession(IPAddress.Loopback);
            _session.Connect();
            _session.SendPack(new Packages.TeamInfoPackage() { TeamID = "TestTeam" });
            Thread.Sleep(5000);
            _session.SendPack(new Packages.ResultPackage(Packages.ResultPackageType.MeasurementResults) {  });
            _session.Close();
        }
    }
}