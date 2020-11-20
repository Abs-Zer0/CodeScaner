using System;
using System.Collections.Generic;
using System.Text;

namespace CodeScaner.Model
{
    public class TestMessage
    {
        public string Text { get; set; }
        public bool IsSelf { get; set; }

        public TestMessage(string txt, bool isSelf = true)
        {
            Text = txt;
            IsSelf = isSelf;
        }
    }
}
