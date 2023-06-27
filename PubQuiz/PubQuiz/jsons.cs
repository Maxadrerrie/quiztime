using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubQuiz
{
    internal class jsons
    {
        public static void vragenOpslaan(List<vragen> argListSavedData)
        {
            var SavedDataFilePath = vragenWeg();

            var JSON = JsonConvert.SerializeObject(argListSavedData, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(SavedDataFilePath, JSON);
        }
        public static string vragenWeg()
        {
            var startupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var SavedCompanyMarges = Path.Combine(startupPath, "vragen.SavedData.json");
            return SavedCompanyMarges;
        }
        public static List<vragen> LeesVragen()
        {
            try
            {
                var SavedDataFilePath = vragenWeg();

                var JSON = File.ReadAllText(SavedDataFilePath);
                var DeserializedSavedDataFileList = JsonConvert.DeserializeObject<List<vragen>>(JSON);

                return DeserializedSavedDataFileList;
            }
            catch (Exception ex)
            {
                return new List<vragen>();
            }
        }


        public static void quizOpslaan(List<quizes> argListSavedData)
        {
            var SavedDataFilePath = quizWeg();

            var JSON = JsonConvert.SerializeObject(argListSavedData, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(SavedDataFilePath, JSON);
        }
        public static string quizWeg()
        {
            var startupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var SavedCompanyMarges = Path.Combine(startupPath, "quizes.SavedData.json");
            return SavedCompanyMarges;
        }
        public static List<quizes> quizLezen()
        {
            try
            {
                var SavedDataFilePath = quizWeg();

                var JSON = File.ReadAllText(SavedDataFilePath);
                var DeserializedSavedDataFileList = JsonConvert.DeserializeObject<List<quizes>>(JSON);

                return DeserializedSavedDataFileList;
            }
            catch (Exception ex)
            {
                return new List<quizes>();
            }
        }
        public static string PakFotoFolder()
        {
            var startupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var SavedCompanyMarges = Path.Combine(startupPath, "Fotos");
            if (!Directory.Exists(SavedCompanyMarges))
                Directory.CreateDirectory(SavedCompanyMarges);
            return SavedCompanyMarges;
        }
    }
}
