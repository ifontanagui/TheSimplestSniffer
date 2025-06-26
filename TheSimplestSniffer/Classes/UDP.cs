using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    internal class UDP : Payload
    {        
        public int Length { get; set; }


        public UDP(ProtocolType type, ushort sourcePort, ushort destinationPort, ushort checksum, int length)
            : base(type, sourcePort, destinationPort, checksum)
        {
            Length = length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            sb.AppendLine($"{$"Length".PadLeft(colLength)} - {this.Length.ToString()}");
            sb.AppendLine($"{$"Checksum".PadLeft(colLength)} - {this.Checksum.ToString()}");

            return sb.ToString();
        }
    }
}
