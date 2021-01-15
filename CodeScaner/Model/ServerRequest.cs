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

        private ServerRequest(string log, string passwd, string code, Status stat, string desc, RetCode ret, string callback)
        {
            this.Login = Encoding.ASCII.GetString(Encoding.Default.GetBytes(log));
            this.Password = Encoding.ASCII.GetString(Encoding.Default.GetBytes(passwd));
            this.Barcode = Encoding.ASCII.GetString(Encoding.Default.GetBytes(code));
            this.NewStatus = stat;
            this.Description = Encoding.ASCII.GetString(Encoding.Default.GetBytes(desc));
            this.ReturnCode = ret;
            this.CallbackMessage = Encoding.ASCII.GetString(Encoding.Default.GetBytes(callback));
        }

        public ServerRequest(string login, string password, string barcode, Status newStatus, string description)
            : this(login, password, barcode, newStatus, description, RetCode.Success, "") { }

        public ServerRequest(string login, string password) : this(login, password, "", Status.Unknown, "") { }

        public ServerRequest() : this("", "") { }
    }
}
