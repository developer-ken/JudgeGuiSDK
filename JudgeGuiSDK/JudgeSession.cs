using JudgeGuiSDK.Packages;
using System;
using System.Net;
using System.Net.Sockets;

namespace JudgeGuiSDK
{
    public class JudgeSession
    {
        Socket sock;
        IPEndPoint remote;
        static public bool ThrowErrors = false;
        Exception LastException;
        public JudgeSession(IPAddress judgeguiserver, int port = 6666)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            remote = new IPEndPoint(judgeguiserver, port);
        }

        public bool Connect()
        {
            try
            {
                sock.Connect(remote);
            }
            catch(Exception e)
            {
                if (ThrowErrors) throw;
                LastException = e;
                return false;
            }
            return sock.Connected;
        }

        public bool SendPack(CommonPackage package)
        {
            try
            {
                sock.Send(package.Pack());
                return true;
            }
            catch (Exception e)
            {
                if (ThrowErrors) throw;
                LastException = e;
                return false;
            }
        }

        public void Close()
        {
            sock.Close();
        }
    }
}
