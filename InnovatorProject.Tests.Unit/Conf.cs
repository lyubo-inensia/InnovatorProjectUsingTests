using Newtonsoft.Json;
using System.IO;

namespace InnovatorProject.Tests.Unit
{
    static class Conf
    {
        public static AppSettings Load(string file = "settings.json")
        {
            return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(file));
        }
    }
}
