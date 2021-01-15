using CodeScaner.Model.Settings;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CodeScaner.Service.Client
{
    public class Settings : ISettings
    {
        public void AddOrUpdateFormats(IEnumerable<BarcodeType> formats)
        {
            CrossSettings.Current.AddOrUpdateValue("formats", JsonSerializer.Serialize(formats));
        }

        public void AddOrUpdatePerson(Person person)
        {
            CrossSettings.Current.AddOrUpdateValue("person", JsonSerializer.Serialize(person));
        }

        public void AddOrUpdateUrlPort(ServerUrl urlPort)
        {
            CrossSettings.Current.AddOrUpdateValue("url:port", JsonSerializer.Serialize(urlPort));
        }

        public void AddOrUpdateUrlPort(string url, string port)
        {
            CrossSettings.Current.AddOrUpdateValue("url:port", url + ":" + port);
        }

        public IEnumerable<BarcodeType> GetFormats(IEnumerable<BarcodeType> defaultVal)
        {
            string formatsDefault = JsonSerializer.Serialize(defaultVal);
            string formatsJson = CrossSettings.Current.GetValueOrDefault("formats", formatsDefault);

            return JsonSerializer.Deserialize<IEnumerable<BarcodeType>>(formatsJson);
        }

        public Person GetPerson(Person defaultVal)
        {
            string personDefault = JsonSerializer.Serialize(defaultVal);
            string personJson = CrossSettings.Current.GetValueOrDefault("person", personDefault);

            return JsonSerializer.Deserialize<Person>(personJson);
        }

        public ServerUrl GetUrlPort(ServerUrl defaultVal)
        {
            string urlPortDefault = JsonSerializer.Serialize(defaultVal);
            string urlPortJson = CrossSettings.Current.GetValueOrDefault("url:port", urlPortDefault);

            return JsonSerializer.Deserialize<ServerUrl>(urlPortJson);
        }

        public string[] GetUrlPort(string urlDefault, string portDefault)
        {
            return CrossSettings.Current.GetValueOrDefault("url:port", urlDefault + ":" + portDefault).Split(':');
        }
    }
}
