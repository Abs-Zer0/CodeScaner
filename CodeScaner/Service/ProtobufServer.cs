using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CodeScaner.Service
{
    public class ProtobufServer : IProtobufServer
    {
        

        public ServerResponse ChangeStatus(ServerRequest request)
        {
            throw new NotImplementedException();
        }

        public ServerResponse SignIn(ServerRequest request)
        {
            TcpClient client = new TcpClient();

            return new ServerResponse();
        }

        public ServerResponse TryConnect()
        {
            throw new NotImplementedException();
        }
    }
}
