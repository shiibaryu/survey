namespace ZenLib.Tests.Network
{
    using System;
    using System.Net;
    using System.IO;
    using ZenLib;
    using static ZenLib.Language;

    public struct Eth
    {
        public EthHeader Header {get;set;}

        public static Zen<Eth> Create(Zen<EthHeader> value)
        {
            return Language.Create<Eth>(("Header",value));   
        }
    }

     static class EthExtensions
    {
        public static Zen<EthHeader> GetHeader(this Zen<Eth> eth)
        {
            return eth.GetField<Eth,EthHeader>("Header");
        }
    }
}