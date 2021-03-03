namespace ZenLib.Tests.Network
{
    using System.Diagnostics.CodeAnalysis;
    using ZenLib;
    using static ZenLib.Language;

    public class VxlanPacket
    {
        public EthHeader OverlayEthHeader;

        public VxlanOuter UnderlayHeader;

        public static Zen<VxlanPacket> Create(
            Zen<EthHeader> overlayHeader,
            Zen<VxlanOuter> underlayHeader)
        {
            return Language.Create<VxlanPacket>(
                ("OverlayHeader",overlayHeader),
                ("UnderlayHeader",underlayHeader));
        }
    }

    static class VxlanPacketExtensions
    {
        public static Zen<EthHeader> GetOverlayHeader(this Zen<VxlanPacket> vpkt)
        {
            return vpkt.GetField<VxlanPacket,EthHeader>("OverlayHeader");
        }

        public static Zen<VxlanOuter> GetUnderlayHeader(this Zen<VxlanPacket> vpkt)
        {
            return vpkt.GetField<VxlanPacket,VxlanOuter>("UnderlayHeader");
        }
    }
}