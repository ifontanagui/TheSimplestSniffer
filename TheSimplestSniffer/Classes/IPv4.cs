using PacketDotNet;
using System.Net;
using System.Text;


namespace TheSimplestSniffer.Classes
{
    internal class IPv4<T> : Protocol<T> where T : Payload
    {
        public ushort Identifier { get; set; }
        public int TimeToLive { get; set; }


        public IPv4(ushort identifier, int timeToLive, IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress, int packetLength, ushort payloadLength, T payload) 
            : base(version, sourceAddress, destinationAddress, packetLength, payloadLength, payload)
        {
            Identifier = identifier;
            TimeToLive = timeToLive;
        }


        public override string ToString()
        {
            const int colLength = 50;
            StringBuilder sb = new StringBuilder();

            sb.Append('#', 48);
            sb.Append($" {Version} ");
            sb.Append('#', 48);
            sb.AppendLine();

            sb.Append(base.ToString());

            sb.AppendLine($"{$"Identifier".PadLeft(colLength)} - {Identifier.ToString()}");
            sb.AppendLine($"{$"TimeToLive".PadLeft(colLength)} - {TimeToLive.ToString()}");


            sb.AppendLine("Payload".PadLeft(54));
            sb.AppendLine(Payload.ToString());

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
