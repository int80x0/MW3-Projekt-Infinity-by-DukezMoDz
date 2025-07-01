using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Text.RegularExpressions;
using PS3Lib;
using System.Net;
using System.IO;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class Spoofer : MetroForm
    {
        private static PS3API PS3 = new PS3API();
        public static bool istmapi = true;
        public static ulong
           SpoofEIPAddr = 0x0,
           SpoofIIPAddr = 0x0;
        public static uint
            ExternalIPOffset,
            InternalIPOffset,
            PortOffset,
            ZIPOffset,
            XUIDOffset,
            ZeroOffset,
            NumberOffsets = 0;

        public static string
            MyInternalIP,
            MyPort,
            MyZIP,
            XUID;
        public Spoofer()
        {
            InitializeComponent();
        }

        public static void GetOffsetForSpoofer(uint client)
        {
            bool InParty = PS3.Extension.ReadBool(0x8AA267);
            ExternalIPOffset = InParty ? 0x8A81F6 + (client * 0x178) : 0x89D29E + (client * 0x178);
            InternalIPOffset = InParty ? 0x8A81E4 + (client * 0x178) : 0x89D28C + (client * 0x178);
            PortOffset = InParty ? 0x8A81FA + (client * 0x178) : 0x89D2A2 + (client * 0x178);
            ZIPOffset = InParty ? 0x8A8118 + (client * 0x178) : 0x89D1C0 + (client * 0x178);
            XUIDOffset = InParty ? 0x8A8220 + (client * 0x178) : 0x89D2C8 + (client * 0x178);
        }

        public static uint GetMe()
        {
            try
            {
                string serverInfo = PS3.Extension.ReadString(0x1BBBC2C);
                for (uint index = 0; index < 18; ++index)
                {
                    if (serverInfo.Contains(GrabName(index)))
                    {
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000000) == 0)
            {
                SpoofEIPAddr = Search(PS3.Extension.ReadBytes(ExternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                PS3.Extension.WriteUInt64(0x2000000, SpoofEIPAddr);
            }
            if (SpoofEIPAddr != 0x0)
            {
                PS3.SetMemory(Convert.ToUInt32(SpoofEIPAddr), GrabIP(GetMyIP()));
            }
            else
            {
                MessageBox.Show("The offset was not found", "Error");
            }
        }

      

        private void ExternalIPTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (!string.IsNullOrEmpty(InternalIPTxt.Text) || !string.IsNullOrWhiteSpace(InternalIPTxt.Text))
            {
                if (new Regex("\\b\\d{1,4}\\.\\d{1,4}\\.\\d{1,4}\\.\\d{1,4}\\b").IsMatch(InternalIPTxt.Text))
                {
                    if (PS3.Extension.ReadUInt64(0x2000100) == 0)
                    {
                        SpoofIIPAddr = Search(PS3.Extension.ReadBytes(InternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                        PS3.Extension.WriteUInt64(0x2000100, SpoofIIPAddr);
                    }
                    if (SpoofIIPAddr != 0x0)
                    {
                        PS3.SetMemory(Convert.ToUInt32(SpoofIIPAddr), GrabIP(InternalIPTxt.Text));
                    }
                    else
                    {
                        MessageBox.Show("The offset was not found", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("The IP address format is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No IP address detected in the textBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000100) == 0)
            {
                SpoofIIPAddr = Search(PS3.Extension.ReadBytes(InternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                PS3.Extension.WriteUInt64(0x2000100, SpoofIIPAddr);
            }
            if (SpoofIIPAddr != 0x0)
            {
                PS3.SetMemory(Convert.ToUInt32(SpoofIIPAddr), GrabIP(GetMyIP()));
            }
            else
            {
                MessageBox.Show("The offset was not found", "Error");
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000000) == 0)
            {
                SpoofEIPAddr = Search(PS3.Extension.ReadBytes(ExternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                PS3.Extension.WriteUInt64(0x2000000, SpoofEIPAddr);
            }
            if (SpoofEIPAddr != 0x0)
            {
                PS3.Extension.WriteUInt16((uint)SpoofEIPAddr + 4, (ushort)PortSpin.Value);
            }
            else
            {
                MessageBox.Show("The offset was not found", "Error");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000000) == 0)
            {
                SpoofEIPAddr = Search(PS3.Extension.ReadBytes(ExternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                PS3.Extension.WriteUInt64(0x2000000, SpoofEIPAddr);
            }
            if (SpoofEIPAddr != 0x0)
            {
                PS3.Extension.WriteUInt16((uint)SpoofEIPAddr + 4, Convert.ToUInt16(string.Format("{0}", MyPort)));
            }
            else
            {
                MessageBox.Show("The offset was not found", "Error");
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000000) == 0)
            {
                SpoofEIPAddr = Search(PS3.Extension.ReadBytes(ExternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                PS3.Extension.WriteUInt64(0x2000000, SpoofEIPAddr);
            }
            if (NatCmB.SelectedIndex == 0)
            {
                PS3.SetMemory((uint)SpoofEIPAddr + 0xB, new byte[] { 1 });
            }
            else if (NatCmB.SelectedIndex == 1)
            {
                PS3.SetMemory((uint)SpoofEIPAddr + 0xB, new byte[] { 2 });
            }
            else if (NatCmB.SelectedIndex == 2)
            {
                PS3.SetMemory((uint)SpoofEIPAddr + 0xB, new byte[] { 3 });
            }
            else if (NatCmB.SelectedIndex == 3)
            {
                PS3.SetMemory((uint)SpoofEIPAddr + 0xB, new byte[1]);
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(0x731474, ZIPTxt.Text);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(0x731474, MyZIP);
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            PS3.Extension.WriteUInt64(0x731E30, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(XUIDOffset, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1BBBC50, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1C11D48, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1C12300, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1C12508, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1CF1C30, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1C488E8, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1D4DFA0, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1D58C28, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x1D8ED58, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x246B3730, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x346B6910, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.Extension.WriteUInt64(0x28D21428, Convert.ToUInt64(XUIDTxt.Text, 16));
            PS3.SetMemory(0x1BBBC2B, new byte[] { 1 });
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            GetOffsetForSpoofer(GetMe());
            PS3.Extension.WriteUInt64(0x731E30, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(XUIDOffset, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1BBBC50, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1C11D48, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1C12300, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1C12508, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1CF1C30, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1C488E8, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1D4DFA0, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1D58C28, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x1D8ED58, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x246B3730, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x346B6910, Convert.ToUInt64(XUID, 16));
            PS3.Extension.WriteUInt64(0x28D21428, Convert.ToUInt64(XUID, 16));
            PS3.SetMemory(0x1bbbc2b, new byte[] { 1 });
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            try
            {

                if (PS3.ConnectTarget())
                {
                    
                    this.metroLabel124.Text = "Connected";
                    this.metroLabel124.ForeColor = Color.LimeGreen;
                    MessageBox.Show("Playstation 3 Connected !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Playstation 3 Not Connected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Playstation 3 Not Connected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            {
                if (istmapi == true)
                {
                    if (PS3.AttachProcess())
                    {
                        this.metroLabel136.Text = "Attached";
                        this.metroLabel136.ForeColor = Color.LimeGreen;
                        MessageBox.Show("Attached to RATModzV6!\n\nHave Fun :D", "Attached!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else

                        MessageBox.Show("Failed to Attach to RATModz V6!\n\nMake sure your ingame!", "Failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (istmapi == false)
                {
                    if (PS3.AttachProcess())

                    {
                        this.metroLabel136.Text = "Attached";
                        this.metroLabel136.ForeColor = Color.LimeGreen;
                        

                        MessageBox.Show("Attached to RATModzV6!\n\nHave Fun :D", "Attached", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else MessageBox.Show("Failed to Attach RATModzV6!\n\nMake sure your ingame!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
            MessageBox.Show("Select TMAPI you can Connect/Attach with TMAPI", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
            MessageBox.Show("Select CCAPI you can Connect/Attach with CCAPI", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Spoofer_Load(object sender, EventArgs e)
        {

        }

        public static byte[] GrabIP(string ip)
        {
            string[] ipS = ip.Split('.');
            return new byte[] { Convert.ToByte(ipS[0]), Convert.ToByte(ipS[1]), Convert.ToByte(ipS[2]), Convert.ToByte(ipS[3]) };
        }

        public static string GrabName(uint Client)
        {
            bool InParty = PS3.Extension.ReadBool(0x8AA267);
            string Name = PS3.Extension.ReadString(InParty ? 0x8A8128 + (Client * 0x178) : 0x89D1D0 + (Client * 0x178));
            if (Name != "")
                return Name;
            else
                return "";
        }

        public static uint ContainsSequence(byte[] toSearch, byte[] toFind, uint StartOffset, int bytes)
        {
            for (int i = 0; (i + toFind.Length) < toSearch.Length; i += bytes)
            {
                bool flag = true;
                for (int j = 0; j < toFind.Length; j++)
                {
                    if (toSearch[i + j] != toFind[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    NumberOffsets++;
                    int num3 = ((int)StartOffset) + i;
                    return (uint)num3;
                }
            }
            return 0;
        }

        public static ulong Search(byte[] Search, uint Start, int Length, int bytes)
        {
            byte[] ReadByte = PS3.Extension.ReadBytes(Start, Length);
            uint num = ContainsSequence(ReadByte, Search, Start, bytes);
            if (num.Equals(ZeroOffset))
            {
                return 0;
                //not found
            }
            else
            {
                int counter = 0;
                foreach (int value in Search)
                    if (value == 1) ++counter;
                uint num2 = num + ((uint)counter);
                return num2;
            }
        }

        public static string GetMyIP()
        {
            string str = "";
            using (WebResponse response = WebRequest.Create("http://checkip.dyndns.org/").GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    str = streamReader.ReadToEnd();
            }
            int startIndex = str.IndexOf("Address: ") + 9;
            int num = str.LastIndexOf("</body>");
            return str.Substring(startIndex, num - startIndex);
        }

        public static string ReadIP(byte[] mem)
        {
            return $"{mem[0]}.{mem[1]}.{mem[2]}.{mem[3]}";
        }

        public static string ReadPort(byte[] input)
        {
            return (input[1] << 8 | input[0]).ToString();
        }

        private void DetectSpoof()
        {
            GetOffsetForSpoofer(GetMe());
            if (PS3.Extension.ReadUInt64(0x2000000) != 0)
            {
                SpoofEIPAddr = PS3.Extension.ReadUInt64(0x2000000);
            }
            if (PS3.Extension.ReadUInt64(0x2000100) != 0)
            {
                SpoofIIPAddr = PS3.Extension.ReadUInt64(0x2000100);
            }
            if (PS3.Extension.ReadString(0x2001000) == "")
            {
                XUID = PS3.Extension.ReadString(0x1bbbC58);
                PS3.Extension.WriteString(0x2001000, XUID);
            }
            else
            {
                XUID = PS3.Extension.ReadString(0x2001000);
            }
            if (PS3.Extension.ReadString(0x2000200) == "")
            {
                MyInternalIP = ReadIP(PS3.Extension.ReadBytes(InternalIPOffset, 4));
                PS3.Extension.WriteString(0x2000200, MyInternalIP);
            }
            else
            {
                MyInternalIP = PS3.Extension.ReadString(0x2000200);

            }
            if (PS3.Extension.ReadString(0x2000300) == "")
            {
                MyPort = ReadPort(PS3.Extension.ReadBytes(PortOffset, 2));
                PS3.Extension.WriteString(0x2000300, MyPort);
            }
            else
            {
                MyPort = PS3.Extension.ReadString(0x2000300);
            }
            if (PS3.Extension.ReadString(0x2000400) == "")
            {
                MyZIP = PS3.Extension.ReadString(ZIPOffset);
                PS3.Extension.WriteString(0x2000400, MyZIP);
            }
            else
            {
                MyZIP = PS3.Extension.ReadString(0x2000400);
            }
        }
    


            private void metroButton357_Click(object sender, EventArgs e)
            {
            GetOffsetForSpoofer(GetMe());
            if (!string.IsNullOrEmpty(ExternalIPTxt.Text) || !string.IsNullOrWhiteSpace(ExternalIPTxt.Text))
            {
                if (new Regex("\\b\\d{1,4}\\.\\d{1,4}\\.\\d{1,4}\\.\\d{1,4}\\b").IsMatch(ExternalIPTxt.Text))
                {
                    if (PS3.Extension.ReadUInt64(0x2000000) == 0)
                    {
                        SpoofEIPAddr = Search(PS3.Extension.ReadBytes(ExternalIPOffset, 4), 0x3002DF24, 0x20000, 4);
                        PS3.Extension.WriteUInt64(0x2000000, SpoofEIPAddr);
                    }
                    if (SpoofEIPAddr != 0x0)
                    {
                        PS3.SetMemory(Convert.ToUInt32(SpoofEIPAddr), GrabIP(ExternalIPTxt.Text));
                    }
                    else
                    {
                        MessageBox.Show("The offset was not found", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("The IP address format is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No IP address detected in the textBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
