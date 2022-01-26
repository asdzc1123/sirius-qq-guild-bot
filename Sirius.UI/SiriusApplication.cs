using Sirius.CoreCSharp;
using Sirius.UI.Models;
using Sirius.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.UI
{
    internal class SiriusApplication
    {
        private static readonly string dataJsonFileName = "data.json";

        private static readonly LocalData localData;

        public static Bot Bot { get; } = new();

        public static BotEvents BotEvents { get => localData.BotEvents; }

        public static BotAccount BotAccount { get => localData.BotAccount; }

        static SiriusApplication()
        {
            if (File.Exists(dataJsonFileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(dataJsonFileName);
                    localData = Util.JsonDecode<LocalData>(jsonString)!;
                }
                catch (Exception)
                {
                    localData = new();
                    File.WriteAllText(dataJsonFileName, Util.JsonEncode(localData));
                }
            }
            else
            {
                localData = new();
                File.WriteAllText(dataJsonFileName, Util.JsonEncode(localData));
            }

        }

        public static void UpdateLocalData()
        {
            File.WriteAllText(dataJsonFileName, Util.JsonEncode(localData));
        }

        private class LocalData
        {
            public BotAccount BotAccount { get; set; } = new();

            public BotEvents BotEvents { get; set; } = new();


        }
    }
}
