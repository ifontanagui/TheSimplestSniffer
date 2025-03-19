using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    internal class TCP : Payload
    {
        public uint SequenceNumber { get; set; }
        public uint AcknowledgmentNumber { get; set; }
        public ushort WindowSize { get; set; }
        public byte[] flagsArray { get; set; }


        public TCP(uint sequenceNumber, uint acknowledgmentNumber, ushort windowSize, ushort flags, ProtocolType type, ushort sourcePort, ushort destinationPort) : base(type, sourcePort, destinationPort)
        {
            SequenceNumber = sequenceNumber;
            AcknowledgmentNumber = acknowledgmentNumber;
            WindowSize = windowSize;

            flagsArray = [0, 0, 0, 0, 0, 0];
            int index = 0;
            foreach (char flag in Convert.ToString(flags, 2).Reverse().ToArray<char>())
            {
                flagsArray[index++] = (byte)(flag == '1' ? 1 : 0);
            }
        }


        public override string ToString()
        {
            const int colLength = 50;
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            
            sb.AppendLine($"{$"SequenceNumber".PadLeft(colLength)} - {SequenceNumber.ToString()}");
            sb.AppendLine($"{$"AcknowledgmentNumber".PadLeft(colLength)} - {AcknowledgmentNumber.ToString()}");
            sb.AppendLine($"{$"WindowSize".PadLeft(colLength)} - {WindowSize.ToString()}");

            sb.AppendLine($"{$"Flags".PadLeft(colLength)}");
            sb.AppendLine($"{$"Ugent".PadLeft(colLength)} - {flagsArray[5].ToString()}");
            sb.AppendLine($"{$"Acknowledgment".PadLeft(colLength)} - {flagsArray[4].ToString()}");
            sb.AppendLine($"{$"Push".PadLeft(colLength)} - {flagsArray[3].ToString()}");
            sb.AppendLine($"{$"Reset".PadLeft(colLength)} - {flagsArray[2].ToString()}");
            sb.AppendLine($"{$"Syn".PadLeft(colLength)} - {flagsArray[1].ToString()}");
            sb.AppendLine($"{$"Fin".PadLeft(colLength)} - {flagsArray[0].ToString()}");

            return sb.ToString();
        }
    }
}
