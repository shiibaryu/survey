namespace ZenLib.Tests.Network
{
    using System.Net;
    using ZenLib;
    using static ZenLib.Language;

    public class EthHeader
    {
        public string DstEth {get;set;}

        public string SrcEth {get;set;}

        public ushort EthType {get;set;}

        public static Zen<EthHeader> Create(Zen<string> dstEth, Zen<string> srcEth, Zen<ushort> ethType){
                return Language.Create<EthHeader>(
                    ("DstEth",dstEth),
                    ("SrcEth",srcEth),
                    ("EthType",ethType));
        }

        public override string ToString()
        {
            return $"header(src={SrcEth}, dst={DstEth}, type={EthType})";
        }
    }

    static class EthHeaderExtensions
    {
        public static Zen<string> GetDstEth(this Zen<EthHeader> hdr)
        {
            return hdr.GetField<EthHeader,string>("DstEth");
        }

        public static Zen<string> GetSrcEth(this Zen<EthHeader> hdr)
        {
            return hdr.GetField<EthHeader,string>("SrcEth");
        }

        public static Zen<ushort> GetEthType(this Zen<EthHeader> hdr)
        {
            return hdr.GetField<EthHeader,ushort>("EthType");
        }
    }
}