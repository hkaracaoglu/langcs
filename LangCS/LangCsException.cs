
namespace LangCSManager
{
    internal class LangCsException
    {
       
        internal static string PathIsNull()
        {
            return
                "Path value not found on config file. If you did added to config file please check key name. Key name should be 'langCSPath'";
        }
    }

    
}
