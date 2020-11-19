using CodeScaner.Component;
using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CodeScaner.Helpers
{
    public class ChatStyleSelector : DataTemplateSelector
    {
        private DataTemplate incoming;
        private DataTemplate outgoing;

        public ChatStyleSelector()
        {
            incoming = new DataTemplate(typeof(IncomingViewCell));
            outgoing = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as TestMessage;
            if (message == null)
                return null;

            return (message.IsSelf) ? outgoing : incoming;
        }
    }
}
