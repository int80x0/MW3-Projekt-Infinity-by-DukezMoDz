using PS3Lib;
using System;
using System.Text;
using System.Threading;
using static MW3_Projekt_Infinity_by_RATModz.ACC;
using static MW3_Projekt_Infinity_by_RATModz.Addresses;
using static MW3_Projekt_Infinity_by_RATModz.Functions;
using static MW3_Projekt_Infinity_by_RATModz.PublicClass1;
using static MW3_Projekt_Infinity_by_RATModz.Connection;
using static MW3_Projekt_Infinity_by_RATModz.RPCMP;
using static MW3_Projekt_Infinity_by_RATModz.statIndex;
using static MW3_Projekt_Infinity_by_RATModz.Structures;

namespace MW3_Projekt_Infinity_by_RATModz
{
    
    class ACS
    {
        private static PS3API PS3 = new PS3API();
        private static int ExpValue;
        public static byte GetPrestige(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)Prestige));
        }

        public static byte[] GetScore(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Score), 4);
        }

        public static byte[] GetWins(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Wins), 4);
        }

        public static byte[] GetLosses(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Losses), 4);
        }

        public static byte[] GetTies(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Ties), 4);
        }

        public static byte[] GetWinstreak(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Win_Streak), 4);
        }

        public static byte[] GetKills(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Kills), 4);
        }

        public static byte[] GetDeaths(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Deaths), 4);
        }

        public static byte[] GetHeadshots(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Headshots), 4);
        }

        public static byte[] GetAssists(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Assists), 4);
        }

        public static byte[] GetKillstreak(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Kill_Streak), 4);
        }
        public static int GetSecond()
        {
            decimal num = ((0 * 86400) + (4 * 3600)) + (0 * 60);
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(num.ToString()));
            Array.Reverse(buffer, 0x00, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static int[] GetTimePlayed(int Client)
        {
            byte[] Array1 = PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Time_Played1), 4);
            byte[] Array2 = PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Time_Played2), 4);
            int seconds = BitConverter.ToInt32(Array1, 0) + BitConverter.ToInt32(Array2, 0);
            int daysFromSeconds = GetDaysFromSeconds(seconds);
            int hoursFromSeconds = GetHoursFromSeconds(seconds);
            int minutesFromSeconds = GetMinutesFromSeconds(seconds);
            return new int[] { daysFromSeconds, hoursFromSeconds, minutesFromSeconds };
        }

        public static int[] GetDoubleXP(int Client)
        {
            byte[] array = PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)DoubleXP), 4);
            int seconds = BitConverter.ToInt32(array, 0);
            int daysFromSeconds = GetDaysFromSeconds(seconds);
            int hoursFromSeconds = GetHoursFromSeconds(seconds);
            int minutesFromSeconds = GetMinutesFromSeconds(seconds);
            return new int[] { daysFromSeconds, hoursFromSeconds, minutesFromSeconds };
        }

        public static int[] GetDoubleWeaponXP(int Client)
        {
            byte[] array = PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)DoubleWeaponXP), 4);
            int seconds = BitConverter.ToInt32(array, 0);
            int daysFromSeconds = GetDaysFromSeconds(seconds);
            int hoursFromSeconds = GetHoursFromSeconds(seconds);
            int minutesFromSeconds = GetMinutesFromSeconds(seconds);
            return new int[] { daysFromSeconds, hoursFromSeconds, minutesFromSeconds };
        }

        public static byte[] GetHits(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Hits), 4);
        }

        public static byte[] GetMisses(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Misses), 4);
        }

        public static byte[] GetTokens(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Tokens), 4);
        }

        public static byte[] GetAccuracy(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Accuracy), 4);
        }

        public static byte[] GetRatioKD(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)RatioKD), 4);
        }

        public static byte[] GetGamePlayed(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)Game_Played), 4);
        }

        public static byte[] GetRatioWL(int Client)
        {
            return PS3.Extension.ReadBytes((uint)GetStatAdress(Client, (int)RatioWL), 4);
        }

        public static byte GetAddClasses(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)Add_Classes));
        }

        public static byte GetMWPrestige(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)MW_Prestige));
        }

        public static byte GetWAWPrestige(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)WAW_Prestige));
        }

        public static byte GetMW2Prestige(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)MW2_Prestige));
        }

        public static byte GetBOPrestige(int Client)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)BO_Prestige));
        }

        public static string GetClassesName(int Client, int ClassIndex)
        {
            return PS3.Extension.ReadString((uint)GetStatAdress(Client, (int)ClassName1 + (ClassIndex * 0x62)));
        }

        public static bool GetGodmode(int Client, int ClassIndex)
        {
            return PS3.Extension.ReadByte((uint)GetStatAdress(Client, (int)GodmodeClass1 + (ClassIndex * 0x62))) != 0x00;
        }

        public static void SetPrestige(int Client, byte Value)
        {
            SetStats<byte>(Client, Prestige, Value);
        }

        public static void SetLevel(int Client, int Value)
        {
            if (Value == 0)
                ExpValue = 0;
            else if (Value == 2)
                ExpValue = 800;
            else if (Value == 3)
                ExpValue = 1900;
            else if (Value == 4)
                ExpValue = 3100;
            else if (Value == 5)
                ExpValue = 4900;
            else if (Value == 6)
                ExpValue = 7100;
            else if (Value == 7)
                ExpValue = 9600;
            else if (Value == 8)
                ExpValue = 12400;
            else if (Value == 9)
                ExpValue = 15600;
            else if (Value == 10)
                ExpValue = 19200;
            else if (Value == 11)
                ExpValue = 23100;
            else if (Value == 12)
                ExpValue = 27500;
            else if (Value == 13)
                ExpValue = 32400;
            else if (Value == 14)
                ExpValue = 37800;
            else if (Value == 15)
                ExpValue = 43700;
            else if (Value == 16)
                ExpValue = 50100;
            else if (Value == 17)
                ExpValue = 57000;
            else if (Value == 18)
                ExpValue = 64400;
            else if (Value == 19)
                ExpValue = 72300;
            else if (Value == 20)
                ExpValue = 80700;
            else if (Value == 21)
                ExpValue = 89600;
            else if (Value == 22)
                ExpValue = 99000;
            else if (Value == 23)
                ExpValue = 108900;
            else if (Value == 24)
                ExpValue = 119300;
            else if (Value == 25)
                ExpValue = 130200;
            else if (Value == 26)
                ExpValue = 141600;
            else if (Value == 27)
                ExpValue = 153500;
            else if (Value == 28)
                ExpValue = 165900;
            else if (Value == 29)
                ExpValue = 178800;
            else if (Value == 30)
                ExpValue = 192200;
            else if (Value == 31)
                ExpValue = 206200;
            else if (Value == 32)
                ExpValue = 220800;
            else if (Value == 33)
                ExpValue = 236000;
            else if (Value == 34)
                ExpValue = 251800;
            else if (Value == 35)
                ExpValue = 268200;
            else if (Value == 36)
                ExpValue = 285200;
            else if (Value == 37)
                ExpValue = 302800;
            else if (Value == 38)
                ExpValue = 321000;
            else if (Value == 39)
                ExpValue = 339800;
            else if (Value == 40)
                ExpValue = 359200;
            else if (Value == 41)
                ExpValue = 379200;
            else if (Value == 42)
                ExpValue = 399800;
            else if (Value == 43)
                ExpValue = 421000;
            else if (Value == 44)
                ExpValue = 442800;
            else if (Value == 45)
                ExpValue = 465200;
            else if (Value == 46)
                ExpValue = 488200;
            else if (Value == 47)
                ExpValue = 511800;
            else if (Value == 48)
                ExpValue = 536000;
            else if (Value == 49)
                ExpValue = 560800;
            else if (Value == 50)
                ExpValue = 586200;
            else if (Value == 51)
                ExpValue = 612350;
            else if (Value == 52)
                ExpValue = 639250;
            else if (Value == 53)
                ExpValue = 666900;
            else if (Value == 54)
                ExpValue = 695300;
            else if (Value == 55)
                ExpValue = 724450;
            else if (Value == 56)
                ExpValue = 754350;
            else if (Value == 57)
                ExpValue = 785000;
            else if (Value == 58)
                ExpValue = 816400;
            else if (Value == 59)
                ExpValue = 848550;
            else if (Value == 60)
                ExpValue = 881450;
            else if (Value == 61)
                ExpValue = 915100;
            else if (Value == 62)
                ExpValue = 949500;
            else if (Value == 63)
                ExpValue = 984650;
            else if (Value == 64)
                ExpValue = 1020550;
            else if (Value == 65)
                ExpValue = 1057200;
            else if (Value == 66)
                ExpValue = 1094600;
            else if (Value == 67)
                ExpValue = 1132750;
            else if (Value == 68)
                ExpValue = 1171650;
            else if (Value == 69)
                ExpValue = 1211300;
            else if (Value == 70)
                ExpValue = 1251700;
            else if (Value == 71)
                ExpValue = 1292850;
            else if (Value == 72)
                ExpValue = 1334500;
            else if (Value == 73)
                ExpValue = 1377150;
            else if (Value == 74)
                ExpValue = 1420300;
            else if (Value == 75)
                ExpValue = 1464450;
            else if (Value == 76)
                ExpValue = 1509100;
            else if (Value == 77)
                ExpValue = 1554750;
            else if (Value == 78)
                ExpValue = 1600900;
            else if (Value == 79)
                ExpValue = 1648050;
            else if (Value == 80)
                ExpValue = 1746200;
            SetStats<int>(Client, Experience, ExpValue);
        }

        public static void SetScore(int Client, int Value)
        {
            SetStats<int>(Client, Score, Value);
        }

        public static void SetWins(int Client, int Value)
        {
            SetStats<int>(Client, Wins, Value);
        }

        public static void SetLosses(int Client, int Value)
        {
            SetStats<int>(Client, Losses, Value);
        }

        public static void SetTies(int Client, int Value)
        {
            SetStats<int>(Client, Ties, Value);
        }

        public static void SetWinstreak(int Client, int Value)
        {
            SetStats<int>(Client, Win_Streak, Value);
        }

        public static void SetKills(int Client, int Value)
        {
            SetStats<int>(Client, Kills, Value);
        }

        public static void SetDeaths(int Client, int Value)
        {
            SetStats<int>(Client, Deaths, Value);
        }

        public static void SetHeadshots(int Client, int Value)
        {
            SetStats<int>(Client, Headshots, Value);
        }

        public static void SetAssists(int Client, int Value)
        {
            SetStats<int>(Client, Assists, Value);
        }

        public static void SetKillstreak(int Client, int Value)
        {
            SetStats<int>(Client, Kill_Streak, Value);
        }

        public static void SetTimePlayed(int Client, int Days, int Hours, int Minutes)
        {
            int Value = ((Days * 86400) + (Hours * 3600)) + (Minutes * 60);
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Value.ToString()));
            SetStats<byte[]>(Client, Time_Played1, bytes);
            SetStats<byte[]>(Client, Time_Played3, bytes);
        }

        public static void SetDoubleXP(int Client, int Days, int Hours, int Minutes)
        {
            int Value = ((Days * 86400) + (Hours * 3600)) + (Minutes * 60);
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Value.ToString()));
            SetStats<byte[]>(Client, DoubleXP, bytes);
        }

        public static void SetDoubleWeaponXP(int Client, int Days, int Hours, int Minutes)
        {
            int Value = ((Days * 86400) + (Hours * 3600)) + (Minutes * 60);
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Value.ToString()));
            SetStats<byte[]>(Client, DoubleWeaponXP, bytes);
        }

        public static void SetHits(int Client, int Value)
        {
            SetStats<int>(Client, Hits, Value);
        }

        public static void SetMisses(int Client, int Value)
        {
            SetStats<int>(Client, Misses, Value);
        }

        public static void SetTokens(int Client, int Value)
        {
            SetStats<int>(Client, Tokens, Value);
        }

        public static void SetRatioKD(int Client, int Value)
        {
            SetStats<int>(Client, RatioKD, Value);
        }

        public static void SetAccuracy(int Client, int Value)
        {
            SetStats<int>(Client, Accuracy, Value);
        }

        public static void SetGamePlayed(int Client, int Value)
        {
            SetStats<int>(Client, Game_Played, Value);
        }

        public static void SetAddClasses(int Client, byte Value)
        {
            SetStats<byte>(Client, Add_Classes, Value);
        }

        public static void SetMWPrestige(int Client, byte Value)
        {
            SetStats<byte>(Client, MW_Prestige, Value);
        }

        public static void SetWAWPrestige(int Client, byte Value)
        {
            SetStats<byte>(Client, WAW_Prestige, Value);
        }

        public static void SetMW2Prestige(int Client, byte Value)
        {
            SetStats<byte>(Client, MW2_Prestige, Value);
        }

        public static void SetBOPrestige(int Client, byte Value)
        {
            SetStats<byte>(Client, BO_Prestige, Value);
        }

        public static void SetClassName(int Client, uint Class, string Text)
        {
            SetStats<string>(Client, ClassName1 + (Class * 0x62), Text + "\0");
            Thread.Sleep(50);
        }

        public static void SetClassNameUTF8(int Client, uint Class, string Text)
        {
            SetStatsUTF8<string>(Client, ClassName1 + (Class * 0x62), Text + "\0");
            Thread.Sleep(50);
        }

        /*public static void SetAugHbar(int Client = 0, uint Class = 0)
        {
            SetStats<int>(Client, PubPrimary_Weapon + Class * 0x62, 0x5A);
            SetStats<int>(Client, PubPrimWeap_Attach1 + Class * 0x62, 0x11);
            SetStats<int>(Client, PubPrimWeap_Camo + Class * 0x62, 0x0A);
            SetStats<int>(Client, PubSecondary_Weapon + Class * 0x62, 0x35);
        }

        public static void GiveGodmodeClasses(int Client = 0, uint Class = 0)
        {
            SetStats<byte>(Client, GodmodeClass1 + (0x62 * Class), 0x6B);
            SetStats<byte>(Client, PubToggleKillStreak + (0x62 * Class), 0x61);
        }*/

        public static void RemoveGodmodeClasses(int clientIndex)
        {
            bool Notify = false;
            for (uint i = 0; i < 15; i++)
            {
                if (GetGodmode(clientIndex, (int)i))
                {
                    SetGodmode(clientIndex, i, GmodeIndex.None);
                    Notify = true;
                }
                if (i < 5)
                {
                    if (GetGodmode(clientIndex, (int)i + 15))
                    {
                        SetGodmode(clientIndex, i + 15, GmodeIndex.None);
                        Notify = true;
                    }
                }
            }
            if (Notify)
            {
                iPrintln($"^2{PS3.Extension.ReadString(G_Client((uint)clientIndex, G_Client_GetName))} ^7Godmode classes ^1removed");
                Notify = false;
            }
        }

        public static void UnlockAll(int Client)
        {
            byte[] bytes = new byte[2] { 0x13, 0x02 };
            byte[] bytes2 = new byte[128] { 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38, 0x1E, 0x38 };
            byte[] bytes3 = new byte[104] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            byte[] bytes4 = new byte[192] { 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A, 0x0A };

            SetStats<byte[]>(Client, UnlockAll0, bytes);
            for (uint i = 0; i < 0x2C4; i += 128)
            {
                SetStats<byte[]>(Client, (UnlockAll1 + i), bytes2);
                Thread.Sleep(20);
            }
            for (uint i = 0; i < 0xCF; i += 104)
            {
                SetStats<byte[]>(Client, (UnlockAll2 + i), bytes3);
                Thread.Sleep(55);
            }
            for (uint i = 0; i < 0x1064; i += 192)
            {
                SetStats<byte[]>(Client, (UnlockAll3 + i), bytes4);
                Thread.Sleep(50);
            }
            SetStats<byte>(Client, EliteCamo, 0xFF);
            SetStats<int>(Client, TitleIndex, 160);
            iPrintln(Client, "Unlock All ^2Finished");
            iPrintln($"Unlock All Finish to ^2" + PS3.Extension.ReadString(G_Client((uint)Client, G_Client_GetName)));
        }

        public static void Derank(int Client, bool Full)
        {
            byte[] bytes = new byte[2] { 0x00, 0x00 };
            byte[] bytes2 = new byte[128] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] bytes3 = new byte[104] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] bytes4 = new byte[192] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            SetStats<byte[]>(Client, UnlockAll0, bytes);
            for (uint i = 0; i < 0x2C4; i += 128)
            {
                SetStats<byte[]>(Client, (UnlockAll1 + i), bytes2);
                Thread.Sleep(20);
            }
            for (uint i = 0; i < 0xCF; i += 104)
            {
                SetStats<byte[]>(Client, (UnlockAll2 + i), bytes3);
                Thread.Sleep(55);
            }
            for (uint i = 0; i < 0x1064; i += 192)
            {
                SetStats<byte[]>(Client, (UnlockAll3 + i), bytes4);
                Thread.Sleep(50);
            }
            SetStats<byte>(Client, EliteCamo, 0);
            SetStats<byte>(Client, Prestige, 0);
            SetStats<int>(Client, Experience, 0);
            SetStats<int>(Client, Score, 0);
            SetStats<int>(Client, Wins, 0);
            SetStats<int>(Client, Losses, 0);
            SetStats<int>(Client, Ties, 0);
            SetStats<int>(Client, Win_Streak, 0);
            SetStats<int>(Client, Kills, 0);
            SetStats<int>(Client, Deaths, 0);
            SetStats<int>(Client, Headshots, 0);
            SetStats<int>(Client, Assists, 0);
            SetStats<int>(Client, Kill_Streak, 0);
            SetStats<int>(Client, Game_Played, 0);
            SetStats<int>(Client, Time_Played1, 0);
            SetStats<int>(Client, Time_Played2, 0);
            SetStats<int>(Client, Time_Played3, 0);
            SetStats<int>(Client, DoubleXP, 0);
            SetStats<int>(Client, DoubleWeaponXP, 0);
            SetStats<int>(Client, Hits, 0);
            SetStats<int>(Client, Misses, 0);
            SetStats<int>(Client, Tokens, 0);
            SetStats<int>(Client, Accuracy, 0);
            SetStats<int>(Client, RatioKD, 0);
            SetStats<int>(Client, RatioWL, 0);
            SetStats<byte>(Client, Add_Classes, 0);
            SetStats<byte>(Client, MW_Prestige, 0);
            SetStats<byte>(Client, WAW_Prestige, 0);
            SetStats<byte>(Client, MW2_Prestige, 0);
            SetStats<byte>(Client, BO_Prestige, 0);
            RemoveGodmodeClasses(Client);
            SetClassName(Client, 0, "^1DerankbyRATModz");
            SetClassName(Client, 1, "^2DerankbyRATModz");
            SetClassName(Client, 2, "^3DerankbyRATModz");
            SetClassName(Client, 3, "^5DerankbyRATModz");
            SetClassName(Client, 4, "^6DerankbyRATModz");
            SetClassName(Client, 5, "^1DerankbyRATModz");
            SetClassName(Client, 6, "^2DerankbyRATModz");
            SetClassName(Client, 7, "^3DerankbyRATModz");
            SetClassName(Client, 8, "^5DerankbyRATModz");
            SetClassName(Client, 9, "^6DerankbyRATModz");
            SetClassName(Client, 10, "^1DerankbyRATModz");
            SetClassName(Client, 11, "^2DerankbyRATModz");
            SetClassName(Client, 12, "^3DerankbyRATModz");
            SetClassName(Client, 13, "^5DerankbyRATModz");
            SetClassName(Client, 14, "^6DerankbyRATModz");
            SetClassName(Client, 15, "^1DerankbyRATModz");
            SetClassName(Client, 16, "^2DerankbyRATModz");
            SetClassName(Client, 17, "^3DerankbyRATModz");
            SetClassName(Client, 18, "^5DerankbyRATModz");
            SetClassName(Client, 19, "^6DerankbyRATModz");
            if (Full)
            {
                for(uint i = 0; i < 20; i++)
                {
                    SetPrimaryProficiencies(Client, i, Proficiencies.None);
                    SetPrimaryAttachments1(Client, i, Attachments.None);
                    SetPrimaryAttachments2(Client, i, Attachments.None);
                    SetSecondaryProficiencies(Client, i, Proficiencies.None);
                    SetSecondaryAttachments1(Client, i, Attachments.None);
                    SetSecondaryAttachments2(Client, i, Attachments.None);
                    SetLethal(Client, i, Lethal.None);
                    SetTactical(Client, i, Tactical.None);
                    SetStrikePackage(Client, i, StrikePackage.Assault);
                    SetDeathstreak(Client, i, Deathstreaks.None);
                }
            }
            iPrintln($"Derank Finish to ^2" + PS3.Extension.ReadString(G_Client((uint)Client, G_Client_GetName)));
        }

        public static int GetDaysFromSeconds(int seconds)
        {
            return (int)(seconds / (int)86400);
        }

        public static int GetHoursFromSeconds(int seconds)
        {
            int temp = seconds - ((int)((GetDaysFromSeconds(seconds) * 24) * 60) * 60);
            return (int)(temp / (int)3600);
        }

        public static int GetMinutesFromSeconds(int seconds)
        {
            int temp = seconds - ((int)((GetDaysFromSeconds(seconds) * 24) * 60) * 60);
            temp -= (int)((GetHoursFromSeconds(seconds) * 60) * 60);
            return (int)(temp / (int)60);
        }

        public static float GetRatioAC(int a, int b) // Accuracy ratio
        {
            return (float)(((float)a / ((float)a + (float)b)) * 100);
        }

        public static float GetRatioKW(int a, int b) // Kill & Wins ratio
        {
            if (b == 0) b = 1;
            return (float)((float)a / (float)b);
        }

        public static int GetStatAdress(int Client, int Index)
        {
            return (getClient_t(Client) + 0x31CED + Index);
        }

        public static int getClient_t(int clientNum)
        {
            return (PS3.Extension.ReadInt32(0x17BB210)) + (clientNum * 0x68B80);
        }

        public static void SV_SendClientStatMessage(int clientIndex, msg_t msg)
        {
            PS3.SetMemory(0x1040000, msg.GetBytes());
            Call(0x22CFEC, getClient_t(clientIndex), 1, 0x1040000);
            PS3.SetMemory(0x1040000, new byte[msg.GetBytes().Length]);
        }

        private static void SetStat(int clientIndex, uint index, byte[] value)
        {
            msg_t msg = new msg_t();
            msg.Append<byte>((byte)0x5A, false);
            msg.Append<byte>((byte)0, false);
            msg.Append<ushort>((ushort)(value.Length + 4), false);
            msg.Append<byte>((byte)0x47, false);
            msg.Append<ushort>((ushort)index, false);
            msg.Append<byte>((byte)value.Length, false);
            msg.Append<byte[]>((byte[])value, false);
            SV_SendClientStatMessage(clientIndex, msg);
        }

        private static void SetStatUTF8(int clientIndex, uint index, byte[] value)
        {
            msg_t msg = new msg_t();
            msg.AppendUTF8<byte>((byte)0x5A, false);
            msg.AppendUTF8<byte>((byte)0, false);
            msg.AppendUTF8<ushort>((ushort)(value.Length + 4), false);
            msg.AppendUTF8<byte>((byte)0x47, false);
            msg.AppendUTF8<ushort>((ushort)index, false);
            msg.AppendUTF8<byte>((byte)value.Length, false);
            msg.AppendUTF8<byte[]>((byte[])value, false);
            SV_SendClientStatMessage(clientIndex, msg);
        }

        private static bool IsValidType(Type t)
        {
            return (t == typeof(bool) || t == typeof(byte) || (t == typeof(short) || t == typeof(int)) || (t == typeof(long) || t == typeof(ushort) || (t == typeof(uint) || t == typeof(ulong))) || (t == typeof(float) || t == typeof(double) || t == typeof(string)) ? 0 : (!(t == typeof(byte[])) ? 1 : 0)) == 0;
        }

        public static void SetStats<T>(int clientIndex, uint index, T value, bool littleEndian = true)
        {
            Type t = typeof(T);
            if (!IsValidType(t))
                throw new Exception("Client.SetStat: Invalid type!");
            if (t == typeof(string))
            {
                string s = (string)(object)value;
                SetStat(clientIndex, index, Encoding.Default.GetBytes(s));
                return;
            }
            else if (t == typeof(byte[]))
            {
                SetStat(clientIndex, index, (byte[])(object)value);
                return;
            }
            else if (t == typeof(byte))
            {
                SetStat(clientIndex, index, new byte[1] { (byte)(object)value });
                return;
            }
            var bytes = typeof(BitConverter).GetMethod("GetBytes", new Type[] { value.GetType() }).Invoke(null, new object[] { value });
            if (!littleEndian)
                Array.Reverse((byte[])bytes);
            SetStat(clientIndex, index, (byte[])bytes);
            Thread.Sleep(20);
        }

        public static void SetStatsUTF8<T>(int clientIndex, uint index, T value, bool littleEndian = true)
        {
            Type t = typeof(T);
            if (!IsValidType(t))
                throw new Exception("Client.SetStat: Invalid type!");
            if (t == typeof(string))
            {
                string s = (string)(object)value;
                SetStatUTF8(clientIndex, index, Encoding.UTF8.GetBytes(s));
                return;
            }
            else if (t == typeof(byte[]))
            {
                SetStatUTF8(clientIndex, index, (byte[])(object)value);
                return;
            }
            else if (t == typeof(byte))
            {
                SetStatUTF8(clientIndex, index, new byte[1] { (byte)(object)value });
                return;
            }
            var bytes = typeof(BitConverter).GetMethod("GetBytes", new Type[] { value.GetType() }).Invoke(null, new object[] { value });
            if (!littleEndian)
                Array.Reverse((byte[])bytes);
            SetStatUTF8(clientIndex, index, (byte[])bytes);
            Thread.Sleep(20);
        }

        public class msg_t
        {
            public uint DataBuffer;
            public uint CommandSize;
            public uint MessageLength;
            public bool Overflowed;

            public msg_t()
            {
                CommandSize = 0x400;
                DataBuffer = 0x1050000;
                MessageLength = 0U;
                Overflowed = false;
            }

            private void UpdateOverflowedBoolean()
            {
                if (MessageLength <= CommandSize)
                    return;
                Overflowed = true;
            }

            private bool IsValidType(Type t)
            {
                return (t == typeof(bool) || t == typeof(byte) || (t == typeof(short) || t == typeof(int)) || (t == typeof(long) || t == typeof(ushort) || (t == typeof(uint) || t == typeof(ulong))) || (t == typeof(float) || t == typeof(double) || t == typeof(string)) ? 0 : (!(t == typeof(byte[])) ? 1 : 0)) == 0;
            }

            public void Append<T>(T value, bool littleEndian = false)
            {
                Type t = typeof(T);
                if (!IsValidType(t))
                    throw new Exception("msg_t.AppendMessage: Invalid type!");
                if (t == typeof(bool))
                {
                    PS3.Extension.WriteInt32(DataBuffer + MessageLength, (bool)(object)value ? 1 : 0);
                    MessageLength += 0x4;
                }
                else if (t == typeof(string))
                {
                    PS3.Extension.WriteString(DataBuffer + MessageLength, (string)(object)value);
                    MessageLength += (uint)Encoding.Default.GetBytes((string)(object)value).Length;
                }
                else if (t == typeof(byte[]))
                {
                    byte[] Bytes = (byte[])(object)value;
                    PS3.SetMemory(DataBuffer + MessageLength, Bytes);
                    MessageLength += (uint)Bytes.Length;
                }
                else if (t == typeof(byte))
                {
                    PS3.Extension.WriteByte(DataBuffer + MessageLength, (byte)(object)value);
                    ++MessageLength;
                }
                else
                {
                    var Bytes = typeof(BitConverter).GetMethod("GetBytes", new Type[1] { value.GetType() }).Invoke(null, new object[1] { value });
                    byte[] data = (byte[])Bytes;
                    if (!littleEndian)
                        Array.Reverse((Array)Bytes);
                    PS3.SetMemory(DataBuffer + MessageLength, data);
                    MessageLength += (uint)data.Length;
                }
                UpdateOverflowedBoolean();
            }

            public void AppendUTF8<T>(T value, bool littleEndian = false)
            {
                Type t = typeof(T);
                if (!IsValidType(t))
                    throw new Exception("msg_t.AppendMessage: Invalid type!");
                if (t == typeof(bool))
                {
                    PS3.Extension.WriteInt32(DataBuffer + MessageLength, (bool)(object)value ? 1 : 0);
                    MessageLength += 0x4;
                }
                else if (t == typeof(string))
                {
                    PS3.Extension.WriteString(DataBuffer + MessageLength, (string)(object)value);
                    MessageLength += (uint)Encoding.UTF8.GetBytes((string)(object)value).Length;
                }
                else if (t == typeof(byte[]))
                {
                    byte[] Bytes = (byte[])(object)value;
                    PS3.SetMemory(DataBuffer + MessageLength, Bytes);
                    MessageLength += (uint)Bytes.Length;
                }
                else if (t == typeof(byte))
                {
                    PS3.Extension.WriteByte(DataBuffer + MessageLength, (byte)(object)value);
                    ++MessageLength;
                }
                else
                {
                    var Bytes = typeof(BitConverter).GetMethod("GetBytes", new Type[1] { value.GetType() }).Invoke(null, new object[1] { value });
                    byte[] data = (byte[])Bytes;
                    if (!littleEndian)
                        Array.Reverse((Array)Bytes);
                    PS3.SetMemory(DataBuffer + MessageLength, data);
                    MessageLength += (uint)data.Length;
                }
                UpdateOverflowedBoolean();
            }

            public byte[] GetBytes()
            {
                if (Overflowed)
                    throw new Exception("msg_t.GetBytes: Message overflowed buffer!");
                byte[] BytesArray = new Byte[0x18];
                PS3Lib.ArrayBuilder arrayBuilder = new PS3Lib.ArrayBuilder(BytesArray);
                arrayBuilder.Write.SetUInt32(0, 0U, PS3Lib.EndianType.BigEndian);
                arrayBuilder.Write.SetUInt32(0x4, 0U, PS3Lib.EndianType.BigEndian);
                arrayBuilder.Write.SetUInt32(0x8, DataBuffer, PS3Lib.EndianType.BigEndian);
                arrayBuilder.Write.SetUInt32(0xC, 0U, PS3Lib.EndianType.BigEndian);
                arrayBuilder.Write.SetUInt32(0x10, CommandSize, PS3Lib.EndianType.BigEndian);
                arrayBuilder.Write.SetUInt32(0x14, MessageLength, PS3Lib.EndianType.BigEndian);
                return BytesArray;
            }
        }

        public static void GScr_MakeDvarServerInfo(string dvarName, string value)
        {
            int dvar = Call(0x294450, dvarName, value, 2);
            uint ofs = (uint)dvar + 4;
            if ((PS3.Extension.ReadBool(ofs)))
                Call(0x2946EC, dvar, 0x10);
        }

        public static void ValidStats()
        {
            CanActive = false;
            if (IsInGame)
                GScr_MakeDvarServerInfo("motd", "^1Infected ^2by ^3RATModz");
            if (IsInGame)
                GScr_MakeDvarServerInfo("iotdText", "^1Infected ^2by ^3RATModz");
            if (IsInGame)
                GScr_MakeDvarServerInfo("pdc", "0");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_drop_on_fail", "0");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_apply_clamps", "0");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_apply_revert", "0");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_apply_revert_full", "0");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_experience", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_weaponXP", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_kills", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_assists", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_headshots", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_wins", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_losses", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_ties", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_hits", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_misses", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("validate_clamp_totalshots", "1342177280");
            if (IsInGame)
                GScr_MakeDvarServerInfo("dw_leaderboard_write_active", "1");
            if (IsInGame)
                GScr_MakeDvarServerInfo("matchdata_active", "1");
            CanActive = true;
        }
    }
}
