using CodeScaner.Model.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Service.Client
{
    public interface ISettings
    {
        void AddOrUpdateUrlPort(ServerUrl urlPort);

        ServerUrl GetUrlPort(ServerUrl defaultVal);

        void AddOrUpdateFormats(IEnumerable<BarcodeType> formats);

        IEnumerable<BarcodeType> GetFormats(IEnumerable<BarcodeType> defaultVal);

        void AddOrUpdatePerson(Person person);

        Person GetPerson(Person defaultVal);
    }
}
