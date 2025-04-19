using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    public abstract class Payload : BaseClass
    {
        public ProtocolType Type { get; set; }
        public ushort SourcePort { get; set; }
        public ushort DestinationPort { get; set; }
        public ushort Checksum { get; set; }


        protected Payload(ProtocolType type, ushort sourcePort, ushort destinationPort, ushort checksum)
        {
            Type = type;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
            Checksum = checksum;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{$"Type".PadLeft(colLength)} - {Type.ToString()}");

            return sb.ToString();
        }
    }
}
