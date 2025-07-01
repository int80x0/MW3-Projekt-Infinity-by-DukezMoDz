using PS3Lib;
using System;
using static MW3_Projekt_Infinity_by_RATModz.Connection;

namespace MW3_Projekt_Infinity_by_RATModz
{
    class GameDetection
    {
        public static string CurrentGame;
        public static string CurrentVersion;
        private static PS3API PS3 = new PS3API();

        public static bool CheckGame(string memory, string regions)
        {
            return regions.Contains(memory);
        }

        public static void GetGame()
        {
            if (IsAttached)
            {
                string MemoryRead = PS3.Extension.ReadString(0x10010251);
                byte MemoryReadMode = PS3.Extension.ReadByte(0x1001D);
                string Regions = "BLUS30838 BLES01428 BLES01429 BLES01430 BLES01431 BLES01432 BLES01433 BLES01434 BLUS30887 BLUS30888";
                CurrentGame = "Unknown";
                CurrentVersion = "Unknown";
                switch (CheckGame(MemoryRead, Regions))
                {
                    case true:
                        CurrentGame = MemoryReadMode == 0x6A ? "Modern Warfare 3 (Special Ops)" : "Modern Warfare 3 (Multiplayer)";
                        CurrentVersion = MemoryRead;
                        break;
                    case false:
                        CurrentGame = "Unknown";
                        CurrentVersion = "Unknown";
                        break;
                    default:
                        CurrentGame = "Unknown";
                        CurrentVersion = "Unknown";
                        break;
                }
            }
            else
            {
                CurrentGame = "Unknown";
                CurrentVersion = "Unknown";
            }
        }
    }
}
