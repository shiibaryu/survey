namespace ZenLib.Tests.Network
{
    using ZenLib;
    using static ZenLib.Language;

    public class UdpHeader
    {
        public ushort DstPort {get;set;}

        public ushort SrcPort {get;set;}

        //public ushort Length {get;set;}

        //public ushort Checksum {get;set;}

        public static Zen<UdpHeader> Create(Zen<ushort> dstPort, Zen<ushort> srcPort){
                return Language.Create<UdpHeader>(
                    ("DstPort",dstPort),
                    ("SrcPort",srcPort));
        }

        public override string ToString()
        {
            return $"header(src={SrcPort}, dst={DstPort})";
        }
    }

    static class UdpHeaderExtensions
    {
        public static Zen<ushort> GetDstPort(this Zen<UdpHeader> hdr)
        {
            return hdr.GetField<UdpHeader,ushort>("DstPort");
        }

        public static Zen<ushort> GetSrcPort(this Zen<UdpHeader> hdr)
        {
            return hdr.GetField<UdpHeader,ushort>("SrcPort");
        }

	/*
        public static Zen<ushort> GetLength(this Zen<UdpHeader> hdr)
        {
            return hdr.GetField<UdpHeader,ushort>("Length");
        }

        public static Zen<ushort> GetChecksum(this Zen<UdpHeader> hdr)
        {
            return hdr.GetField<UdpHeader,ushort>("Checksum");
        }*/
        
    }
}
