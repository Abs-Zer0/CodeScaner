using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace CodeScaner.Service
{
    public class ProtobufServer : IProtobufServer
    {
        public ServerResponse ServerConnect(ServerRequest request)
        {
            TcpClient client = new TcpClient();

            return new ServerResponse();
        }
    }
}
