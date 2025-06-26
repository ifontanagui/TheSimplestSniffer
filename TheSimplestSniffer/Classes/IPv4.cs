using PacketDotNet;
using System.Net;
using System.Text;


namespace TheSimplestSniffer.Classes
{
    internal class IPv4<T> : Protocol<T> where T : Payload
    {
        public int HeaderLength {  get; set; }
        public int TypeOfService {  get; set; }
        public int TotalLength {  get; set; }
        public ushort Identifier { get; set; }
        public int FragmentOffset {  get; set; }
        public int TimeToLive { get; set; }
        public ProtocolType Protocol { get; set; }
        public ushort HeaderChecksum { get; set; }
        public byte[] FragmentFlagsArray { get; set; }

        public IPv4(IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress,
                    int headerLength, int typeOfService, int totalLength, ushort identifier, int fragmentOffset, int timeToLive, ProtocolType protocol, ushort headerChecksum, int flags,
                    T payload)
            : base(version, sourceAddress, destinationAddress, payload)
        {
            HeaderLength = headerLength;
            TypeOfService = typeOfService;
            TotalLength = totalLength;
            Identifier = identifier;
            FragmentOffset = fragmentOffset;
            TimeToLive = timeToLive;
            Protocol = protocol;
            HeaderChecksum = headerChecksum;

            FragmentFlagsArray = [0, 0, 0];
            int index = 0;
            foreach (char flag in Convert.ToString(flags, 2).Reverse().ToArray<char>())
            {
                FragmentFlagsArray[index++] = (byte)(flag == '1' ? 1 : 0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('#', colLength-2);
            sb.Append($" {this.Version} ");
            sb.Append('#', colLength-2);
            sb.AppendLine();

            sb.Append(base.ToString());

            sb.AppendLine($"{$"IHL".PadLeft(colLength)} - {this.HeaderLength.ToString()}");
            sb.AppendLine($"{$"TOS".PadLeft(colLength)} - {this.TypeOfService.ToString()}");
            sb.AppendLine($"{$"TotalLength".PadLeft(colLength)} - {this.TotalLength.ToString()}");
            sb.AppendLine($"{$"Identification".PadLeft(colLength)} - {this.Identifier.ToString()}");


            sb.AppendLine($"{$"Flags".PadLeft(colLength)}");
            sb.AppendLine($"{$"Reserved".PadLeft(colLength)} - {FragmentFlagsArray[2].ToString()}");
            sb.AppendLine($"{$"Don't Fragment".PadLeft(colLength)} - {FragmentFlagsArray[1].ToString()}");
            sb.AppendLine($"{$"More Fragments".PadLeft(colLength)} - {FragmentFlagsArray[0].ToString()}");

            sb.AppendLine($"{$"Fragment Offset".PadLeft(colLength)} - {this.FragmentOffset.ToString()}");
            sb.AppendLine($"{$"TTL".PadLeft(colLength)} - {this.TimeToLive.ToString()}");
            sb.AppendLine($"{$"Checksum".PadLeft(colLength)} - {this.HeaderChecksum.ToString()}");
            sb.AppendLine($"{$"Protocol".PadLeft(colLength)} - {this.HeaderLength.ToString()}");


            sb.AppendLine("Payload".PadLeft(colLength+4));
            sb.AppendLine(Payload.ToString());

            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
