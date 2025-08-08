using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Messages
{
    public class ClienteSavedMessage : ValueChangedMessage<bool>
    {
        public ClienteSavedMessage(bool value) : base(value) { }
    }
}
