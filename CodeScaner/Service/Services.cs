using CodeScaner.Service;
using CodeScaner.Service.Client;
using CodeScaner.Service.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service
{
    public static class Services
    {
        public static IProtobufServer Server => ServiceLocator<IProtobufServer>.GetService();

        public static ISettings Settings => ServiceLocator<ISettings>.GetService();
    }
}
