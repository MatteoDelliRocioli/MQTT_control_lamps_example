using System;
using System.Collections.Generic;
using System.Text;

namespace message_service
{
    public interface IMessageService <TMessage> //Generic Interface
    {
        //connect
        void Connect();

        //send
        void Send(TMessage message);
    }
}
