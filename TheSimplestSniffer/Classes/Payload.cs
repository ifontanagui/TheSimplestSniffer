using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    public abstract class Payload : BaseClass
    {
        public ProtocolType Type { get; set; }
        public ushort SourcePort { get; set; }
        public ushort DestinationPort { get; set; }


        protected Payload(ProtocolType type, ushort sourcePort, ushort destinationPort)
        {
            Type = type;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{$"Type".PadLeft(50)} - {Type.ToString()}");

            return sb.ToString();
        }
    }
}
