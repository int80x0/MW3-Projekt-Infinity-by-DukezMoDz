using PS3Lib;
using static MW3_Projekt_Infinity_by_RATModz.ACS;
using static MW3_Projekt_Infinity_by_RATModz.PublicClass1;
using static MW3_Projekt_Infinity_by_RATModz.statIndex;
using static MW3_Projekt_Infinity_by_RATModz.Structures;

namespace MW3_Projekt_Infinity_by_RATModz
{
    class ACC
    {

        private static PS3API PS3 = new PS3API();
        public static void SetPrimaryWeapon(int Client, uint ClassIndex, WeaponIndex Weapon)
        {
            SetStats<byte>(Client, PubPrimary_Weapon + (ClassIndex * 0x62), (byte)Weapon);
        }

        public static void SetPrimaryProficiencies(int Client, uint ClassIndex, Proficiencies Proficiency)
        {
            SetStats<byte>(Client, PubPrimWeap_Attach1 + (ClassIndex * 0x62), (byte)Proficiency);
        }

        public static void SetPrimaryAttachments1(int Client, uint ClassIndex, Attachments attach)
        {
            SetStats<byte>(Client, PubPrimWeap_Attach2 + (ClassIndex * 0x62), (byte)attach);
        }

        public static void SetPrimaryAttachments2(int Client, uint ClassIndex, Attachments attach)
        {
            SetStats<byte>(Client, PubPrimWeap_Attach3 + (ClassIndex * 0x62), (byte)attach);
        }

        public static void SetPrimaryReticle(int Client, uint ClassIndex, Reticle Reticle)
        {
            SetStats<byte>(Client, PubPrimWeap_Visier + (ClassIndex * 0x62), (byte)Reticle);
        }

        public static void SetPrimaryCamos(int Client, uint ClassIndex, Camos Camo)
        {
            SetStats<byte>(Client, PubPrimWeap_Camo + (ClassIndex * 0x62), (byte)Camo);
        }

        public static void SetSecondaryWeapon(int Client, uint ClassIndex, WeaponIndex Weapon)
        {
            SetStats<byte>(Client, PubSecondary_Weapon + (ClassIndex * 0x62), (byte)Weapon);
        }

        public static void SetSecondaryProficiencies(int Client, uint ClassIndex, Proficiencies Proficiency)
        {
            SetStats<byte>(Client, PubSecWeap_Attach1 + (ClassIndex * 0x62), (byte)Proficiency);
        }

        public static void SetSecondaryAttachments1(int Client, uint ClassIndex, Attachments attach)
        {
            SetStats<byte>(Client, PubSecWeap_Attach2 + (ClassIndex * 0x62), (byte)attach);
        }

        public static void SetSecondaryAttachments2(int Client, uint ClassIndex, Attachments attach)
        {
            SetStats<byte>(Client, PubSecWeap_Attach3 + (ClassIndex * 0x62), (byte)attach);
        }

        public static void SetSecondaryReticle(int Client, uint ClassIndex, Reticle Reticle)
        {
            SetStats<byte>(Client, PubSecWeap_Visier + (ClassIndex * 0x62), (byte)Reticle);
        }

        public static void SetSecondaryCamos(int Client, uint ClassIndex, Camos Camo)
        {
            SetStats<byte>(Client, PubSecWeap_Camo + (ClassIndex * 0x62), (byte)Camo);
        }

        public static void SetLethal(int Client, uint ClassIndex, Lethal Lethal)
        {
            SetStats<byte>(Client, PubPrimaryGrenade + (ClassIndex * 0x62), (byte)Lethal);
        }

        public static void SetTactical(int Client, uint ClassIndex, Tactical Tactical)
        {
            SetStats<byte>(Client, PubSecondaryGrenade + (ClassIndex * 0x62), (byte)Tactical);
        }

        public static void SetPerk1(int Client, uint ClassIndex, Perks Perk)
        {
            SetStats<byte>(Client, PubPerk1 + (ClassIndex * 0x62), (byte)Perk);
        }

        public static void SetPerk2(int Client, uint ClassIndex, Perks Perk)
        {
            SetStats<byte>(Client, PubPerk2 + (ClassIndex * 0x62), (byte)Perk);
        }

        public static void SetPerk3(int Client, uint ClassIndex, Perks Perk)
        {
            SetStats<byte>(Client, PubPerk3 + (ClassIndex * 0x62), (byte)Perk);
        }

        public static void SetStrikePackage(int Client, uint ClassIndex, StrikePackage StrikePackage)
        {
            SetStats<byte>(Client, PubToggleKillStreak + (ClassIndex * 0x62), (byte)StrikePackage);
        }

        public static void SetAssault1(int Client, uint ClassIndex, Assault Assault)
        {
            SetStats<byte>(Client, PubAssault1 + (ClassIndex * 0x62), (byte)Assault);
        }

        public static void SetAssault2(int Client, uint ClassIndex, Assault Assault)
        {
            SetStats<byte>(Client, PubAssault2 + (ClassIndex * 0x62), (byte)Assault);
        }

        public static void SetAssault3(int Client, uint ClassIndex, Assault Assault)
        {
            SetStats<byte>(Client, PubAssault3 + (ClassIndex * 0x62), (byte)Assault);
        }

        public static void SetSupport1(int Client, uint ClassIndex, Support Support)
        {
            SetStats<byte>(Client, PubSupport1 + (ClassIndex * 0x62), (byte)Support);
        }

        public static void SetSupport2(int Client, uint ClassIndex, Support Support)
        {
            SetStats<byte>(Client, PubSupport2 + (ClassIndex * 0x62), (byte)Support);
        }

        public static void SetSupport3(int Client, uint ClassIndex, Support Support)
        {
            SetStats<byte>(Client, PubSupport3 + (ClassIndex * 0x62), (byte)Support);
        }

        public static void SetSpecialist1(int Client, uint ClassIndex, Specialist Specialist)
        {
            SetStats<byte>(Client, PubSpecialist1 + (ClassIndex * 0x62), (byte)Specialist);
        }

        public static void SetSpecialist2(int Client, uint ClassIndex, Specialist Specialist)
        {
            SetStats<byte>(Client, PubSpecialist2 + (ClassIndex * 0x62), (byte)Specialist);
        }

        public static void SetSpecialist3(int Client, uint ClassIndex, Specialist Specialist)
        {
            SetStats<byte>(Client, PubSpecialist3 + (ClassIndex * 0x62), (byte)Specialist);
        }

        public static void SetDeathstreak(int Client, uint ClassIndex, Deathstreaks Deathstreaks)
        {
            SetStats<byte>(Client, PubDeathstreak + (ClassIndex * 0x62), (byte)Deathstreaks);
        }

        public static void SetGodmode(int Client, uint ClassIndex, GmodeIndex GmodeIndex)
        {
            SetStats<byte>(Client, GodmodeClass1 + (ClassIndex * 0x62), (byte)GmodeIndex);
        }
    }
}
