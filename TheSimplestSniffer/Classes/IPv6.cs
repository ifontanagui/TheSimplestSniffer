using PacketDotNet;
using System.Net;
using System.Text;


namespace TheSimplestSniffer.Classes
{
    internal class IPv6<T> : Protocol<T> where T : Payload
    {
        public int TrafficClass { get; set; }
        public int FlowLabel { get; set; }
        public ushort PayloadLength { get; set; }
        public ProtocolType NextHeader { get; set; }
        public int HopLimit { get; set; }


        public IPv6(IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress, int trafficClass, int flowLabel, ushort payloadLength, ProtocolType nextHeader, int hopLimit, T payload)
            : base(version, sourceAddress, destinationAddress, payload)
        {
            TrafficClass = trafficClass;
            FlowLabel = flowLabel;
            PayloadLength = payloadLength;
            NextHeader = nextHeader;
            HopLimit = hopLimit;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('#', colLength-2);
            sb.Append($" {Version} ");
            sb.Append('#', colLength-2);
            sb.AppendLine();

            sb.Append(base.ToString());

            sb.AppendLine($"{$"TrafficClass".PadLeft(colLength)} - {this.TrafficClass.ToString()}");
            sb.AppendLine($"{$"FlowLabel".PadLeft(colLength)} - {this.FlowLabel.ToString()}");
            sb.AppendLine($"{$"PayloadLength".PadLeft(colLength)} - {this.PayloadLength.ToString()}");
            sb.AppendLine($"{$"NextHeader".PadLeft(colLength)} - {this.NextHeader.ToString()}");
            sb.AppendLine($"{$"HopLimit".PadLeft(colLength)} - {this.HopLimit.ToString()}");

            sb.AppendLine("Payload".PadLeft(colLength+4));
            sb.AppendLine(Payload.ToString());

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
