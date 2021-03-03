namespace ZenLib.Tests.Network
{
    using System.Diagnostics.CodeAnalysis;
    using ZenLib;
    using static ZenLib.Language;

    [ExcludeFromCodeCoverage]
    public struct sPacket
    {
        public EthHeader EthHeader;

        public IpHeader IpHeader;

        public UdpHeader UdpHeader;

        public static Zen<sPacket> Create(
            Zen<EthHeader> ethHeader,
            Zen<IpHeader> ipHeader,
            Zen<UdpHeader> udpHeader)
        {
            return Language.Create<sPacket>(
                ("EthHeader", ethHeader),
                ("IpHeader", ipHeader),
                ("UdpHeader",udpHeader));
        }
    }

    static class sPacketExtensions
    {
        public static Zen<EthHeader> GetEthHeader(this Zen<sPacket> packet)
        {
            return packet.GetField<sPacket, EthHeader>("EthHeader");
        }

        public static Zen<IpHeader> GetIpHeader(this Zen<sPacket> packet)
        {
            return packet.GetField<sPacket, IpHeader>("IpHeader");
        }

        public static Zen<UdpHeader> GetUdpHeader(this Zen<sPacket> packet)
        {
            return packet.GetField<sPacket, UdpHeader>("UdpHeader");
        }
    }
}