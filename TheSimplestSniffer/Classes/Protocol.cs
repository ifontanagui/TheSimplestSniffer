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
        public T Payload { get; set; }


        protected Protocol(IPVersion version, IPAddress sourceAddress, IPAddress destinationAddress, T payload)
        {
            Version = version;
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Payload = payload;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{$"From Address: {SourceAddress}".PadLeft(colLength)} - To Address: {DestinationAddress}");
            sb.AppendLine($"{$"From Port: {Payload.SourcePort}".PadLeft(colLength)} - To Port: {Payload.DestinationPort}");

            return sb.ToString();
        }

    }
}
