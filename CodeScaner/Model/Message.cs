using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    [ProtoContract]
    public class Message
    {
        [ProtoMember(1)]
        public Terminal Term { get; set; }

        [ProtoMember(2)]
        public string Login { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; }

        [ProtoMember(4)]
        public Barcode barcode { get; set; }


        [ProtoMember(5)]
        public MessageCommand Command { get; set; }

        [ProtoMember(6)]
        public string AnotherData { get; set; }
    }

    public enum MessageCommand
    {
        RECEIVE, SEND, STATUS
    }
}
