using PacketDotNet;


namespace TheSimplestSniffer.Classes
{
    public static class Make
    {
        private static Payload? MakePayload(ProtocolType type, TransportPacket data)
        {
            switch (type)
            {
                case ProtocolType.Tcp:
                    TcpPacket tcpPayloadPacket = (TcpPacket)data;
                    return new TCP(type, tcpPayloadPacket.SourcePort, tcpPayloadPacket.DestinationPort, tcpPayloadPacket.Checksum, tcpPayloadPacket.SequenceNumber, tcpPayloadPacket.AcknowledgmentNumber, tcpPayloadPacket.DataOffset, tcpPayloadPacket.WindowSize, tcpPayloadPacket.Urgent, tcpPayloadPacket.Flags);

                case ProtocolType.Udp:
                    UdpPacket udpPayloadPacket = (UdpPacket)data;
                    return new UDP(type, udpPayloadPacket.SourcePort, udpPayloadPacket.DestinationPort, udpPayloadPacket.Checksum, udpPayloadPacket.TotalPacketLength);

                default:
                    return null;
            }
        }

        public static Protocol<Payload>? MakeProtocol(EthernetPacket data)
        {
            switch (data.Type)
            {
                case EthernetType.IPv4:
                    IPv4Packet ipv4packet = (IPv4Packet)data.PayloadPacket;

                    Payload? ipv4payload = MakePayload(ipv4packet.Protocol, (TransportPacket)ipv4packet.PayloadPacket);
                    if (ipv4payload != null)
                    {
                        return new IPv4<Payload>(
                            ipv4packet.Version, ipv4packet.SourceAddress, ipv4packet.DestinationAddress,
                            ipv4packet.HeaderLength, ipv4packet.TypeOfService, ipv4packet.TotalLength, ipv4packet.Id, ipv4packet.FragmentOffset, ipv4packet.TimeToLive, ipv4packet.Protocol, ipv4packet.Checksum, ipv4packet.FragmentFlags,
                            ipv4payload
                        );
                    }

                    return null;
                case EthernetType.IPv6:
                    IPv6Packet ipv6packet = (IPv6Packet)data.PayloadPacket;

                    Payload? ipv6payload = MakePayload(ipv6packet.Protocol, (TransportPacket)ipv6packet.PayloadPacket);
                    if (ipv6payload != null)
                    {
                        return new IPv6<Payload>(ipv6packet.Version, ipv6packet.SourceAddress, ipv6packet.DestinationAddress, ipv6packet.TrafficClass, ipv6packet.FlowLabel, ipv6packet.PayloadLength, ipv6packet.NextHeader, ipv6packet.HopLimit, ipv6payload);
                    }

                    return null;
                default:
                    return null;
            }
        }
    }
}
