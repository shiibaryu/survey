namespace ZenLib.Tests.Network
{
    using System;
    using ZenLib;
    using static ZenLib.Language;

    //simple vxlan header class
    public struct Vxlan
    {
        public VxlanHeader Header {get;set;}

        public static Zen<Vxlan> Create(Zen<VxlanHeader> hdr)
        {
            return Language.Create<Vxlan>(("Header",hdr));   
        }
    }

    static class VxlanExtensions
    {
        public static Zen<VxlanHeader> GetHeader(this Zen<Vxlan> vxlan)
        {
            return vxlan.GetField<Vxlan,VxlanHeader>("Header");
        }
    }   
}