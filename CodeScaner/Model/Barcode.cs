using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    [ProtoContract]
    public class Barcode
    {
        [ProtoMember(1)]
        public string Val { get; set; }

        [ProtoMember(2)]
        public ZXing.BarcodeFormat Format { get; set; }

    }
}
