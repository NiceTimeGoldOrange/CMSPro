using System.Reflection;

namespace DALFactory
{
    public class TRoom
    {
        public static IDAL.ITRoom Create()
        {
            string path = System.Configuration.ConfigurationSettings.AppSettings["WebDAL"];
            string className = path + ".Account";

            return (IDAL.ITRoom)Assembly.Load(path).CreateInstance(className);
        }
    }
}
