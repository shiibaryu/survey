namespace ZenLib.Tests.Network
{
    using System;
    using System.Net;
    using System.IO;
    using System.Text;
    using ZenLib;
    using static ZenLib.Language;

    public struct Udp
    {
        public UdpHeader Header {get;set;}

        public static Zen<Udp> Create(Zen<UdpHeader> hdr)
        {
            return Language.Create<Udp>(("Header",hdr));   
        }
    }
    
     static class UdpExtensions
    {
        public static Zen<UdpHeader> GetHeader(this Zen<Udp> udp)
        {
            return udp.GetField<Udp,UdpHeader>("Header");
        }
    }
}