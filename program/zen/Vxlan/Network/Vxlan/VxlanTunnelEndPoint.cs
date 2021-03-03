// <copyright file="ForwardingTable.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace ZenLib.Tests.Network
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using ZenLib;
    using static ZenLib.Language;

    class VxlanTunnelEndPoint
    {
        //public Interface Int1;

        //public Interface Int2;

        public (Zen<VxlanHeader>,Zen<UdpHeader>,Zen<IpHeader>,Zen<EthHeader>)? VxlanTunnel {get;set;}

        public Zen<VxlanPacket> Encapsulate(Zen<EthHeader> eth)
        {
            if (this.VxlanTunnel.HasValue)
            {
                var oheader = eth;
                var newVxlan = this.VxlanTunnel.Value.Item1;
                var newUdp = this.VxlanTunnel.Value.Item2;
                var newIp = this.VxlanTunnel.Value.Item3;
                var newEth = this.VxlanTunnel.Value.Item4;
                var newOuter = sPacket.Create(newEth,newIp,newUdp);

                var uheader = VxlanOuter.Create(
                    newOuter,
                    newVxlan);
                
                var vxlanPkt = VxlanPacket.Create(oheader,uheader);

                return vxlanPkt;
            }

            Console.WriteLine("Encapsulation failed.");
            return null;
        }

        public Zen<sPacket> Decapsulate(Zen<VxlanPacket> packet)
        {
            if (this.VxlanTunnel.HasValue)
            {
                var sp = packet.GetOuterHeader();
                return sPacket.Create(sp.GetEthHeader(),sp.GetIpHeader(),sp.GetUdpHeader());
            }

            Console.WriteLine("Decapsulation failed.");
            return null;
        }

    }
}
