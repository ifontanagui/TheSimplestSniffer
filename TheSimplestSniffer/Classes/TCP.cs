using PacketDotNet;
using System.Text;

namespace TheSimplestSniffer.Classes
{
    internal class TCP : Payload
    {
        public uint SequenceNumber { get; set; }
        public uint AcknowledgmentNumber { get; set; }
        public int DataOffset { get; set; }
        public ushort WindowSize { get; set; }
        public bool Urgent { get; set; }
        public byte[] FlagsArray { get; set; }

        public TCP(ProtocolType type, ushort sourcePort, ushort destinationPort, ushort checksum,
                   uint sequenceNumber, uint acknowledgmentNumber, int dataOffset, ushort windowSize, bool urgent, ushort flags)
            : base(type, sourcePort, destinationPort, checksum)
        {
            SequenceNumber = sequenceNumber;
            AcknowledgmentNumber = acknowledgmentNumber;
            DataOffset = dataOffset;
            WindowSize = windowSize;
            Urgent = urgent;

            FlagsArray = [0, 0, 0, 0, 0, 0];
            int index = 0;
            foreach (char flag in Convert.ToString(flags, 2).Reverse().ToArray<char>())
            {
                FlagsArray[index++] = (byte)(flag == '1' ? 1 : 0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            
            sb.AppendLine($"{$"SequenceNumber".PadLeft(colLength)} - {SequenceNumber.ToString()}");
            sb.AppendLine($"{$"AcknowledgmentNumber".PadLeft(colLength)} - {AcknowledgmentNumber.ToString()}");
            sb.AppendLine($"{$"DataOffset".PadLeft(colLength)} - {DataOffset.ToString()}");
            sb.AppendLine($"{$"WindowSize".PadLeft(colLength)} - {WindowSize.ToString()}");
            sb.AppendLine($"{$"Checksum".PadLeft(colLength)} - {Checksum.ToString()}");
            sb.AppendLine($"{$"Urgent Pointer".PadLeft(colLength)} - {(Urgent ? '1' : '0')}");

            sb.AppendLine($"{$"Flags".PadLeft(colLength)}");
            sb.AppendLine($"{$"Ugent".PadLeft(colLength)} - {FlagsArray[5].ToString()}");
            sb.AppendLine($"{$"Acknowledgment".PadLeft(colLength)} - {FlagsArray[4].ToString()}");
            sb.AppendLine($"{$"Push".PadLeft(colLength)} - {FlagsArray[3].ToString()}");
            sb.AppendLine($"{$"Reset".PadLeft(colLength)} - {FlagsArray[2].ToString()}");
            sb.AppendLine($"{$"Syn".PadLeft(colLength)} - {FlagsArray[1].ToString()}");
            sb.AppendLine($"{$"Fin".PadLeft(colLength)} - {FlagsArray[0].ToString()}");

            return sb.ToString();
        }
    }
}
