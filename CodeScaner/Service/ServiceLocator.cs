using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service
{
    public static class ServiceLocator<T>
    {
        private static T service;

        public static void RegisterService(T serviceImpl)
        {
            if (service != null)
                throw new Exception("This service already registered");

            service = serviceImpl;
        }

        public static T GetService()
        {
            if (service == null)
                throw new Exception("Service is not registered yet");

            return service;
        }
    }
}
