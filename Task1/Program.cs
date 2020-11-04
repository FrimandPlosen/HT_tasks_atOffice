using System;
using System.IO;
using Newtonsoft.Json;

namespace Task1
{
    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Program
    {

        static public void SerialiseJson()
        {
            Participant participant = null;

            var pathToJson = Path.Combine(Directory.GetCurrentDirectory());
            
            if (File.Exists(pathToJson + "\\Participant.json"))
            {
                using (StreamReader readJson = File.OpenText(pathToJson + "\\Participant.json"))
                {
                    JsonSerializer deserialise = new JsonSerializer();

                    participant = (Participant)deserialise.Deserialize(readJson, typeof(Participant));

                    participant.FirstName = "Asbjørn";
                    participant.LastName = "Løvlie Meyer";
                }
            }
            else
            {
                Console.WriteLine("The Participant.json file does not exist");
            }

            if (participant != null)
            {
                using (StreamWriter writeJson = File.CreateText(pathToJson + "\\Participant_edited.json"))
                {
                    JsonSerializer serialise = new JsonSerializer();

                    serialise.Serialize(writeJson, participant);
                }
            }
            else
            {
                Console.WriteLine("Participant object is empty, did not write to file");
            }

        }

        static void Main(string[] args)
        {
            SerialiseJson();
        }
    }
}
