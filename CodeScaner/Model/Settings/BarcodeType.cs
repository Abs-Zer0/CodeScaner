using System;
using System.Collections.Generic;
using System.Text;
using ZXing;

namespace CodeScaner.Model.Settings
{
    public class BarcodeType
    {
        public BarcodeType() : this("", new BarcodeFormat[] { }, true) { }

        public BarcodeType(string name, IEnumerable<BarcodeFormat> formats, bool selected)
        {
            this.Name = name;
            this.Formats = formats;
            this.IsSelect = selected;
        }

        public string Name { get; set; }
        public IEnumerable<BarcodeFormat> Formats { get; set; }
        public bool IsSelect { get; set; }

        public static BarcodeType Barcode => new BarcodeType()
        {
            Name = "Штрих код",
            Formats = new[] { BarcodeFormat.All_1D, BarcodeFormat.MSI, BarcodeFormat.PHARMA_CODE, BarcodeFormat.PLESSEY }
        };

        public static BarcodeType Aztec => new BarcodeType()
        {
            Name = "AZTEC",
            Formats = new[] { BarcodeFormat.AZTEC }
        };

        public static BarcodeType DataMatrix => new BarcodeType()
        {
            Name = "Data Matrix",
            Formats = new[] { BarcodeFormat.DATA_MATRIX }
        };

        public static BarcodeType Imb => new BarcodeType()
        {
            Name = "IMB",
            Formats = new[] { BarcodeFormat.IMB }
        };

        public static BarcodeType Maxicode => new BarcodeType()
        {
            Name = "MAXICODE",
            Formats = new[] { BarcodeFormat.MAXICODE }
        };

        public static BarcodeType Pdf => new BarcodeType()
        {
            Name = "PDF",
            Formats = new[] { BarcodeFormat.PDF_417 }
        };

        public static BarcodeType QR => new BarcodeType()
        {
            Name = "QR код",
            Formats = new[] { BarcodeFormat.QR_CODE }
        };

        public static IEnumerable<BarcodeType> AllCodes => new[] { Barcode, Aztec, DataMatrix, Imb, Maxicode, Pdf, QR };
    }
}
