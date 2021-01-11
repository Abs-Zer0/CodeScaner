using CodeScaner.Model.Responses;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    [ProtoContract]
    public class ServerResponse
    {
        [ProtoMember(1)]
        public ResponseType Type { get; set; }
        [ProtoMember(2)]
        public string Description { get; set; }
    }
}
