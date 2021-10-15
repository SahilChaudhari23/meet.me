namespace Content
{
    public class ContentServerFactory
    {
        private static IContentServer contentServer;

        public static IContentServer getInstance()
        {
            if (contentServer != null)
            {
                return contentServer;
            }

            contentServer = new ContentServer();
            return contentServer;
        }
    }
}