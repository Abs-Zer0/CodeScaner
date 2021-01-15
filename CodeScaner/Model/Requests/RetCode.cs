using System;
using System.Collections.Generic;
using System.Text;

namespace sbc.data
{
    [ProtoBuf.ProtoContract()]
    public enum RetCode
    {
        [ProtoBuf.ProtoEnum(Name = @"SUCCESS")]
        Success = 0,
        [ProtoBuf.ProtoEnum(Name = @"SIGN_IN_ERROR")]
        SignInError = 1,
        [ProtoBuf.ProtoEnum(Name = @"ALREADY_SETTED")]
        AlreadySetted = 2,
        [ProtoBuf.ProtoEnum(Name = @"ERROR")]
        Error = 3,
    }
}
