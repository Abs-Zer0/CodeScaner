using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    [ProtoContract]
    public class Terminal
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public TerminalType Type { get; set; }
    }

    public enum TerminalType
    {
        MOBILE, DESKTOP, MICROCONTROLLER
    }
}
