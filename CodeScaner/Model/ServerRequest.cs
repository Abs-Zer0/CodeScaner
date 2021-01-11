using CodeScaner.Model.Requests;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    [ProtoContract]
    public class ServerRequest
    {
        [ProtoMember(1)]
        public string Login { get; set; }
        [ProtoMember(2)]
        public string Password { get; set; }
        [ProtoMember(3)]
        public string Barcode { get; set; }
        [ProtoMember(4)]
        public Status NewStatus { get; set; }
        [ProtoMember(5)]
        public string Description { get; set; }

        public ServerRequest(string login, string password, string barcode, Status newStatus, string description)
        {
            this.Login = Encoding.ASCII.GetString(Encoding.Default.GetBytes(login));
            this.Password = Encoding.ASCII.GetString(Encoding.Default.GetBytes(password));
            this.Barcode = Encoding.ASCII.GetString(Encoding.Default.GetBytes(barcode));
            this.NewStatus = newStatus;
            this.Description = description;
        }

        public ServerRequest(string login, string password) : this(login, password, "", Status.UNKNOWN, "") { }
    }
}
