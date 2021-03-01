using System;
using ZenLib;
using static ZenLib.Language;

public class Packet
{
    // packet destination ip
    public uint DstIp { get; set; }
    // packet source ip
    public uint SrcIp { get; set; }
}

// define helper extension methods for manipulating packets.
public static class PacketExtensions
{
    public static Zen<uint> GetDstIp(this Zen<Packet> packet)
    {
        return packet.GetField<Packet, uint>("DstIp");
    }

    public static Zen<uint> GetSrcIp(this Zen<Packet> packet)
    {
        return packet.GetField<Packet, uint>("SrcIp");
    }
}

// class representing an ACL with a list of prioritized rules.
public class Acl
{
    public string Name { get; set; }
    public AclLine[] Lines { get; set; }

    public Zen<bool> Allowed(Zen<Packet> packet)
    {
        return Allowed(packet, 0);
    }

    // compute whether a packet is allowed by the ACL recursively
    private Zen<bool> Allowed(Zen<Packet> packet, int lineNumber)
    {
        if (lineNumber >= this.Lines.Length)
        {
            return false; // Zen implicitly converts false to Zen<bool>
        }

        var line = this.Lines[lineNumber];

        // if the current line matches, then return the action, otherwise continue to the next line
        return If(line.Matches(packet), line.Action, this.Allowed(packet, lineNumber + 1));
    }
}

// An ACL line that matches a packet.
public class AclLine
{
    public bool Action { get; set; }
    public uint DstIpLow { get; set; }
    public uint DstIpHigh { get; set; }
    public uint SrcIpLow { get; set; }
    public uint SrcIpHigh { get; set; }

    // a packet matches a line if it falls within the specified ranges.
    public Zen<bool> Matches(Zen<Packet> packet)
    {
        return And(packet.GetDstIp() >= this.DstIpLow,
                   packet.GetDstIp() <= this.DstIpHigh,
                   packet.GetSrcIp() >= this.SrcIpLow,
                   packet.GetSrcIp() <= this.SrcIpHigh);
    }
}

namespace zen_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Packet p = new Packet();
            p.DstIp = 10;
            p.SrcIp = 10;
            Console.WriteLine(p.DstIp);
        }
    }
}

