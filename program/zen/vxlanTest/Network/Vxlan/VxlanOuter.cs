namespace ZenLib.Tests.Network
{
    using System.Diagnostics.CodeAnalysis;
    using ZenLib;
    using static ZenLib.Language;

    public class VxlanOuter
    {
        public sPacket OuterPacketHeader;

        public VxlanHeader VxlanHeader;

        public static Zen<VxlanOuter> Create(
            Zen<sPacket> outerPacketHeader,
            Zen<VxlanHeader> vxlanHeader)
        {
            return Language.Create<VxlanOuter>(
                ("OuterPacketHeader",outerPacketHeader),
                ("VxlanHeader",vxlanHeader));
        }
    }

    static class VxlanOuterExtensions
    {
        public static Zen<sPacket> GetOuterHeader(this Zen<VxlanPacket> vpkt)
        {
            return vpkt.GetField<VxlanPacket,sPacket>("OuterHeader");
        }

        public static Zen<VxlanHeader> GetVxlanHeader(this Zen<VxlanPacket> vpkt)
        {
            return vpkt.GetField<VxlanPacket,VxlanHeader>("VxlanHeader");
        }
    }
}