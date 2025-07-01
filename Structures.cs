using System;

namespace MW3_Projekt_Infinity_by_RATModz
{
    class Structures
    {
        public static bool 
            IsInGame,
            IsHostVerified,
            CreatorDetect,
            IsSelectedConnectedPlayer,
            IsStatsActived,
            IsInParty,
            CanActive,
            IsNotBot,
            AntiFreezeClassesBool,
            AntiGmodBool,
            AutoFreezeParty,
            AntiFreezeActived,
            HostNotify;

        public static int
            SelectedPlayerIndex;

        public static uint 
            MyIndex,
            HostIndex;

        public static string 
            OldPerk2 = "",
            CurrentGameMode,
            CurrentGameType = "Unknown";

        public enum WeaponIndex : byte
        {
            None,
            USPTactical,
            MP412,
            Magnum44,
            DesertEagle,
            P99,
            FiveSeven,
            ACR6_8,
            Type95,
            M4A1,
            AK47,
            M16A4,
            MK14,
            CM901,
            G36C,
            SCARL,
            FAD,
            MP5,
            PM9,
            P90,
            PP90M1,
            UMP45,
            MP7,
            FMG9,
            G18,
            MP9,
            SKORPION,
            SPAS12 = 0x1C,
            AA12,
            STRIKER,
            MODEL1887,
            USAS12,
            KSG12,
            M60E4,
            MK46,
            PKPPECHENEG,
            L86LSW,
            MG36,
            BARRETT50,
            MSR,
            RSASS,
            DRAGUNOV,
            AS50,
            L118A,
            RPG7 = 0x2E,
            JAVELIN = 0x35,
            STINGER,
            SMAW,
            M320GLM,
            RiotShield = 0x3F,
            XM25 = 0x42,
            AUGHBAR = 0x5A
        }

        public enum Proficiencies : byte
        {
            None,
            Speed = 0x23,
            Attachments = 0x39,
            Impact = 0x84,
            Kick,
            Focus,
            Breath = 0x88,
            Range,
            Melee,
            Stability,
            Damage
        }

        public enum Attachments : byte
        {
            None,
            RedDotSight,
            ACOGScope,
            Grip,
            Akimbo,
            Thermal,
            Shotgun,
            HeatbeatSensor,
            ExtendedMags = 0x09,
            RapidFire,
            HolographicSight,
            TacticalKnife,
            VariabmeZoomScope,
            GrenadeLauncher,
            Silencer = 0x11,
            HAMRScope = 0x13,
            HybridSight = 0x15
        }

        public enum Camos : byte
        {
            None,
            Classic,
            Snow,
            Multicam,
            Digital_Urban,
            Hex,
            Choco,
            Marine,
            Snake,
            Winter,
            Blue,
            Red,
            Autumn,
            Gold
        }

        public enum Reticle : byte
        {
            None,
            TargetDot,
            Delta,
            UDOT,
            MILDOT,
            Omega,
            Lambda
        }

        public enum Lethal : byte
        {
            None,
            C4 = 0x65,
            Claymore,
            ThrowingKnife = 0x6A,
            Semtex,
            Frag,
            BouncingBetty,
        }

        public enum Tactical : byte
        {
            None,
            Scrambler = 0x4B,
            PortableRadar,
            FlashGrenade = 0x6E,
            SmokeGrenade,
            ConcussionGrenade,
            TrophySystem = 0x72,
            EMPGrenade = 0x75,
            TacticalInsertion = 0x83
        }

        public enum Perks : byte
        {
            None,
            DeadSilence = 0x08,
            ExtremeConditioning,
            Sitrep,
            SteadyAim = 0x0C,
            SleightOfHand = 0x0F,
            Overkill = 0x11,
            Quickdraw = 0x26,
            Scavenger = 0x2B,
            Assasin = 0x30,
            BlindEye,
            Hardline = 0x44,
            Stalker = 0x4A,
            BlastShield = 0x4E,
            Recon = 0x5C,
            Marksman = 0x94,
        }

        public enum StrikePackage : byte
        {
            Assault = 0x5E,
            Support = 0x5F,
            Specialist = 0x61,
        }

        public enum Assault : byte
        {
            None,
            UAV,
            CarePackage,
            PredatorMissile,
            IMS,
            SentryGun,
            PrecisionAirstike = 0x07,
            AttackHelicopter,
            StrafeRun,
            AH6_Overwatch,
            Reaper,
            AssaultDrone,
            Pavelow = 0x0E,
            AC130,
            Juggernaut,
            OspreyGunner = 0x12
        }

        public enum Support : byte
        {
            None,
            UAV = 0x13,
            CounterUAV,
            BallisticVests,
            AirdropTrap,
            SamTurret,
            ReconDrone,
            AdvancedUAV,
            RemoteTurret,
            StealthBomber,
            EMP,
            JuggernautRecon,
            EscortAirdrop = 0x1F
        }

        public enum Specialist : byte
        {
            None,
            ExtremeConditioning = 0x21,
            SleightOfHand,
            Scavenger,
            BlindEye,
            Recon,
            Hardline,
            Assassin,
            Quickdraw,
            Blastshield = 0x2A,
            Sitrep,
            Marksman,
            SteadyAim,
            DeadSilence,
            Stalker
        }

        public enum Deathstreaks : byte
        {
            None,
            Juiced = 0x76,
            Martyrdom,
            FinalStand,
            Revenge = 0x7C,
            DeadMansHead,
            HollowPoint
        }

        public enum GmodeIndex : byte
        {
            None,
            Godmode = 0x6B
        }
    }
}
