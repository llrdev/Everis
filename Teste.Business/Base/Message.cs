using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Business.Base
{
    public class Message
    {
        public MessageType Code { get; set; }

        public string Description { get; set; }

        public Message() { }

        public Message(MessageType status, string description)
        {
            Code = status;
            Description = description;
        }
    }
}
