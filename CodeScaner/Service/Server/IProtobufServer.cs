using CodeScaner.Model;
using CodeScaner.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeScaner.Service.Server
{
    public interface IProtobufServer
    {
        Task SignInAsync(string login, string password);

        Task ChangeStatusAsync(string barcode, Status newStatus, string description);
    }
}
