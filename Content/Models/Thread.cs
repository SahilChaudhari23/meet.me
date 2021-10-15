using System;
using System.Collections.Generic;

namespace Content
{
    public class Thread
    {
        private List<ReceiveMessageData> msgList;
        private int threadId;
        private int numOfMessages;
        private DateTime creationTime;
    }
}