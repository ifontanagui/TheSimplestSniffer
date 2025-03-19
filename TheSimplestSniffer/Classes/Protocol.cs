using PacketDotNet;
using System.Net;
using System.Text;


namespace TheSimplestSniffer.Classes
{
    public abstract class Protocol<T> : BaseClass where T : Payload
    {
        public IPVersion Version { get; set; }
        public IPAddress SourceAddress { get; set; }
        public IPAddress DestinationAddress { get; set; }
        public int PacketLength { get; set; }
        public ushort PayloadLength { get; set; }
        public T Payload { get; set; }


        public Protocol(IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress, int packetLength, ushort payloadLength, T payload)
        {
            Version = version;
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            PacketLength = packetLength;
            PayloadLength = payloadLength;
            Payload = payload;
        }



        public override string ToString()
        {
            const int colLength = 50;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{$"From: {SourceAddress}:{Payload.SourcePort}".PadLeft(colLength)} - To: {DestinationAddress}:{Payload.DestinationPort}");
            sb.AppendLine($"{$"PacketLength".PadLeft(colLength)} - {PacketLength.ToString()}");
            sb.AppendLine($"{$"PayloadLength".PadLeft(colLength)} - {PayloadLength.ToString()}");

            return sb.ToString();
        }

    }
}
