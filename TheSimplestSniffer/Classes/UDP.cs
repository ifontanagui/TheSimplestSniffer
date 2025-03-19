using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    internal class UDP : Payload
    {        
        public ushort Checksum { get; set; }


        public UDP(ushort checksum, ProtocolType type, ushort sourcePort, ushort destinationPort) : base(type, sourcePort, destinationPort)
        {
            Checksum = checksum;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine($"{$"Checksum".PadLeft(50)} - {Checksum.ToString()}");

            return sb.ToString();
        }
    }
}
