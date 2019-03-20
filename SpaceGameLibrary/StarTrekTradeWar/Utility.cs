using Newtonsoft.Json;
using System;
using System.IO;

namespace StarTrekTradeWar
{
    public class Utility
    {
        public static double WarpSpeedToLightSpeed(double w)
        {
            if (w <= 0 || w > 9.6) throw new ArgumentOutOfRangeException("Wrap factor too crazy!");

            return Math.Pow(w, 10.0 / 3) + Math.Pow(10 - w, -11.0 / 3);
        }

        public static double WarpSpeedToFuelConsumptionPerLY(double w)
        {
            if (w <= 0 || w > 9.6) throw new ArgumentOutOfRangeException("Wrap factor too crazy!");

            return Math.Pow(w, 2)/100.0;
        }


        public static ConsoleKey PromptForInput(string prompt = ">")
        {
            var cursorLeftPos = Console.CursorLeft;
            var cursorTopPos = Console.CursorTop;

            Console.SetCursorPosition(0, Console.WindowHeight-1);
            Console.Write(prompt);

            Console.SetCursorPosition(cursorLeftPos,cursorTopPos);

            return Console.ReadKey(true).Key;
        }




        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}