using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace InnovatorProject.Tests
{
    static class Conf
    {
        public static AppSettings Load(string[] files = default)
        {
            var builder = new ConfigurationBuilder();
            if (files == default)
            {
                files = new string[] { "settings.json" };
            }

            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    throw new Exception($"File {file} doesn't exist.");
                }
                builder.AddJsonFile(file, true, true);
            }

            builder.AddEnvironmentVariables();
            var ret = builder.Build().GetSection("AppSettings").Get<AppSettings>();

            return ret;
        }
    }
}
