using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chapter39Notes
{
    public class MessageInABottle
    {
        public void Go()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            string previous;
            try
            {
                // previous = File.ReadAllText(@"C:\Users\david\Desktop\Message.txt");
                FileStream reader = new FileStream(@"C:\Users\david\Desktop\Message.txt", FileMode.Open);
                previous = (string)serializer.Deserialize(reader);
                reader.Close();

                Console.WriteLine("Previous message: ");
                Console.WriteLine(previous);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error:");
                Console.WriteLine(e.Message);
            }
            Console.Write("What do you want me to tell you next time? ");
            string message = Console.ReadLine() ?? "No input detected";

            //File.WriteAllText(@"C:\Users\david\Desktop\Message.txt", message);
            TextWriter writer = new StreamWriter(@"C:\Users\david\Desktop\Message.txt");
            serializer.Serialize(writer, message);
        }
    }
}
