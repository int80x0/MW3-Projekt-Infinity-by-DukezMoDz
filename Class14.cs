using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW3_Projekt_Infinity_by_RATModz;
using PS3Lib;
using System.Threading;

namespace MW3_Projekt_Infinity_by_RATModz
{
    
    class Class14
    {

        static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        public static uint num;

        public static uint Element(uint Index)
        {
            return 15786252u + Index * 180u;
        }


        public static void smethod_34(uint uint_1, uint uint_2)
        {
            byte[] bytes = BitConverter.GetBytes(uint_2);
            Array.Reverse(bytes);
            Form1.smethod_8(uint_1, bytes);
        }

        public static void Vision(int p0, string p1)
        {
            RPC.SV_GameSendServerCommand(p0, "J \"" + p1 + "\"");
            Thread.Sleep(20);
        }


        internal static void SV_GameSendServerCommand(uint p0, string v)
        {
            RPC.Call(RPC.Offsets.Addresses.SV_GameSendServerCommand, new object[]
            {
            (uint)p0,
            0,
            v,
            0,
            0
            });
        }
    }
}