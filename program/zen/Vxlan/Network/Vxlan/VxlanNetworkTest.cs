namespace ZenLib.Tests
{
    using System.Collections.Generic;
    using ZenLib;
    using static ZenLib.Language;
    using ZenLib.Tests.Network;

    public class VxlanNetworkTest
    {
        private Network.Network ExampleNetwork()
        {
            /*
            Toy network: [H1] --i1--i2--[VTEP R1]--i3--i4--[VTEM R2]--i5--i6--[H2]
                                   |-----VTEP1-----|   |-----VTEP2-----|
            H1.i1.address = 10.0.0.1;
            R1.i2.address = 10.0.0.2;
            R1.i3.address = 192.168.10.1
            R2.i4.address = 172.168.10.1
            R2.i5.address = 10.0.0.3;
            H2.i6.address = 10.0.0.4;
            */

            /*parameters for VXLAN*/
            //vtep1
            byte f1 = 0;
            UInt24 v1rsvd1 = new UInt24(0);
            UInt24 vnid1 = new UInt24(10);
            byte v1rsvd2 = 0;
            var vh1 = VxlanHeader.Create(f1,v1rsvd1,vnid1,v1rsvd2);
            var udph1 = UdpHeader.Create(10,10);
            var iph1 = IpHeader.Create(Ip.Parse("172.168.10.1"),Ip.Parse("192.168.10.1"),1,1,17);
            var eth1 = EthHeader.Create("ffeeddccbbaa","aabbccddeeff",2048);

            //vtep2
            byte f2 = 0;
            UInt24 v2rsvd1 = new UInt24(0);
            UInt24 vnid2 = new UInt24(10);
            byte v2rsvd2 = 0;
            var vh2 = VxlanHeader.Create(f2,v2rsvd1,vnid2,v2rsvd2);
            var udph2 = UdpHeader.Create(10,10);
            var iph2 = IpHeader.Create(Ip.Parse("192.168.10.1"),Ip.Parse("172.168.10.1"),1,1,17);
            var eth2 = EthHeader.Create("aabbccddeeff","ffeeddccbbaa",2048);

            /*create interfaces*/
            Interface i1 = new Interface();
            i1.Name = "i1";
            i1.PortNumber = 1;

            Interface i2 = new Interface();
            i2.Name = "i2";
            i2.PortNumber = 1;

            Interface i3 = new Interface();
            i3.Name = "i3";
            i3.PortNumber = 2;

            Interface i4 = new Interface();
            i4.Name = "i4";
            i4.PortNumber = 1;

            Interface i5 = new Interface();
            i5.Name = "i5";
            i5.PortNumber = 2;

            Interface i6 = new Interface();
            i6.Name = "i6";
            i6.PortNumber = 1;

            /*Create VxlanTunneEndPoint*/

            VxlanTunnelEndPoint vtep1 = new VxlanTunnelEndPoint();
            vtep1.VxlanTunnel = (vh1,udph1,iph1,eth1);

            VxlanTunnelEndPoint vtep2 = new VxlanTunnelEndPoint();
            vtep1.VxlanTunnel = (vh2,udph2,iph2,eth2);

            //Neighbor
            i1.Neighbor = i2;
            i2.Neighbor = i1;
            i3.Neighbor = i4;
            i4.Neighbor = i3;
            i5.Neighbor = i6;
            i6.Neighbor = i5;

            //Device creation
            Device h1 = new Device();
            h1.Name = "H1";
            h1.Interfaces = new Interface[] {i1};

            Device r1 = new Device();
            r1.Name = "R1";
            r1.Interfaces = new Interface[] {i2,i3};
            r1.Vtep = vtep1;


            Device r2 = new Device();
            r2.Name = "R2";
            r2.Interfaces = new Interface[] {i4,i5};
            r2.Vtep = vtep2;

            Device h2 = new Device();
            h2.Name = "H2";
            h2.Interfaces = new Interface[] {i6};

            i1.Owner = h1;
            i2.Owner = r1;
            i3.Owner = r1;
            i4.Owner = r2;
            i5.Owner = r2;
            i6.Owner = h2;

            //FIB creation

            var table1 = new ForwardingTable
            {
                Rules = new ForwardingRule[]
                {
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("10.0.0.0"),
                        DstIpHigh = Ip.Parse("10.0.0.255"),
                        Interface = i1,
                    },
                }   
            };

            var table2 = new ForwardingTable
            {
                Rules = new ForwardingRule[]
                {
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("10.0.0.0"),
                        DstIpHigh = Ip.Parse("10.0.0.255"),
                        Interface = i2,
                    },
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("172.168.10.0"),
                        DstIpHigh = Ip.Parse("172.168.10.255"),
                        Interface = i3,
                    },
                }   
            };

             var table3 = new ForwardingTable
            {
                Rules = new ForwardingRule[]
                {
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("10.0.0.0"),
                        DstIpHigh = Ip.Parse("10.0.0.255"),
                        Interface = i5,
                    },
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("192.168.10.0"),
                        DstIpHigh = Ip.Parse("192.168.10.255"),
                        Interface = i4,
                    },
                }   
            };

            var table4 = new ForwardingTable
            {
                Rules = new ForwardingRule[]
                {
                    new ForwardingRule
                    {
                        DstIpLow = Ip.Parse("10.0.0.0"),
                        DstIpHigh = Ip.Parse("10.0.0.255"),
                        Interface = i6,
                    },
                }   
            };

            //set FIB to device
            h1.Table = table1;
            r1.Table = table2;
            r2.Table = table3;
            h2.Table = table4;

            //create the network
            var network = new Network.Network {Devices = new Dictionary<string, Device>() };
            network.Devices["H1"] = h1;
            network.Devices["R1"] = r1;
            network.Devices["R2"] = r2;
            network.Devices["H2"] = h2;

            return network;
        }

        public void TestVxlanNetwork()
        {
            var network = ExampleNetwork(); 
            var h1 = network.Devices["H1"];
            var r1 = network.Devices["R1"];
            var r2 = network.Devices["R2"];
            var h2 = network.Devices["H2"];

            var f = Function<sPacket,bool>(p =>
            {
                //forward from h1 to r1
                var fwd1 = h1.Table.sForward(p,0) != 0;
                //encap at r1
                var pencap = r1.Vtep.Encapsulate(p.GetEthHeader());
                //forward from r1 to r2
                var pouter = VxlanOuterExtensions.GetOuterHeader(pencap);
                var fwd2 = r1.Table.sForward(pouter,0) != 0;
                //decap at r2
                var pdecap = r2.Vtep.Decapsulate(pencap);
                //forward from r2 to h2
                var fwd3 = r2.Table.sForward(pdecap,0) != 0;

                return And(fwd1,fwd2,fwd3);
            });

        }
    }
}