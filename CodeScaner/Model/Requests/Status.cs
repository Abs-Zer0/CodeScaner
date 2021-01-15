using System;
using System.Collections.Generic;
using System.Text;

namespace sbc.data
{
    [ProtoBuf.ProtoContract()]
    public enum Status
    {
        [ProtoBuf.ProtoEnum(Name = @"PROCESSING")]
        Processing = 0,
        [ProtoBuf.ProtoEnum(Name = @"SEND")]
        Send = 1,
        [ProtoBuf.ProtoEnum(Name = @"TRAVEL")]
        Travel = 2,
        [ProtoBuf.ProtoEnum(Name = @"RECEIVE")]
        Receive = 3,
        [ProtoBuf.ProtoEnum(Name = @"LOST")]
        Lost = 4,
        [ProtoBuf.ProtoEnum(Name = @"OTHER")]
        Other = 5,
        [ProtoBuf.ProtoEnum(Name = @"UNKNOWN")]
        Unknown = 6,
    }
}
