using System;
using System.Text;
using System.Threading;
using PS3Lib;

namespace MW3_Projekt_Infinity_by_RATModz
{

	public static class RPC
	{
	
		private static void WriteSingle(uint address, float input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			RPC.PS3.SetMemory(address, array);

		}

    public static byte[] ReverseBytes(byte[] inArray)
		{
			Array.Reverse(inArray);
			return inArray;
		}


       

        public static float[] ReadFloatLength(uint Offset, int Length)
        {
            byte[] memory = RPC.GetMemory(Offset, Length * 4);
            Array.Reverse(memory);
            float[] array = new float[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = BitConverter.ToSingle(memory, (Length - 1 - i) * 4);
            }
            return array;
        }

    

        public static void WriteSingle(uint address, float[] input)
		{
			int num = input.Length;
			byte[] array = new byte[num * 4];
			for (int i = 0; i < num; i++)
			{
				RPC.ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, i * 4);
			}
			RPC.PS3.SetMemory(address, array);
		}

		
		public static void GetMemoryR(uint Address, ref byte[] Bytes)
		{
			RPC.PS3.GetMemory(Address, Bytes);
		}


        public static void WriteFloatArray(uint Offset, float[] Array)
        {
            byte[] array = new byte[Array.Length * 4];
            for (int i = 0; i < Array.Length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(Array[i])).CopyTo(array, (int)(i * 4));
            }
            PS3.SetMemory(Offset, array);
        }


        public static uint GetFuncReturn()
		{
			byte[] array = new byte[4];
			RPC.GetMemoryR(0x114AE64, ref array);
			Array.Reverse(array);
			return BitConverter.ToUInt32(array, 0);
		}

        public static void Enable()
        {
            if (RPC.PS3.Extension.ReadByte(func_address + 4) != 0x3f)
            {
                byte[] bytes = new byte[] {
                    0x3f, 0x80, 0x10, 5, 0x81, 0x9c, 0, 0x48, 0x2c, 12, 0, 0, 0x41, 130, 0, 120,
                    0x80, 0x7c, 0, 0, 0x80, 0x9c, 0, 4, 0x80, 0xbc, 0, 8, 0x80, 220, 0, 12,
                    0x80, 0xfc, 0, 0x10, 0x81, 0x1c, 0, 20, 0x81, 60, 0, 0x18, 0x81, 0x5c, 0, 0x1c,
                    0x81, 0x7c, 0, 0x20, 0xc0, 60, 0, 0x24, 0xc0, 0x5c, 0, 40, 0xc0, 0x7c, 0, 0x2c,
                    0xc0, 0x9c, 0, 0x30, 0xc0, 0xbc, 0, 0x34, 0xc0, 220, 0, 0x38, 0xc0, 0xfc, 0, 60,
                    0xc1, 0x1c, 0, 0x40, 0xc1, 60, 0, 0x44, 0x7d, 0x89, 3, 0xa6, 0x4e, 0x80, 4, 0x21,
                    0x38, 0x80, 0, 0, 0x90, 0x9c, 0, 0x48, 0x90, 0x7c, 0, 0x4c, 0xd0, 60, 0, 80,
                    0x48, 0, 0, 20
                 };
                PS3.SetMemory(func_address, new byte[] { 0x41 });
                PS3.SetMemory(func_address + 4, bytes);
                PS3.SetMemory(func_address, new byte[] { 0x40 });
            }
        }


        public static int Call(uint address, params object[] parameters)
        {
            int length = parameters.Length;
            int index = 0;
            uint num3 = 0;
            uint num4 = 0;
            uint num5 = 0;
            uint num6 = 0;
            while (index < length)
            {
                if (parameters[index] is int)
                {
                    RPC.PS3.Extension.WriteInt32(0x10050000 + (num3 * 4), (int)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is uint)
                {
                    RPC.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), (uint)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is short)
                {
                    RPC.PS3.Extension.WriteInt16(0x10050000 + (num3 * 4), (short)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is ushort)
                {
                    RPC.PS3.Extension.WriteUInt16(0x10050000 + (num3 * 4), (ushort)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is byte)
                {
                    RPC.PS3.Extension.WriteByte(0x10050000 + (num3 * 4), (byte)parameters[index]);
                    num3++;
                }
                else
                {
                    uint num7;
                    if (parameters[index] is string)
                    {
                        num7 = 0x10052000 + (num4 * 0x400);
                        RPC.PS3.Extension.WriteString(num7, Convert.ToString(parameters[index]));
                        RPC.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);
                        num3++;
                        num4++;
                    }
                    else if (parameters[index] is float)
                    {
                        RPC.PS3.Extension.WriteFloat(0x10050024 + (num5 * 4), (float)parameters[index]);
                        num5++;
                    }
                    else if (parameters[index] is float[])
                    {
                        float[] array = (float[])parameters[index];
                        num7 = 0x10051000 + (num6 * 4);
                        RPC.WriteFloatArray(num7, array);
                        RPC.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);
                        num3++;
                        num6 += (uint)array.Length;
                    }
                }
                index++;
            }
            RPC.PS3.Extension.WriteUInt32(0x10050048, address);
            Thread.Sleep(20);
            return RPC.PS3.Extension.ReadInt32(0x1005004c);
        }

      

      
        private static byte[] ReadBytes(uint address, int length)
		{
			return RPC.GetMemory(address, length);
		}

		
		public static byte[] GetMemory(uint offset, int length)
		{
			byte[] array = new byte[length];
			RPC.PS3.GetMemory(offset, array);
			return array;
		}

	
		public static float[] ReadSingle(uint address, int length)
		{
			byte[] array = RPC.ReadBytes(address, length * 4);
			Array.Reverse(array);
			float[] array2 = new float[length];
			for (int i = 0; i < length; i++)
			{
				array2[i] = BitConverter.ToSingle(array, (length - 1 - i) * 4);
			}
			return array2;
		}

       

        public static void SV_KickClient(int client, string text)
		{
			RPC.Call(0x00223BD0, new object[]
			{
				client,
				text
			});
		}

		
		public static void CBuf_AddText(int client, string command)
		{
			RPC.Call(RPC.Offsets.Addresses.CBuf_AddText, new object[]
			{
				(uint)client,
				command,
				0,
				0,
				0
			});
		}

		
		public static void SV_GameSendServerCommand(int client, string command)
		{
			RPC.Call(RPC.Offsets.Addresses.SV_GameSendServerCommand, new object[]
			{
				(uint)client,
				0,
				command,
				0,
				0
			});
		}

		
		public static void iPrintln(int client, string Text)
		{
			Text.Replace("[X]", "\u0001").Replace("[O]", "\u0002").Replace("[]", "\u0003").Replace("[Y]", "\u0004").Replace("[L1]", "\u0005").Replace("[R1]", "\u0006").Replace("[L3]", "\u0010").Replace("[R3]", "\u0011").Replace("[L2]", "\u0012").Replace("[R2]", "\u0013").Replace("[UP]", "\u0014").Replace("[DOWN]", "\u0015").Replace("[LEFT]", "\u0016").Replace("[RIGHT]", "\u0017").Replace("[START]", "\u000e").Replace("[SELECT]", "\u000f").Replace("[LINE]", "\n");
			RPC.SV_GameSendServerCommand(client, "c \"" + Text + "\"");
			Thread.Sleep(20);
		}

		
		public static void iPrintlnBold(int client, string Text)
		{
			Text.Replace("[X]", "\u0001").Replace("[O]", "\u0002").Replace("[]", "\u0003").Replace("[Y]", "\u0004").Replace("[L1]", "\u0005").Replace("[R1]", "\u0006").Replace("[L3]", "\u0010").Replace("[R3]", "\u0011").Replace("[L2]", "\u0012").Replace("[R2]", "\u0013").Replace("[UP]", "\u0014").Replace("[DOWN]", "\u0015").Replace("[LEFT]", "\u0016").Replace("[RIGHT]", "\u0017").Replace("[START]", "\u000e").Replace("[SELECT]", "\u000f").Replace("[LINE]", "\n");
			RPC.SV_GameSendServerCommand(client, "f \"" + Text + "\"");
			Thread.Sleep(20);
		}

		
		public static void Set_ClientDvar(int client, string Text)
		{
			RPC.SV_GameSendServerCommand(client, "q " + Text);
			Thread.Sleep(20);
		}

	

		
		public static void Fov(int client, string Text)
		{
			RPC.SV_GameSendServerCommand(client, "q cg_fov " + Text);
			Thread.Sleep(20);
		}

		
		public static void Vision(int client, string Text)
		{
			RPC.SV_GameSendServerCommand(client, "J \"" + Text + "\"");
			Thread.Sleep(20);
		}

		
		public static void Kick(int client, string Text)
		{
			RPC.SV_GameSendServerCommand(client, "r \"" + Text + "\"");
			Thread.Sleep(20);
		}

      
        public static void GiveWeapon(int client, int weapon, int akimbo)
		{
			RPC.Call(RPC.Offsets.Addresses.G_GivePlayerWeapon, new object[]
			{
				RPC.G_ClientFunction(client),
				(uint)weapon,
				0
			});
			RPC.Call(RPC.Offsets.Addresses.Add_Ammo, new object[]
			{
				(uint)((ulong)RPC.Offsets.Addresses.G_Entity + (ulong)((long)(client * 640))),
				(uint)weapon,
				0,
				9999,
				1
			});
		}

		
		public static uint G_ClientFunction(int client)
		{
			return RPC.Offsets.Addresses.G_Client + (uint)(client * 14720);
		}

		
		public static void SetModel(int client, string model)
		{
			RPC.Call(RPC.Offsets.Addresses.G_SetModel, new object[]
			{
				(uint)((ulong)RPC.Offsets.Addresses.G_Entity + (ulong)((long)(client * 640))),
				model,
				0,
				0,
				0
			});
		}

        
        public static void Cmd_ExecuteSingleCommand(uint client, string command)
		{
			RPC.Call(RPC.Offsets.Addresses.Cmd_ExecuteSingleCommand, new object[]
			{
				client,
				command,
				0,
				0,
				0
			});
		}

        


        private static PS3API PS3 = new PS3API();

		
		public static uint func_address = 0x277208;

	
		public static class Offsets
		{
			
			public static class Addresses
			{
              public static uint
              G_Client = 0x110A280,
              g_client = 0x110A280,
              G_ClientIndex = 0x3980,
              EntityIndex = 0x280,
              G_Entity = 0xFCA280,
              MapBrushModel = 0x7F80,
              BG_GetPerkIndexForName = 0x210B0,
              BG_GetNumWeapons = 0x3CFBC,
              BG_FindWeaponIndexForName = 0x3CFD0,
              BG_GetWeaponIndexForName = 0x3D434,
              BG_GetViewModelWeaponIndex = 0x3D7D8,
              Cmd_ExecuteSingleCommand = 0x1DB240,
              BG_WeaponFireRecoil = 0x3FBD0,
              CG_FireWeapon = 0xBE498,
              Key_IsDown = 0xD1CD8,
              Key_StringToKeynum = 0xD1D18,
              Key_IsValidGamePadChar = 0xD1E64,
              Key_KeyNumToString = 0xD1EA4,
              Key_Unbind_f = 0xD2368,
              Key_Bind_f = 0xD247C,
              BG_TakePlayerWeapon = 0x1C409C,
              G_GivePlayerWeapon = 0x1C3034,
              SV_GameSendServerCommand = 0x228FA8,
              SV_GetConfigString = 0x22A4A8,
              SV_SetConfigString = 0x22A208,
              va = 0x299490,
              G_SetModel = 0x1BEF5C,
              G_LocalizedStringIndex = 0x1BE6CC,
              G_MaterialIndex = 0x1BE744,
              G_ModelIndex = 0x1BE7A8,
              G_ModelName = 0x1BE8A0,
              Add_Ammo = 0x18A29C,
              PlayerCmd_SetPerk = 0x17EBE8,
              G_Damage = 0x183E18,
              G_RadiusDamage = 0x185600,
              G_GetClientScore = 0x18EA74,
              G_GetClientDeaths = 0x18EA98,
              Cmd_AddCommandInternal = 0x1DC4FC,
              CBuf_AddText = 0x001DB240,
              SV_SendDisconnect  = 0x0022472C,
              SV_SendClientGameState  = 0x002284F8,
              SV_KickClient  = 0x00223BD0,
              G_CallSpawnEntity  = 0x001BA730,
              Player_Die  = 0x00183748,
              SV_DropClient  = 0x002249FC,
              SV_SendServerCommand  = 0x0022CEBC,
              Scr_Notify  = 0x001BB1B0,
              Sv_SetGametype  = 0x00229C1C,
              Sv_Maprestart  = 0x00223774,
              sv_maprestart_f = 0x00223B20,
              sv_spawnsever  = 0x0022ADF8,
              sv_map_f = 0x002235A0,
              sv_matchend  = 0x0022F7A8,
              R_AddCmdDrawText  = 0x00393640,
              R_RegisterFont  = 0x003808B8,
              R_AddCmdDrawStretchPic  = 0x00392D78,
              CL_DrawTextHook  = 0x000D93A8,
              R_AddCmdDrawTextWithEffects  = 0x003937C0,
              CG_BoldGameMessage  = 0x0007A5C8,
              UI_FillRectPhysical  = 0x0023A810,
              UI_DrawLoadBar  = 0x0023A730,
              Scr_MakeGameMessage  = 0x001B07F0,
              Scr_ConstructMessageString  = 0x001B04F4,
              R_NormalizedTextScale  = 0x003808F0,
              TeleportPlayer  = 0x00191B00,
              CL_DrawText  = 0x000D9490,
              CL_DrawTextRotate  = 0x000D9554,
              SV_GameDropClient  = 0x00229020,
              Dvar_GetBool  = 0x00291060,
              Dvar_GetInt  = 0x002910DC,
              Dvar_GetFloat  = 0x00291148,
              Dvar_RegisterBool  = 0x002933F0,
              Dvar_IsValidName  = 0x0029019C,
              Material_RegisterHandle  = 0x0038B044,
              CL_RegisterFont = 0x000D9734,
              SetClientViewAngle  = 0x001767E0,
              R_RegisterDvars  = 0x0037E420,
              PlayerCmd_SetClientDvar  = 0x0017CB4C,
              Jump_RegisterDvars  = 0x00018E20,
              AimTarget_RegisterDvars = 0x00012098,
              G_FreeEntity  = 0x001C0840,
              G_EntUnlink  = 0x001C4A5C,
              SV_DObjGetTree  = 0x00229A68,
              BG_GetEntityTypeName  = 0x0001D1F0,
              CL_GetClientState  = 0x000E26A8,
              CL_GetConfigString  = 0x000C5E7C,
              Info_ValueForKey  = 0x00299604,
              Scr_GetInt  = 0x002201C4,
              ClientSpawn  = 0x00177468,
              Sv_ClientCommand  = 0x00228178,
              Sv_ExecuteClientMessage  = 0x00228B50,
              Sv_ExecuteClientCommand  = 0x00182DEC,
              ClientCommand  = 0x00182440,
              CalculateRanks  = 0x0019031C,
              ClientScr_SetScore  = 0x00176150,
              ClientScr_SetMaxHealth  = 0x00176094,
              Sv_ReceiveStats  = 0x002244E0,
              ClientConnect  = 0x001771A0,
              Sv_DirectConnect  = 0x00255BB4,
              Sv_SetConfigstring  = 0x0022A208,
              Sv_AddServerCommand  = 0x0022CBA0,
              IntermissionClientEndFrame  = 0x001745F8,
              memset = 0x0049B928,
              str_pointer = 0x523b30,
              g_gametype = 0x8360d5;
            }
		}
	}
}
