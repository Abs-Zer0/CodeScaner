using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace sbc.data
{
    [ProtoContract]
    public class ServerRequest : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1)]
        [global::System.ComponentModel.DefaultValue("")]
        public string Login { get; set; } = "";

        [global::ProtoBuf.ProtoMember(2)]
        [global::System.ComponentModel.DefaultValue("")]
        public string Password { get; set; } = "";

        [global::ProtoBuf.ProtoMember(3)]
        [global::System.ComponentModel.DefaultValue("")]
        public string Barcode { get; set; } = "";

        [global::ProtoBuf.ProtoMember(4)]
        public Status NewStatus { get; set; } = Status.Unknown;

        [global::ProtoBuf.ProtoMember(5)]
        [global::System.ComponentModel.DefaultValue("")]
        public string Description { get; set; } = "";

        [global::ProtoBuf.ProtoMember(6)]
        public RetCode ReturnCode { get; set; } = RetCode.Success;

        [global::ProtoBuf.ProtoMember(7)]
        [global::System.ComponentModel.DefaultValue("")]
        public string CallbackMessage { get; set; } = "";

        public ServerRequest(string login, string password, string barcode, Status newStatus, string description)
        {
            this.Login = Encoding.ASCII.GetString(Encoding.Default.GetBytes(login));
            this.Password = Encoding.ASCII.GetString(Encoding.Default.GetBytes(password));
            this.Barcode = Encoding.ASCII.GetString(Encoding.Default.GetBytes(barcode));
            this.NewStatus = newStatus;
            this.Description = Encoding.ASCII.GetString(Encoding.Default.GetBytes(description));
        }

        public ServerRequest(string login, string password) : this(login, password, "", Status.Unknown, "") { }

        public ServerRequest() : this("", "") { }
    }
}
