using Newtonsoft.Json;
using System.IO;

namespace InnovatorProject.Tests.Unit
{
    static class Conf
    {
        public static AppSettings Load(string file = "settings.json")
        {
            var ret = new AppSettings();
            try
            {
                ret = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(file));
            }
            catch { }

            return ret;
        }
    }
}
