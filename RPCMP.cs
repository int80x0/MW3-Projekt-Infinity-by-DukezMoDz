using PS3Lib;
using System;
using System.Text;
using System.Threading;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public class RPCMP
    {
        private static PS3API PS3 = new PS3API();
        public SelectAPI CurrentAPI;
        public static uint func_address = 0x277208;

        public static string Enable()
        {
            if (PS3.Extension.ReadByte(0x27720C) == 0x80)
            {
                byte[] WritePPC = new byte[] {
                    0x3F, 0x80, 0x10, 0x05, 0x81, 0x9C, 0x00, 0x48, 0x2C, 0x0C, 0x00, 0x00, 0x41, 0x82, 0x00, 0x78,
                    0x80, 0x7C, 0x00, 0x00, 0x80, 0x9C, 0x00, 0x04, 0x80, 0xBC, 0x00, 0x08, 0x80, 0xDC, 0x00, 0x0C,
                    0x80, 0xFC, 0x00, 0x10, 0x81, 0x1C, 0x00, 0x14, 0x81, 0x3C, 0x00, 0x18, 0x81, 0x5C, 0x00, 0x1C,
                    0x81, 0x7C, 0x00, 0x20, 0xC0, 0x3C, 0x00, 0x24, 0xC0, 0x5C, 0x00, 0x28, 0xC0, 0x7C, 0x00, 0x2C,
                    0xC0, 0x9C, 0x00, 0x30, 0xC0, 0xBC, 0x00, 0x34, 0xC0, 0xDC, 0x00, 0x38, 0xC0, 0xFC, 0x00, 0x3C,
                    0xC1, 0x1C, 0x00, 0x40, 0xC1, 0x3C, 0x00, 0x44, 0x7D, 0x89, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x21,
                    0x38, 0x80, 0x00, 0x00, 0x90, 0x9C, 0x00, 0x48, 0x90, 0x7C, 0x00, 0x4C, 0xD0, 0x3C, 0x00, 0x50,
                    0x48, 0x00, 0x00, 0x14 };
                PS3.SetMemory(func_address, new byte[] { 0x41 });
                PS3.SetMemory(func_address + 4, WritePPC);
                PS3.SetMemory(func_address, new byte[] { 0x40 });
                Thread.Sleep(10);
                DestroyAll();
                if (PS3.Extension.ReadByte(0x27720C) == 0x3F)
                {
                    return "Enabled";
                }
                else
                {
                    return "Disabled";
                }
            }
            else if (PS3.Extension.ReadByte(0x27720C) == 0x3F)
            {
                return "Enabled";
            }
            else
            {
                return "Disabled";
            }
        }

        public static int Call(uint address, params object[] parameters)
        {
            int length = parameters.Length;
            int index = 0;
            uint count = 0;
            uint Strings = 0;
            uint Single = 0;
            uint Array = 0;
            while (index < length)
            {
                if (parameters[index] is int)
                {
                    PS3.Extension.WriteInt32(0x10050000 + (count * 4), (int)parameters[index]);
                    count++;
                }
                else if (parameters[index] is uint)
                {
                    PS3.Extension.WriteUInt32(0x10050000 + (count * 4), (uint)parameters[index]);
                    count++;
                }
                else if (parameters[index] is short)
                {
                    PS3.Extension.WriteInt16(0x10050000 + (count * 4), (short)parameters[index]);
                    count++;
                }
                else if (parameters[index] is ushort)
                {
                    PS3.Extension.WriteUInt16(0x10050000 + (count * 4), (ushort)parameters[index]);
                    count++;
                }
                else if (parameters[index] is byte)
                {
                    PS3.Extension.WriteByte(0x10050000 + (count * 4), (byte)parameters[index]);
                    count++;
                }
                else
                {
                    uint pointer;
                    if (parameters[index] is string)
                    {
                        pointer = 0x10052000 + (Strings * 0x400);
                        PS3.Extension.WriteString(pointer, Convert.ToString(parameters[index]));
                        PS3.Extension.WriteUInt32(0x10050000 + (count * 4), pointer);
                        count++;
                        Strings++;
                    }
                    else if (parameters[index] is float)
                    {
                        PS3.Extension.WriteFloat(0x10050024 + (Single * 4), (float)parameters[index]);
                        Single++;
                    }
                    else if (parameters[index] is float[])
                    {
                        float[] Args = (float[])parameters[index];
                        pointer = 0x10051000 + Array * 4;
                        PS3.Extension.WriteFloats(pointer, Args);
                        PS3.Extension.WriteUInt32(0x10050000 + count * 4, pointer);
                        count++;
                        Array += (uint)Args.Length;
                    }

                }
                index++;
            }
            PS3.Extension.WriteUInt32(0x10050048, address);
            Thread.Sleep(20);
            return PS3.Extension.ReadInt32(0x1005004c);
        }

     



        public static object CallDynamic<T>(uint Address, params object[] Parameters)
        {
            int length = Parameters.Length;
            int index = 0;
            uint count = 0;
            uint Strings = 0;
            uint Single = 0;
            uint Array = 0;
            while (index < length)
            {
                if (Parameters[index] is bool)
                {
                    PS3.Extension.WriteBool(0x10050000 + (count * 4), (bool)Parameters[index]);
                    count++;
                }
                else if (Parameters[index] is int)
                {
                    PS3.Extension.WriteInt32(0x10050000 + (count * 4), (int)Parameters[index]);
                    count++;
                }
                else if (Parameters[index] is uint)
                {
                    PS3.Extension.WriteUInt32(0x10050000 + (count * 4), (uint)Parameters[index]);
                    count++;
                }
                else if (Parameters[index] is short)
                {
                    PS3.Extension.WriteInt16(0x10050000 + (count * 4), (short)Parameters[index]);
                    count++;
                }
                else if (Parameters[index] is ushort)
                {
                    PS3.Extension.WriteUInt16(0x10050000 + (count * 4), (ushort)Parameters[index]);
                    count++;
                }
                else if (Parameters[index] is byte)
                {
                    PS3.Extension.WriteByte(0x10050000 + (count * 4), (byte)Parameters[index]);
                    count++;
                }
                else
                {
                    uint pointer;
                    if (Parameters[index] is string)
                    {
                        pointer = 0x10052000 + (Strings * 0x400);
                        PS3.Extension.WriteString(pointer, Convert.ToString(Parameters[index]));
                        PS3.Extension.WriteUInt32(0x10050000 + (count * 4), pointer);
                        count++;
                        Strings++;
                    }
                    else if (Parameters[index] is float)
                    {
                        PS3.Extension.WriteFloat(0x10050024 + (Single * 4), (float)Parameters[index]);
                        Single++;
                    }
                    else if (Parameters[index] is float[])
                    {
                        float[] Args = (float[])Parameters[index];
                        pointer = 0x10051000 + (Array * 4);
                        RPC.WriteFloatArray(pointer, Args);
                        PS3.Extension.WriteUInt32(0x10050000 + (count * 4), pointer);
                        count++;
                        Array += (uint)Args.Length;
                    }
                }
                index++;
            }
            PS3.Extension.WriteUInt32(0x10050048, Address);
            Thread.Sleep(20);
            uint address = PS3.Extension.ReadUInt32(0x1005004c);
            if (typeof(T) == typeof(int))
            {
                return PS3.Extension.ReadInt32(address);
            }
            if (typeof(T) == typeof(uint))
            {
                return PS3.Extension.ReadUInt32(address);
            }
            if (typeof(T) == typeof(bool))
            {
                return PS3.Extension.ReadBool(address);
            }
            if (typeof(T) == typeof(string))
            {
                return PS3.Extension.ReadString(address);
            }
            if (typeof(T) == typeof(float))
            {
                return PS3.Extension.ReadFloat(address);
            }
            if (typeof(T) == typeof(float[]))
            {
                return RPC.ReadFloatLength(address, 3);
            }
            return 0;
        }

        public static void DestroyAll()
        {
            byte[] clear = new byte[0xB4 * 1024];
            PS3.SetMemory(0xF0E10C, clear);
        }
        #region CBuf_AddText
        public static void CBuf_AddText(string command)
        {
            Call(0x1DB240, 0, command);
        }

        public static void CBuf_AddText(int client, string command)
        {
            Call(0x1DB240, client, command);
        }
        #endregion
        #region SV_GameSendServerCommand
        public static void SV_GameSendServerCommand(int client, string command)
        {
            Call(0x228FA8, client, 0, command);
        }

        public static void iPrintln(int client, string Text)
        {
            SV_GameSendServerCommand(client, "f \"" + Text);
        }

        public static void iPrintlnBold(int client, string Text)
        {
            SV_GameSendServerCommand(client, "c \"" + Text);
        }
        #endregion

        public static void iPrintlnBold(string msg, int localClient = 0)
        {
            Call(0x7A5C8, localClient, msg);
            Thread.Sleep(20);
        }

        public string ByteArrayToString(byte[] bytes)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(bytes);
        }

        public static void iPrintln(string msg, int localClient = 0)
        {
            Call(0x7A588, localClient, msg);
            Thread.Sleep(20);
        }

        public static void SV_KickClientUseGMode(int localClientIndex, string command)
        {
            Call(0x223BD0, localClientIndex, command);
            Thread.Sleep(20);
        }

        public static int Dvar_GetInt(string dvarName)
        {
            return Call(0x2910DC, dvarName);
        }

        public static string Dvar_GetString(string dvarName)
        {
            return (string)CallDynamic<string>(0x2911A8, dvarName);
        }

        public static string SV_GetGuid(int Client)
        {
            return (string)CallDynamic<string>(0x229ACC, Client);
        }

        public static bool isBot(int Client)
        {
            return SV_GetGuid(Client).IndexOf("bot") == 0;
        }
    }
}
