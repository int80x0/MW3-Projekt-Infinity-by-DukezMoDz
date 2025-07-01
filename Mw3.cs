using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PS3Lib;
using SNMAPINetLib;
using MetroFramework;
using MetroFramework.Forms;
using System.Threading;
using PS3Lib.NET;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
//using MW3_Projekt_Infinity_by_RATModz.Properties;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Runtime.Versioning;
using System.Security;
using static MW3_Projekt_Infinity_by_RATModz.ACC;
using static MW3_Projekt_Infinity_by_RATModz.ACS;
using static MW3_Projekt_Infinity_by_RATModz.Addresses;
using static MW3_Projekt_Infinity_by_RATModz.Connection;
using static MW3_Projekt_Infinity_by_RATModz.Functions;
using static MW3_Projekt_Infinity_by_RATModz.GameDetection;
using static MW3_Projekt_Infinity_by_RATModz.RPCMP;
using static MW3_Projekt_Infinity_by_RATModz.statIndex;
using static MW3_Projekt_Infinity_by_RATModz.Structures;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class Mw3 : Form
    {
        static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        public Thread JetThread;
        public static uint DestroyCarousel;
        public static uint SV_GameSendServerCommand2 = 2265000u;
        public static uint uint_20 = 2265000u;
        public static bool KarouselBool = false;
        private static string pathOfEboot;
        public int NameChangerZahl;
        public static uint CopyDome;
        public static uint[] CarouselDesroy = new uint[88];
        public static float KarouselYaw = 0f;
        public static uint[] CarePackageSurferDelete = new uint[18];
        public static float[] TrampolinOrigin;
        public static Thread JumpThread;
        public static bool SetMemoryBool = true;
        public static bool JetPackOn = false;
        public static int HostJump = 0;
        public static uint[] TrampolinDelete;
        public static float[] Trickshot;
        public static string TitleName;
        public static Thread HearthThread;
        public static int Trickshoot1;
        public static int Trickshoot2;
        public static int Trickshoot3;
        public static string XUID;
        private static Thread MBThread;
        public static uint SuicideHarrierClient = 0u;
        public static string SuicideHarrieString = "vehicle_phantom_ray";
        public static bool SuicideHarrierBool = false;
        public static string Land;
        public static PictureBox[] PBS = new PictureBox[64];
        public bool IsMultiplayerBool = true;
        public static uint uint_11;
        public static string IPTOLOCATE;
        public static string Faktor;
        public static bool AntiFreezeClasses;
        public static uint uint_12;
        public static uint uint_4;
        public static uint uint_7;
        public static uint uint_28;
        public static uint uint_27;
        public static bool AutoRefreshbool;
        public static uint uint_13;
        public static uint lcuExlcodSN;
        public static uint uint_22;
        public static uint uint_3;
        private DateTime dateTime_0;
        private Color UsedColor = Color.Black;
        private string string_2;
        private static int int_9;
        public static uint PlayersName;
        private static int Countername889 = 0;
        private string TimeNow2;
        public static uint[] Elements = new uint[64];
        public static uint relativeOffset = 44u;
        private string string_0;
        public static Color EraseColor = Color.FromArgb(255, 220, 220, 255);
        private uint Count = 0u;
        private static int int_2;
        public static bool BlinkName;
        private static int int_3;
        public static int SearchIndex = 0;
        private static int int_5;
        public string StickyNameChangerString;
        public static uint fontSizeOffset = 20u;
        private static int int_4;
        public static uint uint_40;
        public static uint GlowColor = 140u;
        public static byte[] byte_1;
        public static string Generatorstring;
        public static string Ready;
        public static bool MOABBOOL = false;
        public bool StickyNameChangerBool;
        public static string MODELOVERMAP;
        public static bool SniperLobby;
        public static Thread DiscoThread;
        public static byte[] byte_2;
        public static uint uint_54;
        public static bool FakeDNABool = false;
        public static bool AdvencedNoclipBool = false;
        public static float[] Save;
        public static float[] Save1;
        public static float[] Save2;
        public static float[] Save3;
        public static float[] Save4;
        public static float[] Save5;
        public static float[] Save6;
        public static float[] Save8;
        public static float[] Save7;
        public static float[] Save9;
        public static float[] Save10;
        public static float[] Save11;
        public static float[] Save12;
        public static float[] Save13;
        public static float[] Save14;
        public static float[] Save15;
        public static float[] Save16;
        public static float[] Save17;
        public static float[] Save18;
        public static float[] Save19;
        public static uint TypewriterIndex = 516u;
        public static uint ShotRocketsINT = 0u;
        public static bool LiveFlash;
        public static int SaveInt = 0;
        public static bool NameFlash;
        public static bool AutoFOVChanger;
        public static uint uint_2;
        public static bool ShotRocketsBool = false;
        public static bool Forcehost;
        public static string ShotRocketsString = "ac130_105mm_mp";
        public static byte[] dump = new byte[0];
        public static bool AntiEndgameBool = false;
        public static byte[] savedcoordinates;
        public static byte[] byte_0;
        public static bool iPrintlnON = true;
        public static bool ClientSuperJumpBool = false;
        public static uint CSuperJumpUint = 0u;
        public static float[] distances = new float[18];
        public static uint[] DomeBowlingUint = new uint[20];
        public static bool istmapi = true;
        public static int PainterInt;
        public static uint TeleportGunUint = 0u;
        public static bool CheckIfIngameBool = false;
        public static bool NoClip;
        public static bool Phantom;
        public static int int_1;
        public static bool TeleportGunBool = false;
        public static uint Vehicle1;
        public static string TeleportString = "Real";
        public static uint G_ClientOffset = 17867392u;
        public static uint G_ClientSize = 14720u;
        public static uint uint_0;
        public static uint NameAddress = 17880588u;
        public static uint Vehicle2;
        public static uint Vehicle3;
        public static uint G_EntitySize = 640u;
        private static Thread FCThread;
        public Mw3()
        {
            InitializeComponent();
        }

        private void metroButton407_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(0xFCA41E + (localClientNumber * 0x280), 0xFF);
        }

        public void WriteUInt32_ROP_1_(uint Address, uint Value)
        {
            PS3.Extension.WriteUInt32(0x10055008, Value);
            PS3.Extension.WriteUInt32(0x10055004, Address);
            PS3.Extension.WriteUInt32(0x10055000, 1);

            while (PS3.Extension.ReadUInt32(0x10055000) == 1)
                Thread.Sleep(1);
        }

        public void WriteUInt32_ROP_1_Exploit(uint Address, uint Value)
        {
            PS3.Extension.WriteUInt32(0x10055014, Value);
            PS3.Extension.WriteUInt32(0x10055010, Address);
            PS3.Extension.WriteUInt32(0x10055000, 2);

            while (PS3.Extension.ReadUInt32(0x10055000) == 2)
                Thread.Sleep(1);
        }




        private void metroButton459_Click(object sender, EventArgs e)
        {
            PS3.ChangeAPI(PS3Lib.SelectAPI.ControlConsole);
            bool flag = PS3.ConnectTarget(this.comboBox22.Text);
            if (!flag)
            {
                MessageBox.Show("Cant Connect\nAre you in MW2?\nAre you uisng CCAPI 2.60?", "RATMoDz 6.4 Private");
            }
            bool flag2 = PS3.AttachProcess();
            if (flag2)
            {
                PS3.CCAPI.Notify(PS3Lib.CCAPI.NotifyIcon.TROPHY4, "RATMoDz 6.4 Private by YouTube<3");
                //this.NameChanger.Text = PS3.Extension.ReadString(33157404u);
                //this.ResetName.Text = PS3.Extension.ReadString(33157404u);
                MessageBox.Show("Connected ~ Attached");
                //this.Size = new Size(695, 353);
            }
        }

        private void metroButton401_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_Exploit(0x0110D87C + (localClientNumber * 0x3980), 2);
        }

        private void metroButton400_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_Exploit(0x0110D87C + (localClientNumber * 0x3980), 0);
        }

        private void metroButton399_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(0x0110a6a8 + (localClientNumber * 0x3980), 0xFF);
        }

        private void metroButton398_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(0x0110a6b4 + (localClientNumber * 0x3980), 0xFF);
        }

        private void metroButton394_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_Exploit(0x0110a69c + (localClientNumber * 0x3980), 0xFF);
        }

        private void metroButton393_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(0x0110a6c0 + (localClientNumber * 0x3980), 0xFF);
        }

        private void metroCheckBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (this.metroCheckBox23.Checked)
            {
                byte[] array = new byte[]
                {
                    2
                };
                PS3.SetMemory(389223u, array);
                byte[] array2 = new byte[]
                {
                    65,
                    128
                };
                Form1.smethod_17(361616u, array2);
            }
            else
            {
                byte[] array3 = new byte[]
                {
                    1
                };
                PS3.SetMemory(389223u, array3);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(0x0110A5F9 + (localClientNumber * 0x280), 0x3F);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            uint cgArray = PS3.Extension.ReadUInt32(0x7BD008);
            uint localClientNumber = PS3.Extension.ReadUInt32(cgArray + 0x150);
            WriteUInt32_ROP_1_(17867405 + (localClientNumber * 0x280), 0x84);
           

        }

        
        private void metroButton367_Click(object sender, EventArgs e)
        {

            WriteUInt32_ROP_1_(0x1c1947c + ((uint)this.numericUpDown103.Value * 0x280), 0x10000000);
        }

        private void metroButton366_Click(object sender, EventArgs e)
        {
            WriteUInt32_ROP_1_Exploit(0x1c1926c + ((uint)this.numericUpDown102.Value * 0x3980), 1);
        }
    }
    }

