using System.Collections.Generic;

namespace Content
{
    public class ContentServer : IContentServer
    {
        List<IContentListener> subscribers;
        List<Thread> allMessages;
        public void SSubscribe(IContentListener subscriber)
        {
            subscribers.Add(subscriber);
        }
        public List<Thread> SGetAllMessages()
        {
            return allMessages;
        }
        public void SSendAllMessagesToClient(int userId)
        {
            return;
        }
    }
}
