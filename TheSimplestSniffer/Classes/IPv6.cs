using PacketDotNet;
using System.Net;
using System.Text;


namespace TheSimplestSniffer.Classes
{
    internal class IPv6<T> : Protocol<T> where T : Payload
    {
        public int TrafficClass { get; set; }
        public int HopLimit { get; set; }


        public IPv6(int trafficClass, int hopLimit, IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress, int packetLength, ushort payloadLength, T payload)
            : base(version, sourceAddress, destinationAddress, packetLength, payloadLength, payload)
        {
            TrafficClass = trafficClass;
            HopLimit = hopLimit;
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

            sb.AppendLine($"{$"TrafficClass".PadLeft(colLength)} - {TrafficClass.ToString()}");
            sb.AppendLine($"{$"HopLimit".PadLeft(colLength)} - {HopLimit.ToString()}");

            sb.AppendLine("Payload".PadLeft(54));
            sb.AppendLine(Payload.ToString());

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
