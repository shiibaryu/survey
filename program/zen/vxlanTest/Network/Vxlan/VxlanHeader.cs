namespace ZenLib.Tests.Network
{
    using System;
    using ZenLib;
    using static ZenLib.Language;

    //simple vxlan header class
    public class VxlanHeader
    {
        byte Flags;

        UInt24 Rsvd1;

        UInt24 VNID;

        byte Rsvd2;

        public static Zen<VxlanHeader> Create(Zen<byte> flags, Zen<UInt24> rsvd1, Zen<UInt24> vnid, Zen<byte> rsvd2){
                return Language.Create<VxlanHeader>(
                    ("Flags",flags),
                    ("Rsvd1",rsvd1),
                    ("VNID",vnid),
                    ("Rsvd2",rsvd2));
        }

        public override string ToString()
        {
            return $"header(flags={Flags}, vnid={VNID})";
        }
    }

    static class VxlanHeaderExtensions
    {
        public static Zen<byte> GetFlags(this Zen<VxlanHeader> hdr)
        {
            return hdr.GetField<VxlanHeader,byte>("Flags");
        }

        public static Zen<UInt24> GetVNID(this Zen<VxlanHeader> hdr)
        {
            return hdr.GetField<VxlanHeader,UInt24>("VNID");
        }
    }

    
}