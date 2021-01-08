using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service
{
    public interface IProtobufServer
    {
        ServerResponse SignIn(ServerRequest request);

        ServerResponse ChangeStatus(ServerRequest request);

        ServerResponse TryConnect();
    }
}
