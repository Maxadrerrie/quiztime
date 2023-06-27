using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubQuiz
{
    public class Id
    {
        public static int nieuwID()
        {
            var startupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var SavedIDPath = Path.Combine(startupPath, "id.txt");

            if (!File.Exists(SavedIDPath))
                File.WriteAllText(SavedIDPath, "");

            var StringID = File.ReadAllText(SavedIDPath);

            if (string.IsNullOrEmpty(StringID))
            {
                File.WriteAllText(SavedIDPath, "1");
                return 1;
            }

            var ID = int.Parse(StringID);
            ID = ID + 1;
            File.WriteAllText(SavedIDPath, ID.ToString());
            return ID;
        }
    }
}
