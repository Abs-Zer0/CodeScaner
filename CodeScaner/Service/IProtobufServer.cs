using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service
{
    interface IProtobufServer
    {
        ServerResponse ServerConnect(ServerRequest request);
    }
}
