using System;
using System.Threading;
using PS3Lib;

namespace MW3_Projekt_Infinity_by_RATModz
{
	
	internal class RPCSO
	{
		
		public static void Enable()
		{
			RPCSO.RPCON = true;
			PS3.SetMemory(RPCSO.func_address, new byte[]
			{
				78,
				128,
				0,
				32
			});
			Thread.Sleep(20);
			byte[] bytes = new byte[]
			{
				124,
				8,
				2,
				166,
				248,
				1,
				0,
				128,
				60,
				96,
				16,
				2,
				129,
				131,
				0,
				76,
				44,
				12,
				0,
				0,
				65,
				130,
				0,
				100,
				128,
				131,
				0,
				4,
				128,
				163,
				0,
				8,
				128,
				195,
				0,
				12,
				128,
				227,
				0,
				16,
				129,
				3,
				0,
				20,
				129,
				35,
				0,
				24,
				129,
				67,
				0,
				28,
				129,
				99,
				0,
				32,
				192,
				35,
				0,
				36,
				192,
				67,
				0,
				40,
				192,
				99,
				0,
				44,
				192,
				131,
				0,
				48,
				192,
				163,
				0,
				52,
				192,
				195,
				0,
				56,
				192,
				227,
				0,
				60,
				193,
				3,
				0,
				64,
				193,
				35,
				0,
				72,
				128,
				99,
				0,
				0,
				125,
				137,
				3,
				166,
				78,
				128,
				4,
				33,
				60,
				128,
				16,
				2,
				56,
				160,
				0,
				0,
				144,
				164,
				0,
				76,
				144,
				100,
				0,
				80,
				232,
				1,
				0,
				128,
				124,
				8,
				3,
				166,
				56,
				33,
				0,
				112,
				78,
				128,
				0,
				32
			};
			PS3.SetMemory(RPCSO.func_address + 4u, bytes);
			PS3.SetMemory(268566528u, new byte[10324]);
			PS3.SetMemory(RPCSO.func_address, new byte[]
			{
				248,
				33,
				byte.MaxValue,
				145
			});
		}


        public static byte[] ReverseBytes(byte[] arry)
        {
            Array.Reverse(arry);
            return arry;
        }



        public static void WriteSingle(uint address, float[] input)
        {
            int num = input.Length;
            byte[] array = new byte[num * 4];
            for (int i = 0; i < num; i++)
            {
                RPCSO.ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, i * 4);
            }
            PS3.SetMemory(address, array);
        }

       
        public static int Call(uint func_address, params object[] parameters)
		{
			int result;
			if (RPCSO.RPCON)
			{
				int num = parameters.Length;
				int i = 0;
				uint num2 = 0u;
				uint num3 = 0u;
				uint num4 = 0u;
				uint num5 = 0u;
				while (i < num)
				{
					if (parameters[i] is int)
					{
						PS3.Extension.WriteInt32(268566528u + num2 * 4u, (int)parameters[i]);
						num2 += 1u;
					}
					else if (parameters[i] is uint)
					{
						PS3.Extension.WriteUInt32(268566528u + num2 * 4u, (uint)parameters[i]);
						num2 += 1u;
					}
					else if (parameters[i] is string)
					{
						uint num6 = 268574720u + num3 * 1024u;
						PS3.Extension.WriteString(num6, Convert.ToString(parameters[i]));
						PS3.Extension.WriteUInt32(268566528u + num2 * 4u, num6);
						num2 += 1u;
						num3 += 1u;
					}
					else if (parameters[i] is float)
					{
						PS3.Extension.WriteFloat(268566564u + num4 * 4u, (float)parameters[i]);
						num4 += 1u;
					}
					else if (parameters[i] is float[])
					{
						float[] array = (float[])parameters[i];
						uint num6 = 268570624u + num5 * 4u;
						RPCSO.WriteSingle(num6, array);
						PS3.Extension.WriteUInt32(268566528u + num2 * 4u, num6);
						num2 += 1u;
						num5 += (uint)array.Length;
					}
					i++;
				}
				PS3.Extension.WriteUInt32(268566604u, func_address);
				Thread.Sleep(20);
				result = PS3.Extension.ReadInt32(268566608u);
			}
			else
			{
				result = 0;
			}
			return result;
		}

        private static PS3API PS3 = new PS3API();

        
        private static uint func_address = 3695104u;

		
		public static bool RPCON = false;
	}
}
