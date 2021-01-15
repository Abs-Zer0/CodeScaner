using CodeScaner.Model.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service.Client
{
    public interface ISettings
    {
        void AddOrUpdateUrlPort(ServerUrl urlPort);
        void AddOrUpdateUrlPort(string url, string port);

        ServerUrl GetUrlPort(ServerUrl defaultVal);
        string[] GetUrlPort(string urlDefault, string portDefault);

        void AddOrUpdateFormats(IEnumerable<BarcodeType> formats);

        IEnumerable<BarcodeType> GetFormats(IEnumerable<BarcodeType> defaultVal);

        void AddOrUpdatePerson(Person person);
        void AddOrUpdatePerson(string login, string password);

        Person GetPerson(Person defaultVal);
        string[] GetPerson(string loginDefault, string passwordDefault);
    }
}
