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
                    return new TCP(tcpPayloadPacket.SequenceNumber, tcpPayloadPacket.AcknowledgmentNumber, tcpPayloadPacket.WindowSize, tcpPayloadPacket.Flags, type, tcpPayloadPacket.SourcePort, tcpPayloadPacket.DestinationPort);

                case ProtocolType.Udp:
                    UdpPacket udpPayloadPacket = (UdpPacket)data;
                    return new UDP(udpPayloadPacket.Checksum, type, udpPayloadPacket.SourcePort, udpPayloadPacket.DestinationPort);

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
                        return new IPv4<Payload>(ipv4packet.Id, ipv4packet.TimeToLive, ipv4packet.Version, ipv4packet.SourceAddress, ipv4packet.DestinationAddress, ipv4packet.TotalPacketLength, ipv4packet.PayloadLength, ipv4payload);
                    }

                    return null;
                case EthernetType.IPv6:
                    IPv6Packet ipv6packet = (IPv6Packet)data.PayloadPacket;

                    Payload? ipv6payload = MakePayload(ipv6packet.Protocol, (TransportPacket)ipv6packet.PayloadPacket);
                    if (ipv6payload != null)
                    {
                        return new IPv6<Payload>(ipv6packet.TrafficClass, ipv6packet.HopLimit, ipv6packet.Version, ipv6packet.SourceAddress, ipv6packet.DestinationAddress, ipv6packet.TotalPacketLength, ipv6packet.PayloadLength, ipv6payload);
                    }

                    return null;
                default:
                    return null;
            }
        }
    }
}
