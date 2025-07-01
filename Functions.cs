
using PS3Lib;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static MW3_Projekt_Infinity_by_RATModz.Addresses;
using static MW3_Projekt_Infinity_by_RATModz.RPCMP;
using static MW3_Projekt_Infinity_by_RATModz.Connection;
using static MW3_Projekt_Infinity_by_RATModz.Structures;

namespace MW3_Projekt_Infinity_by_RATModz
{
    class Functions
    {
        private static PS3API PS3 = new PS3API();
        public static bool PossibleActiveStats()
        {
            if (IsInGame && IsHostVerified)
                if (CreatorDetect)
                    if (IsSelectedConnectedPlayer)
                        if (IsNotBot)
                            return true;
                        else
                            MessageBox.Show("You can't freeze the bot", "Bot detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Client doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("You can't kick the creator of tool", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("You aren't in game or you aren't the host", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public static bool PossibleActiveKick()
        {
            if (IsInGame && IsHostVerified)
                if (CreatorDetect)
                    if (IsSelectedConnectedPlayer)
                        return true;
                    else
                        MessageBox.Show("Client doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("You can't kick the creator of tool", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("You aren't in game or you aren't the host", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public static bool PossibleActiveFreeze()
        {
            if (IsInGame && IsHostVerified)
                if (CreatorDetect)
                    if (IsSelectedConnectedPlayer)
                        if (IsNotBot)
                            return true;
                        else
                            MessageBox.Show("You can't freeze the bot", "Bot detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Client doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("You can't freeze the creator of tool", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("You aren't in game or you aren't the host", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public static bool PossibleActiveClasses()
        {
            if (IsInGame && IsHostVerified)
                if (CreatorDetect)
                    if (IsSelectedConnectedPlayer)
                        if (IsNotBot)
                            return true;
                        else
                            MessageBox.Show("You can't freeze the bot", "Bot detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Client doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("You can't change the creator classes of tool", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("You aren't in game or you aren't the host", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public static bool PossibleActiveClasses2()
        {
            if (IsInGame && IsHostVerified)
                if (CreatorDetect)
                    if (IsSelectedConnectedPlayer)
                        if (IsNotBot)
                            return true;
                        else
                            MessageBox.Show("You can't freeze the bot", "Bot detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Client doesn't exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("You can't change the creator classes of tool", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public static void Motd(string Text)
        {
            PS3.Extension.WriteString(0x8A3320, Text);
            PS3.Extension.WriteString(0x8A3120, Text);
        }

        public static uint G_Client(uint ClientIndex)
        {
            return (G_Client_a + (G_Client_Interval_a * ClientIndex));
        }

        public static uint G_Client(uint ClientIndex, uint Mods)
        {
            return (G_Client_a + (G_Client_Interval_a * ClientIndex)) + Mods;
        }

        public static uint G_Entity(uint ClientIndex)
        {
            return (G_Entity_a + (G_Entity_Interval_a * ClientIndex));
        }

        public static uint G_Entity(uint ClientIndex, uint Mods)
        {
            return (G_Entity_a + (G_Entity_Interval_a * ClientIndex)) + Mods;
        }

        public static bool OnPlayerConnected(uint client)
        {
            return PS3.Extension.ReadInt32(G_Client(client, 0x332C)) == 2;
        }

        public static bool OnPlayerSpawned(uint client)
        {
            return PS3.Extension.ReadByte(G_Client(client, 0x41F)) != 0 || PS3.Extension.ReadByte(G_Client(client, 0x3313)) == 1;
        }

        public static void PS3Freeze(uint Client)
        {
            /*PS3.SetMemory(0x110A500 + (Client * 0x3980), new byte[] { 0x00, 0xE5, 0xD0 });
            PS3.SetMemory(0x110A506 + (Client * 0x3980), new byte[] { 0x00, 0xE5, 0xD0 });
            PS3.SetMemory(0x110A520 + (Client * 0x3980), new byte[] { 0xDF, 0xE5, 0xD0, 0xD0 });
            PS3.SetMemory(0x110A528 + (Client * 0x3980), new byte[] { 0xDF, 0xE5, 0xD0, 0xD0 });*/
            PS3.SetMemory(G_Entity(Client, 0x187), new byte[] { 0xDF });
            PS3.SetMemory(G_Client(Client, 0x3303), new byte[1]);
            PS3.SetMemory(G_Client(Client, 0x12), new byte[] { 4 });
            Thread.Sleep(0x60);
            PS3.SetMemory(G_Client(Client, 0x35FF), new byte[] { 4 });
            Thread.Sleep(0x20);
            PS3.SetMemory(G_Client(Client, 0x2C9), new byte[] { 1 });
            PS3.SetMemory(G_Client(Client, 0x2B1), new byte[] { 1 });
            PS3.SetMemory(G_Client(Client, 0x2D5), new byte[] { 1 });
            PS3.SetMemory(G_Client(Client, 0x2BD), new byte[] { 1 });
        }

        public static bool InGame()
        {
            return PS3.Extension.ReadBool(0x18D4C64);
        }

        public static bool ImHost()
        {
            return GetHost() == GetMe();
        }

        public static int GetHost()
        {
            IsInParty = PS3.Extension.ReadBool(0x8AA267);
            if (IsInParty)
                HostIndex = PS3.Extension.ReadByte(0x8AA1EB);
            else
                HostIndex = PS3.Extension.ReadByte(0x89F293);
            return (int)HostIndex;
        }

        public static uint GetMe()
        {
            try
            {
                string serverInfo = PS3.Extension.ReadString(LocalName);
                for (uint index = 0; index < 18; ++index)
                {
                    if (serverInfo.Contains(GrabName((int)index)))
                    {
                        MyIndex = index;
                        return index;
                    }
                }
                return 18;
            }
            catch
            {

            }
            return 18;
        }

        public static string GrabName(int Client)
        {
            string Name = PS3.Extension.ReadString(LobbyName + ((uint)Client * GrabInterval));
            if (Name != "")
                return Name;
            return "";
        }

        public static string ReadPartyID(uint Offset)
        {
            byte[] buffer = new byte[8];
            PS3.GetMemory(Offset, buffer);
            string PartyID = BitConverter.ToString(buffer).Replace("-", "");
            switch (PartyID)
            {
                case "0000000000000000": return "N/D";
                default: return PartyID;
            }
        }

        public static Color GetGroup(int Client)
        {
            if (Client == HostIndex)
                return Color.Yellow;
            else if (CurrentGameMode == "Free-for-All" || CurrentGameMode == "One in the Chamber" || CurrentGameMode == "Gun Game")
                return Color.Red;
            else if (ReadPartyID(LobbyPartyID + ((uint)Client * GrabInterval)) == ReadPartyID(LobbyPartyID + (HostIndex * GrabInterval)))
                return Color.Blue;
            else if (getClientTeam((uint)Client) == getClientTeam(HostIndex))
                return Color.Lime;
            else if (getClientTeam((uint)Client) != getClientTeam(HostIndex))
                return Color.Red;
            else
                return Color.FromArgb(240, 240, 240);
        }

        public static string GetNameInGame(int Client)
        {
            string Name = PS3.Extension.ReadString(G_Client((uint)Client, G_Client_GetName));
            if (Client == HostIndex)
                return "Host : " + Name;
            return Name;
        }

        public static string ReadIP(byte[] mem)
        {
            string IP = $"{mem[0]}.{mem[1]}.{mem[2]}.{mem[3]}";
            if (IP == "81.66.80.111")
                return "Creator";
            else
                return IP;
        }

        public static bool ISNotCreator()
        {
            return ReadIP(PS3.Extension.ReadBytes(0x89D29E + (HostIndex * 0x178), 4)) == "Creator" ? true : ReadIP(PS3.Extension.ReadBytes(0x89D29E + ((uint)SelectedPlayerIndex * 0x178), 4)) != "Creator";
        }

        public static uint clientInfo(uint ID)
        {
            uint Centity = PS3.Extension.ReadUInt32(CEntity_a);
            return Centity + ClientInfo_a + (ID * ClientInfo_Size_a);
        }

        public static byte getClientTeam(uint ID)
        {
            return PS3.Extension.ReadByte(clientInfo(ID) + 0x23);
        }

        public static void NoRecoil(bool State)
        {
            byte[] buffer = new byte[4];
            buffer[0] = 0x60;
            PS3.SetMemory(0xBE6D0, State ? buffer : new byte[] { 0x4B, 0xF8, 0x15, 0x01 });
            if (IsInGame)
                if (CanActive)
                    iPrintln(State ? "No recoil : [^2On^7]" : "No recoil : [^1Off^7]");
        }

        public static void NoSpread(bool State)
        {
            PS3.SetMemory(0x18DE168, State ? new byte[] { 1 } : new byte[] { 0x3F });
            if (IsInGame)
                if (CanActive)
                    iPrintln(State ? "No spread : [^2On^7]" : "No spread : [^1Off^7]");
        }

        public static void NoSway(bool State)
        {
            byte[] buffer = new byte[4];
            buffer[0] = 0x60;
            PS3.SetMemory(0x50800, State ? buffer : new byte[] { 0xD0, 0x3D, 0x00, 0x08 });
            PS3.SetMemory(0x50838, State ? buffer : new byte[] { 0xD0, 0x3D, 0x00, 0x04 });
            PS3.SetMemory(0x50874, State ? buffer : new byte[] { 0xD0, 0x3F, 0x00, 0x00 });
            PS3.SetMemory(0x51500, State ? buffer : new byte[] { 0xD0, 0x3F, 0x00, 0x04 });
            PS3.SetMemory(0x51534, State ? buffer : new byte[] { 0xD0, 0x3F, 0x00, 0x00 });
            if (IsInGame)
                if (CanActive)
                    iPrintln(State ? "No sway : [^2On^7]" : "No sway : [^1Off^7]");
        }

        public static void NoFlinch(bool State)
        {
            byte[] buffer = new byte[4];
            buffer[0] = 0x60;
            PS3.SetMemory(0x8C144, State ? buffer : new byte[] { 0x4B, 0xFF, 0xFA, 0x85 });
            if (IsInGame)
                if (CanActive)
                    iPrintln(State ? "No flinch : [^2On^7]" : "No flinch : [^1Off^7]");
        }

        public static void NoFlash(bool State)
        {
            byte[] buffer = new byte[4];
            buffer[0] = 0x60;
            PS3.SetMemory(0x3B8234, State ? buffer : new byte[] { 0x4B, 0xFF, 0x6B, 0x05 });
            //PS3.SetMemory(0x18C8B8C, State ? new Byte[1] : new Byte[] { 0x01 });
            //Other No Fx
            PS3.SetMemory(0x18C9164, State ? new byte[] { 0x01 } : new byte[1]);
            if (IsInGame)
                if (CanActive)
                    iPrintln(State ? "No flash : [^2On^7]" : "No flash : [^1Off^7]");
        }

        public static void lockIntDvarToValue(uint pointer, byte[] value)
        {
            uint num = 4;
            uint num2 = 11;
            byte[] buffer = new byte[4];
            PS3.GetMemory(pointer, buffer);
            Array.Reverse(buffer);
            uint num3 = BitConverter.ToUInt32(buffer, 0);
            byte[] bytes = new byte[2];
            PS3.GetMemory(num3 + 4, bytes);
            Array.Reverse(bytes);
            ushort num4 = BitConverter.ToUInt16(bytes, 0);
            if ((num4 & 0x800) != 0x800)
            {
                num4 = (ushort)(num4 | 0x800);
                bytes = BitConverter.GetBytes(num4);
                Array.Reverse(bytes);
                PS3.SetMemory(num3 + num, bytes);
            }
            PS3.SetMemory(num3 + num2, value);
        }
    }
}
