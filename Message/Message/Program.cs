using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Message
{
    //[XmlRoot("Message")]
    public class Message
    {
        
        int commandID;
        int commandSize;
        string text;

        public Message(int commandID, int commandSize, string text)
        {
            this.commandID = commandID;
            this.commandSize = commandSize;
            this.text = text;
        }
        public Message()
        {
            this.commandID = 0;
            this.commandSize = 0;
            this.text = "";
        }
        

        [XmlAttribute("cmd_id")]
        public int CommandID
        {
            get { return commandID; }
            set { commandID = value; }
        }
        [XmlAttribute("cmd_size")]
        public int CommandSize
        {
            get { return commandSize; }
            set { commandSize = value; }
        }
        

        [XmlElement("text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Message message = new Message(1, 3, "qwe");
            //message.CommandID = 1;
            //message.CommandSize = 3;
            //message.Text = "qwe";

            XmlSerializer serializer = new XmlSerializer(typeof(Message));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, message);

            Console.WriteLine("Message: {0}", writer);

            StringReader reader = new StringReader(writer.ToString());

            Message message2 = (Message)serializer.Deserialize(reader);
            Console.WriteLine(message2.ToString());
        }
    }
}
