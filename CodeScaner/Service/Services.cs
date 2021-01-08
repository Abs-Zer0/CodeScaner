using CodeScaner.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service
{
    public static class Services
    {
        public static IProtobufServer Server => ServiceLocator<IProtobufServer>.GetService();
    }
}
