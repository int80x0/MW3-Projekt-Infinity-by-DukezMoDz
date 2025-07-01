namespace MW3_Projekt_Infinity_by_RATModz
{
    class Addresses
    {
        public static uint
            G_Client_a = 0x110A280,
            G_Client_Interval_a = 0x3980,
            G_Entity_a = 0xFCA280,
            G_Entity_Interval_a = 0x280,
            G_Client_GetName = 0x3414,
            PartyBoolean = 0x8AA267,
            PartyHostIndex = 0x8AA1EB,
            PartyName = 0x8A8128,
            LobbyHostIndex = 0x89F293,
            LobbyName = 0x89D1D0,
            LobbyPartyID = 0x89D184,
            HostIP = 0x89F266,
            HostPort = 0x89F26A,
            GrabInterval = 0x178,
            LocalName = 0x1BBBC2C,
            CEntity_a = 0x7BD010,
            ClientInfo_a = 0x1FE04C,
            ClientInfo_Size_a = 0x594;
    }

    class statIndex
    {
        public static uint
            Prestige = 0xCA8,
            Experience = 0xA98,
            Score = 0xCB0,
            Wins = 0xD0C,
            Losses = 0xD10,
            Ties = 0xD14,
            Win_Streak = 0xD18,
            Kills = 0xCD8,
            Deaths = 0xCE0,
            RatioKD = 0xD08,
            RatioWL = 0xD20,
            Headshots = 0xCEC,
            Accuracy = 0xD30,
            Assists = 0xCE8,
            Kill_Streak = 0xCDC,
            Game_Played = 0xCB4,
            Time_Played1 = 0xCF8,
            Time_Played2 = 0xCFC,
            Time_Played3 = 0xD04,
            Add_Classes = 0x2B0F,
            Tokens = 0x2B07,
            DoubleXP = 0x2B5D,
            DoubleWeaponXP = 0x2B65,
            Hits = 0xD24,
            Misses = 0xD28,
            TitleIndex = 0x28A6,
            MW_Prestige = 0x2BA2,
            WAW_Prestige = 0x2BA7,
            MW2_Prestige = 0x2BAD,
            BO_Prestige = 0x2BB4,
            ClassName1 = 0x1058,
            ClassName2 = 0x10BA,
            ClassName3 = 0x111C,
            ClassName4 = 0x117E,
            ClassName5 = 0x11E0,
            ClassName6 = 0x1242,
            ClassName7 = 0x12A4,
            ClassName8 = 0x1306,
            ClassName9 = 0x1368,
            ClassName10 = 0x13CA,
            ClassName11 = 0x142C,
            ClassName12 = 0x148E,
            ClassName13 = 0x14F0,
            ClassName14 = 0x1552,
            ClassName15 = 0x15B4,
            PMClassName1 = 0x1616,
            PMClassName2 = 0x1678,
            PMClassName3 = 0x16DA,
            PMClassName4 = 0x173C,
            PMClassName5 = 0x179E,

            GodmodeClass1 = 4235,
            GodmodeClass2 = 4333,
            GodmodeClass3 = 4431,
            GodmodeClass4 = 4529,
            GodmodeClass5 = 4627,
            GodmodeClass6 = 4725,
            GodmodeClass7 = 4823,
            GodmodeClass8 = 4921,
            GodmodeClass9 = 5019,
            GodmodeClass10 = 5117,
            GodmodeClass11 = 5215,
            GodmodeClass12 = 5313,
            GodmodeClass13 = 5411,
            GodmodeClass14 = 5509,
            GodmodeClass15 = 5607,
            PMGodmodeClass1 = 5705,
            PMGodmodeClass2 = 5803,
            PMGodmodeClass3 = 5901,
            PMGodmodeClass4 = 5999,
            PMGodmodeClass5 = 6097,

            UnlockAll0 = 0x17DB, //0x13, 0x02
            UnlockAll1 = 0x8E0, //0xB8, 0x1E...
            UnlockAll2 = 0x28CC, //0xFF, 0xFF...
            UnlockAll3 = 0x181E, //0x0A, 0x0A...
            UnlockAll4 = 0xEB0,

            EliteCamo = 0x2B18;
    }

    class PublicClass1 // Add 0x62 for next Class (max. 20)
    {
        public static uint
            PubPrimary_Weapon = 0x1030, //7 = ACR
            PubPrimWeap_Attach1 = 0x1038, //76 = Radar 75 = Störer
            PubPrimWeap_Attach2 = 0x1032,
            PubPrimWeap_Attach3 = 0x1034,
            PubPrimWeap_Camo = 0x1036, // 13 = Gold
            PubPrimWeap_Visier = 0x103A, // maxValue = 6 // 4 = Best

            PubSecondary_Weapon = 0x103C,
            PubSecWeap_Attach1 = 0x1044, //76 = Radar 75 = Störer
            PubSecWeap_Attach2 = 0x103E,
            PubSecWeap_Attach3 = 0x1040,
            PubSecWeap_Camo = 0x1042, // 13 = Gold
            PubSecWeap_Visier = 0x1046, // maxValue = 6 // 4 = Best

            PubPrimaryGrenade = 0x1048,
            PubSecondaryGrenade = 0x1054,

            PubPerk1 = 0x104A,
            PubPerk2 = 0x104C,
            PubPerk3 = 0x104E,

            PubDeathstreak = 0x106D,

            PubAssault1 = 0x106F,
            PubAssault2 = 0x1071,
            PubAssault3 = 0x1073,

            PubSupport1 = 0x1075,
            PubSupport2 = 0x1077,
            PubSupport3 = 0x1079,

            PubSpecialist1 = 0x107B,
            PubSpecialist2 = 0x107D,
            PubSpecialist3 = 0x107F,

            PubToggleKillStreak = 0x1052; // Storm = 94 // Support = 95 // Specialist = 61
    }
}
