
using TheSimplestSniffer.Classes;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

namespace TheSimplestSniffer
{
    public static class App
    {
        public static void Run()
        {
            Console.WriteLine("Dispositivos disponíveis para captura:");
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            int index = 0;
            foreach (LibPcapLiveDevice dev in devices)
            {
                Console.WriteLine($"{++index}) {dev.Description}");
            }

            Console.WriteLine();
            Console.WriteLine("Selecione um dispositivo:");

            var lineReaded = Console.ReadLine();

            int deviceIndex;
            if (Int32.TryParse(lineReaded, out deviceIndex) && deviceIndex > 0 && deviceIndex <= devices.Count)
            {
                Console.Clear();

                LibPcapLiveDevice device = devices[--deviceIndex];
                Console.WriteLine(device.Description);
                Console.WriteLine();

                device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);

                int readTimeoutMilliseconds = 1000;
                device.Open(DeviceModes.Promiscuous, readTimeoutMilliseconds);

                if (device.Opened)
                {
                    device.Capture();
                }
                else
                {
                    Console.WriteLine("Não foi possível utilizar este dispositivo");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Dispositivo inválido");
            }
        }

        private static void Device_OnPacketArrival(object s, PacketCapture e)
        {
            try
            {
                var rawPacket = e.GetPacket();
                var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

                if (packet != null)
                {
                    var protocol = Make.MakeProtocol((EthernetPacket)packet);
                    if (protocol != null)
                    {
                        Console.WriteLine(protocol);
                    }
                }
            }
            catch { }
        }
    }
}