namespace Content
{
    public class ContentServerFactory
    {
        static IContentServer contentServer;
        static IContentServer getInstance()
        {
            if(contentServer != null)
            {
                return contentServer;
            }

            contentServer = new ContentServer();
            return contentServer;
        }
    }
}