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
using System.Runtime.CompilerServices;

namespace MW3_Projekt_Infinity_by_RATModz
{
    public partial class Ip_Grabber : MetroForm
    {
        static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        public static bool istmapi = true;
        public static uint PrestigeOffset;
        public static int client;
        public Ip_Grabber()
        {
            InitializeComponent();
        }

        private void Ip_Grabber_Load(object sender, EventArgs e)
        {

        }


        public static string ReadString(uint address)
        {
            int num = 40;
            int num2 = 0;
            string text = "";
            do
            {
                byte[] memory = RPC.GetMemory(address + (uint)num2, num);
                text += Encoding.UTF8.GetString(memory);
                num2 += num;
            }
            while (!text.Contains('\0'));
            int length = text.IndexOf('\0');
            string result = text.Substring(0, length);
            text = string.Empty;
            return result;
        }


        public static string GetNameParty(int client)
        {
            return Ip_Grabber.ReadString((uint)(9077032 + 376 * client));
        }

        
        public static string GetNameLobby(int client)
        {
            return Ip_Grabber.ReadString((uint)(9032144 + 376 * client));
        }


        public static string GetZIPLobby(int client)
        {
            return Ip_Grabber.ReadString((uint)(9032128 + 376 * client));
        }


       

     
        public static string GetZIPParty(int client)
        {
            return Ip_Grabber.ReadString((uint)(9077016 + 376 * client));
        }


        public static string GetXUIDParty(int Client)
        {
            return BitConverter.ToString(RPC.GetMemory((uint)(9077280 + Client * 376), 8)).Replace("-", string.Empty);
        }


     
        public static string GetXUIDLobby(int Client)
        {
            return BitConverter.ToString(RPC.GetMemory((uint)(9032392 + Client * 376), 8)).Replace("-", string.Empty);
        }

       
        public static string GetIPLobby(int Client)
        {
            byte[] memory = RPC.GetMemory((uint)(9032350 + Client * 376), 4);
            return string.Concat(new string[]
            {
                Convert.ToString(memory[0]),
                ".",
                Convert.ToString(memory[1]),
                ".",
                Convert.ToString(memory[2]),
                ".",
                Convert.ToString(memory[3])
            });
        }


        public static string GetIPParty(int Client)
        {
            byte[] memory = RPC.GetMemory((uint)(9077238 + Client * 376), 4);
            return string.Concat(new string[]
            {
                Convert.ToString(memory[0]),
                ".",
                Convert.ToString(memory[1]),
                ".",
                Convert.ToString(memory[2]),
                ".",
                Convert.ToString(memory[3])
            });
        }



     



        private void metroButton297_Click(object sender, EventArgs e)
        {

          
                if (this.metroRadioButton13.Checked)
            {
                for (int i = 0; i < 18; i++)
                {
                    
                    this.zeQoFgEegA.Text = Form1.smethod_15(29101263u);
                    dataGridView2.Enabled = true;
                    dataGridView2.RowCount = 18;
                    byte[] bytes = new byte[30];
                    byte[] bytes2 = new byte[30];
                    byte[] bytes3 = new byte[30];
                    byte[] bytes4 = new byte[30];
                    byte[] bytes5 = new byte[30];
                    byte[] bytes6 = new byte[30];
                    byte[] bytes7 = new byte[30];
                    byte[] bytes8 = new byte[30];
                    byte[] bytes9 = new byte[30];
                    byte[] bytes10 = new byte[30];
                    byte[] bytes11 = new byte[30];
                    byte[] bytes12 = new byte[30];
                    byte[] bytes13 = new byte[30];
                    byte[] bytes14 = new byte[30];
                    byte[] bytes15 = new byte[30];
                    byte[] bytes16 = new byte[30];
                    byte[] bytes17 = new byte[30];
                    byte[] bytes18 = new byte[30];
                    Form1.smethod_3(9077032u, ref bytes);
                    Form1.smethod_3(9077408u, ref bytes2);
                    Form1.smethod_3(9077784u, ref bytes3);
                    Form1.smethod_3(9078160u, ref bytes4);
                    Form1.smethod_3(9078536u, ref bytes5);
                    Form1.smethod_3(9078912u, ref bytes6);
                    Form1.smethod_3(9079288u, ref bytes7);
                    Form1.smethod_3(9079664u, ref bytes8);
                    Form1.smethod_3(9080040u, ref bytes9);
                    Form1.smethod_3(9080416u, ref bytes10);
                    Form1.smethod_3(9080792u, ref bytes11);
                    Form1.smethod_3(9081168u, ref bytes12);
                    Form1.smethod_3(9081544u, ref bytes13);
                    Form1.smethod_3(9081920u, ref bytes14);
                    Form1.smethod_3(9082296u, ref bytes15);
                    Form1.smethod_3(9082672u, ref bytes16);
                    Form1.smethod_3(9083048u, ref bytes17);
                    Form1.smethod_3(9083424u, ref bytes18);
                    string @string = Encoding.ASCII.GetString(bytes);
                    string string2 = Encoding.ASCII.GetString(bytes2);
                    string string3 = Encoding.ASCII.GetString(bytes3);
                    string string4 = Encoding.ASCII.GetString(bytes4);
                    string string5 = Encoding.ASCII.GetString(bytes5);
                    string string6 = Encoding.ASCII.GetString(bytes6);
                    string string7 = Encoding.ASCII.GetString(bytes7);
                    string string8 = Encoding.ASCII.GetString(bytes8);
                    string string9 = Encoding.ASCII.GetString(bytes9);
                    string string10 = Encoding.ASCII.GetString(bytes10);
                    string string11 = Encoding.ASCII.GetString(bytes11);
                    string string12 = Encoding.ASCII.GetString(bytes12);
                    string string13 = Encoding.ASCII.GetString(bytes13);
                    string string14 = Encoding.ASCII.GetString(bytes14);
                    string string15 = Encoding.ASCII.GetString(bytes15);
                    string string16 = Encoding.ASCII.GetString(bytes16);
                    string string17 = Encoding.ASCII.GetString(bytes17);
                    string string18 = Encoding.ASCII.GetString(bytes18);
                    this.dataGridView2.Enabled = true;
                    this.dataGridView2.RowCount = 18;
                    this.dataGridView2.Update();
                    this.dataGridView2.Rows[0].Cells[1].Value = @string;
                    this.dataGridView2.Rows[1].Cells[1].Value = string2;
                    this.dataGridView2.Rows[2].Cells[1].Value = string3;
                    this.dataGridView2.Rows[3].Cells[1].Value = string4;
                    this.dataGridView2.Rows[4].Cells[1].Value = string5;
                    this.dataGridView2.Rows[5].Cells[1].Value = string6;
                    this.dataGridView2.Rows[6].Cells[1].Value = string7;
                    this.dataGridView2.Rows[7].Cells[1].Value = string8;
                    this.dataGridView2.Rows[8].Cells[1].Value = string9;
                    this.dataGridView2.Rows[9].Cells[1].Value = string10;
                    this.dataGridView2.Rows[10].Cells[1].Value = string11;
                    this.dataGridView2.Rows[11].Cells[1].Value = string12;
                    this.dataGridView2.Rows[12].Cells[1].Value = string13;
                    this.dataGridView2.Rows[13].Cells[1].Value = string14;
                    this.dataGridView2.Rows[14].Cells[1].Value = string15;
                    this.dataGridView2.Rows[15].Cells[1].Value = string16;
                    this.dataGridView2.Rows[16].Cells[1].Value = string17;
                    this.dataGridView2.Rows[17].Cells[1].Value = string18;
                    this.dataGridView2.Rows[0].Cells[0].Value = 0;
                    this.dataGridView2.Rows[1].Cells[0].Value = 1;
                    this.dataGridView2.Rows[2].Cells[0].Value = 2;
                    this.dataGridView2.Rows[3].Cells[0].Value = 3;
                    this.dataGridView2.Rows[4].Cells[0].Value = 4;
                    this.dataGridView2.Rows[5].Cells[0].Value = 5;
                    this.dataGridView2.Rows[6].Cells[0].Value = 6;
                    this.dataGridView2.Rows[7].Cells[0].Value = 7;
                    this.dataGridView2.Rows[8].Cells[0].Value = 8;
                    this.dataGridView2.Rows[9].Cells[0].Value = 9;
                    this.dataGridView2.Rows[10].Cells[0].Value = 10;
                    this.dataGridView2.Rows[11].Cells[0].Value = 11;
                    this.dataGridView2.Rows[12].Cells[0].Value = 12;
                    this.dataGridView2.Rows[13].Cells[0].Value = 13;
                    this.dataGridView2.Rows[14].Cells[0].Value = 14;
                    this.dataGridView2.Rows[15].Cells[0].Value = 15;
                    this.dataGridView2.Rows[16].Cells[0].Value = 16;
                    this.dataGridView2.Rows[17].Cells[0].Value = 17;
                    this.dataGridView2.Update();
                    dataGridView2.Rows[i].Cells[1].Value = GetNameParty(i);
                    dataGridView2.Rows[i].Cells[2].Value = GetXUIDParty(i);
                    dataGridView2.Rows[i].Cells[3].Value = GetIPParty(i);
                    dataGridView2.Rows[i].Cells[4].Value = GetZIPParty(i);
                    dataGridView2.Rows[i].Cells[5].Value = PrestigeOffset = 0x8A80EB + ((uint)client * 0x178);
                    



                }

                }
            
            if (this.metroRadioButton14.Checked)
            {
                for (int i = 0; i < 18; i++)
                {
                    
                    this.zeQoFgEegA.Text = Form1.smethod_15(29101263u);
                    dataGridView2.Enabled = true;
                    dataGridView2.RowCount = 18;
                    byte[] bytes = new byte[30];
                    byte[] bytes2 = new byte[30];
                    byte[] bytes3 = new byte[30];
                    byte[] bytes4 = new byte[30];
                    byte[] bytes5 = new byte[30];
                    byte[] bytes6 = new byte[30];
                    byte[] bytes7 = new byte[30];
                    byte[] bytes8 = new byte[30];
                    byte[] bytes9 = new byte[30];
                    byte[] bytes10 = new byte[30];
                    byte[] bytes11 = new byte[30];
                    byte[] bytes12 = new byte[30];
                    byte[] bytes13 = new byte[30];
                    byte[] bytes14 = new byte[30];
                    byte[] bytes15 = new byte[30];
                    byte[] bytes16 = new byte[30];
                    byte[] bytes17 = new byte[30];
                    byte[] bytes18 = new byte[30];
                    Form1.smethod_3(9077032u, ref bytes);
                    Form1.smethod_3(9077408u, ref bytes2);
                    Form1.smethod_3(9077784u, ref bytes3);
                    Form1.smethod_3(9078160u, ref bytes4);
                    Form1.smethod_3(9078536u, ref bytes5);
                    Form1.smethod_3(9078912u, ref bytes6);
                    Form1.smethod_3(9079288u, ref bytes7);
                    Form1.smethod_3(9079664u, ref bytes8);
                    Form1.smethod_3(9080040u, ref bytes9);
                    Form1.smethod_3(9080416u, ref bytes10);
                    Form1.smethod_3(9080792u, ref bytes11);
                    Form1.smethod_3(9081168u, ref bytes12);
                    Form1.smethod_3(9081544u, ref bytes13);
                    Form1.smethod_3(9081920u, ref bytes14);
                    Form1.smethod_3(9082296u, ref bytes15);
                    Form1.smethod_3(9082672u, ref bytes16);
                    Form1.smethod_3(9083048u, ref bytes17);
                    Form1.smethod_3(9083424u, ref bytes18);
                    string @string = Encoding.ASCII.GetString(bytes);
                    string string2 = Encoding.ASCII.GetString(bytes2);
                    string string3 = Encoding.ASCII.GetString(bytes3);
                    string string4 = Encoding.ASCII.GetString(bytes4);
                    string string5 = Encoding.ASCII.GetString(bytes5);
                    string string6 = Encoding.ASCII.GetString(bytes6);
                    string string7 = Encoding.ASCII.GetString(bytes7);
                    string string8 = Encoding.ASCII.GetString(bytes8);
                    string string9 = Encoding.ASCII.GetString(bytes9);
                    string string10 = Encoding.ASCII.GetString(bytes10);
                    string string11 = Encoding.ASCII.GetString(bytes11);
                    string string12 = Encoding.ASCII.GetString(bytes12);
                    string string13 = Encoding.ASCII.GetString(bytes13);
                    string string14 = Encoding.ASCII.GetString(bytes14);
                    string string15 = Encoding.ASCII.GetString(bytes15);
                    string string16 = Encoding.ASCII.GetString(bytes16);
                    string string17 = Encoding.ASCII.GetString(bytes17);
                    string string18 = Encoding.ASCII.GetString(bytes18);
                    this.dataGridView2.Enabled = true;
                    this.dataGridView2.RowCount = 18;
                    this.dataGridView2.Update();
                    this.dataGridView2.Rows[0].Cells[1].Value = @string;
                    this.dataGridView2.Rows[1].Cells[1].Value = string2;
                    this.dataGridView2.Rows[2].Cells[1].Value = string3;
                    this.dataGridView2.Rows[3].Cells[1].Value = string4;
                    this.dataGridView2.Rows[4].Cells[1].Value = string5;
                    this.dataGridView2.Rows[5].Cells[1].Value = string6;
                    this.dataGridView2.Rows[6].Cells[1].Value = string7;
                    this.dataGridView2.Rows[7].Cells[1].Value = string8;
                    this.dataGridView2.Rows[8].Cells[1].Value = string9;
                    this.dataGridView2.Rows[9].Cells[1].Value = string10;
                    this.dataGridView2.Rows[10].Cells[1].Value = string11;
                    this.dataGridView2.Rows[11].Cells[1].Value = string12;
                    this.dataGridView2.Rows[12].Cells[1].Value = string13;
                    this.dataGridView2.Rows[13].Cells[1].Value = string14;
                    this.dataGridView2.Rows[14].Cells[1].Value = string15;
                    this.dataGridView2.Rows[15].Cells[1].Value = string16;
                    this.dataGridView2.Rows[16].Cells[1].Value = string17;
                    this.dataGridView2.Rows[17].Cells[1].Value = string18;
                    this.dataGridView2.Rows[0].Cells[0].Value = 0;
                    this.dataGridView2.Rows[1].Cells[0].Value = 1;
                    this.dataGridView2.Rows[2].Cells[0].Value = 2;
                    this.dataGridView2.Rows[3].Cells[0].Value = 3;
                    this.dataGridView2.Rows[4].Cells[0].Value = 4;
                    this.dataGridView2.Rows[5].Cells[0].Value = 5;
                    this.dataGridView2.Rows[6].Cells[0].Value = 6;
                    this.dataGridView2.Rows[7].Cells[0].Value = 7;
                    this.dataGridView2.Rows[8].Cells[0].Value = 8;
                    this.dataGridView2.Rows[9].Cells[0].Value = 9;
                    this.dataGridView2.Rows[10].Cells[0].Value = 10;
                    this.dataGridView2.Rows[11].Cells[0].Value = 11;
                    this.dataGridView2.Rows[12].Cells[0].Value = 12;
                    this.dataGridView2.Rows[13].Cells[0].Value = 13;
                    this.dataGridView2.Rows[14].Cells[0].Value = 14;
                    this.dataGridView2.Rows[15].Cells[0].Value = 15;
                    this.dataGridView2.Rows[16].Cells[0].Value = 16;
                    this.dataGridView2.Rows[17].Cells[0].Value = 17;
                    this.dataGridView2.Update();
                    dataGridView2.Rows[i].Cells[1].Value = GetNameLobby(i);
                    dataGridView2.Rows[i].Cells[2].Value = GetXUIDLobby(i);
                    dataGridView2.Rows[i].Cells[3].Value = GetIPLobby(i);
                    dataGridView2.Rows[i].Cells[4].Value = GetZIPLobby(i);
                    dataGridView2.Rows[i].Cells[5].Value = PrestigeOffset = 0x89D193 + ((uint)client * 0x178);
                }
           
       }
        }




        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.zeQoFgEegA.Text = Form1.smethod_15(29101263u);
            dataGridView1.Enabled = true;
            dataGridView1.RowCount = 18;
            dataGridView1.Update();
            bool @checked = this.metroRadioButton14.Checked;
            bool flag = @checked;
            if (flag)
            {
                dataGridView1.Update();
                byte[] bytes = new byte[30];
                byte[] bytes2 = new byte[30];
                byte[] bytes3 = new byte[30];
                byte[] bytes4 = new byte[30];
                byte[] bytes5 = new byte[30];
                byte[] bytes6 = new byte[30];
                byte[] bytes7 = new byte[30];
                byte[] bytes8 = new byte[30];
                byte[] bytes9 = new byte[30];
                byte[] bytes10 = new byte[30];
                byte[] bytes11 = new byte[30];
                byte[] bytes12 = new byte[30];
                byte[] bytes13 = new byte[30];
                byte[] bytes14 = new byte[30];
                byte[] bytes15 = new byte[30];
                byte[] bytes16 = new byte[30];
                byte[] bytes17 = new byte[30];
                byte[] bytes18 = new byte[30];
                Form1.smethod_3(9077032u, ref bytes);
                Form1.smethod_3(9077408u, ref bytes2);
                Form1.smethod_3(9077784u, ref bytes3);
                Form1.smethod_3(9078160u, ref bytes4);
                Form1.smethod_3(9078536u, ref bytes5);
                Form1.smethod_3(9078912u, ref bytes6);
                Form1.smethod_3(9079288u, ref bytes7);
                Form1.smethod_3(9079664u, ref bytes8);
                Form1.smethod_3(9080040u, ref bytes9);
                Form1.smethod_3(9080416u, ref bytes10);
                Form1.smethod_3(9080792u, ref bytes11);
                Form1.smethod_3(9081168u, ref bytes12);
                Form1.smethod_3(9081544u, ref bytes13);
                Form1.smethod_3(9081920u, ref bytes14);
                Form1.smethod_3(9082296u, ref bytes15);
                Form1.smethod_3(9082672u, ref bytes16);
                Form1.smethod_3(9083048u, ref bytes17);
                Form1.smethod_3(9083424u, ref bytes18);
                string @string = Encoding.ASCII.GetString(bytes);
                string string2 = Encoding.ASCII.GetString(bytes2);
                string string3 = Encoding.ASCII.GetString(bytes3);
                string string4 = Encoding.ASCII.GetString(bytes4);
                string string5 = Encoding.ASCII.GetString(bytes5);
                string string6 = Encoding.ASCII.GetString(bytes6);
                string string7 = Encoding.ASCII.GetString(bytes7);
                string string8 = Encoding.ASCII.GetString(bytes8);
                string string9 = Encoding.ASCII.GetString(bytes9);
                string string10 = Encoding.ASCII.GetString(bytes10);
                string string11 = Encoding.ASCII.GetString(bytes11);
                string string12 = Encoding.ASCII.GetString(bytes12);
                string string13 = Encoding.ASCII.GetString(bytes13);
                string string14 = Encoding.ASCII.GetString(bytes14);
                string string15 = Encoding.ASCII.GetString(bytes15);
                string string16 = Encoding.ASCII.GetString(bytes16);
                string string17 = Encoding.ASCII.GetString(bytes17);
                string string18 = Encoding.ASCII.GetString(bytes18);
                dataGridView1.Rows[0].Cells[2].Value = @string;
                dataGridView1.Rows[1].Cells[2].Value = string2;
                dataGridView1.Rows[2].Cells[2].Value = string3;
                dataGridView1.Rows[3].Cells[2].Value = string4;
                dataGridView1.Rows[4].Cells[2].Value = string5;
                dataGridView1.Rows[5].Cells[2].Value = string6;
                dataGridView1.Rows[6].Cells[2].Value = string7;
                dataGridView1.Rows[7].Cells[2].Value = string8;
                dataGridView1.Rows[8].Cells[2].Value = string9;
                dataGridView1.Rows[9].Cells[2].Value = string10;
                dataGridView1.Rows[10].Cells[2].Value = string11;
                dataGridView1.Rows[11].Cells[2].Value = string12;
                dataGridView1.Rows[12].Cells[2].Value = string13;
                dataGridView1.Rows[13].Cells[2].Value = string14;
                dataGridView1.Rows[14].Cells[2].Value = string15;
                dataGridView1.Rows[15].Cells[2].Value = string16;
                dataGridView1.Rows[16].Cells[2].Value = string17;
                dataGridView1.Rows[17].Cells[2].Value = string18;
                for (int i = 0; i < 18; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i;
                    dataGridView1.Rows[i].Cells[6].Value = Form1.smethod_198(i);
                    dataGridView1.Rows[i].Cells[4].Value = Form1.smethod_197(i);
                    byte[] bytes19 = new byte[7];
                    Form1.smethod_3((uint)(9076996 + 376 * i), ref bytes19);
                    string string19 = Encoding.ASCII.GetString(bytes19);
                    string19.Replace("\0", "");
                    dataGridView1.Rows[i].Cells[1].Value = string19;
                    byte value = Form1.smethod_11((uint)(9077238 + 376 * i));
                    byte value2 = Form1.smethod_11((uint)(9077239 + 376 * i));
                    byte value3 = Form1.smethod_11((uint)(9077240 + 376 * i));
                    byte value4 = Form1.smethod_11((uint)(9077241 + 376 * i));
                    byte value5 = Form1.smethod_11((uint)(9077242 + 376 * i));
                    byte value6 = Form1.smethod_11((uint)(0x8A80EB + 376 * i));
                    int num = Convert.ToInt32(value);
                    int num2 = Convert.ToInt32(value2);
                    int num3 = Convert.ToInt32(value3);
                    int num4 = Convert.ToInt32(value4);
                    Convert.ToInt32(value5);
                    Convert.ToInt32(value6);
                    bool flag2 = num == 0;
                    bool flag3 = flag2;
                    if (flag3)
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "0.0.0.0";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = string.Concat(new object[]
                        {
                            num,
                            ".",
                            num2,
                            ".",
                            num3,
                            ".",
                            num4
                        });
                    }
                    byte value7 = Form1.smethod_11((uint)(9077220 + 376 * i));
                    byte value8 = Form1.smethod_11((uint)(9077221 + 376 * i));
                    byte value9 = Form1.smethod_11((uint)(9077222 + 376 * i));
                    byte value10 = Form1.smethod_11((uint)(0x89D193 + 376 * i));
                    int num5 = Convert.ToInt32(value7);
                    int num6 = Convert.ToInt32(value8);
                    int num7 = Convert.ToInt32(value9);
                    int num8 = Convert.ToInt32(value10);
                    bool flag4 = num5 == 0;
                    bool flag5 = flag4;
                    if (flag5)
                    {
                        dataGridView1.Rows[i].Cells[5].Value = "0.0.0.0";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[5].Value = string.Concat(new object[]
                        {
                            num5,
                            ".",
                            num6,
                            ".",
                            num7,
                            ".",
                            num8
                        });
                    }
                }
            }
            else
            {
                bool checked2 = this.metroRadioButton13.Checked;
                bool flag6 = checked2;
                if (flag6)
                {
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Enabled = true;
                    dataGridView1.RowCount = 18;
                    for (int j = 0; j < 18; j++)
                    {
                        dataGridView1.Update();
                        byte[] bytes20 = new byte[7];
                        Form1.smethod_3((uint)(9032108 + 376 * j), ref bytes20);
                        string string20 = Encoding.ASCII.GetString(bytes20);
                        string20.Replace("\0", "");
                        dataGridView1.Rows[j].Cells[1].Value = string20;
                        byte[] bytes21 = new byte[32];
                        Form1.smethod_3((uint)(9032144 + 376 * j), ref bytes21);
                        string string21 = Encoding.ASCII.GetString(bytes21);
                        string21.Replace("\0", "");
                        byte[] array = Form1.smethod_12((uint)(9032392 + 376 * j), 8);
                        string value11 = BitConverter.ToString(array).Replace("-", string.Empty);
                        string string22 = Encoding.ASCII.GetString(array);
                        string22.Replace("\0", "");
                        byte[] bytes22 = new byte[7];
                        Form1.smethod_3((uint)(9032128 + 376 * j), ref bytes22);
                        string string23 = Encoding.ASCII.GetString(bytes22);
                        string23.Replace("\0", "");
                        dataGridView1.Rows[j].Cells[2].Value = string21;
                        dataGridView1.Rows[j].Cells[0].Value = j;
                        dataGridView1.Rows[j].Cells[4].Value = value11;
                        dataGridView1.Rows[j].Cells[6].Value = string23;
                        dataGridView1.Rows[j].Cells[1].Value = string20;
                        byte value12 = Form1.smethod_11((uint)(0x89D193 + 376 * j));
                        byte value13 = Form1.smethod_11((uint)(9032351 + 376 * j));
                        byte value14 = Form1.smethod_11((uint)(9032352 + 376 * j));
                        byte value15 = Form1.smethod_11((uint)(9032353 + 376 * j));
                        byte value16 = Form1.smethod_11((uint)(9032350 + 376 * j));
                        byte value17 = Form1.smethod_11((uint)(9032350 + 376 * j));
                        byte value18 = Form1.smethod_11((uint)(9032350 + 376 * j));
                        int num9 = Convert.ToInt32(value12);
                        int num10 = Convert.ToInt32(value13);
                        int num11 = Convert.ToInt32(value14);
                        int num12 = Convert.ToInt32(value15);
                        Convert.ToInt32(value16);
                        Convert.ToInt32(value17);
                        bool flag7 = num9 == 0;
                        bool flag8 = flag7;
                        if (flag8)
                        {
                            dataGridView1.Rows[j].Cells[3].Value = "0.0.0.0";
                        }
                        else
                        {
                            dataGridView1.Rows[j].Cells[3].Value = string.Concat(new object[]
                            {
                                num9,
                                ".",
                                num10,
                                ".",
                                num11,
                                ".",
                                num12
                            });
                        }
                        byte value19 = Form1.smethod_11((uint)(9032332 + 376 * j));
                        byte value20 = Form1.smethod_11((uint)(9032333 + 376 * j));
                        byte value21 = Form1.smethod_11((uint)(9032334 + 376 * j));
                        byte value22 = Form1.smethod_11((uint)(9032335 + 376 * j));
                        byte value23 = Form1.smethod_11((uint)(0x89D193 + 376 * j));
                        int num13 = Convert.ToInt32(value18);
                        int num14 = Convert.ToInt32(value19);
                        int num15 = Convert.ToInt32(value20);
                        int num16 = Convert.ToInt32(value21);
                        bool flag9 = num13 == 0;
                        bool flag10 = flag9;
                        if (flag10)
                        {
                            dataGridView1.Rows[j].Cells[5].Value = "0.0.0.0";
                        }
                        else
                        {
                            dataGridView1.Rows[j].Cells[5].Value = string.Concat(new object[]
                            {
                                num13,
                                ".",
                                num14,
                                ".",
                                num15,
                                ".",
                                num16
                            });
                        }
                    }
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {

                if (PS3.ConnectTarget())
                {
                    
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

        private void metroButton4_Click(object sender, EventArgs e)
        {
            {
                if (istmapi == true)
                {
                    if (PS3.AttachProcess())
                    {
                       
                        MessageBox.Show("Attached to RATModzV6!\n\nHave Fun :D", "Attached!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else

                        MessageBox.Show("Failed to Attach to RATModz V6!\n\nMake sure your ingame!", "Failed...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (istmapi == false)
                {
                    if (PS3.AttachProcess())

                    {
                       
                        MessageBox.Show("Attached to RATModzV6!\n\nHave Fun :D", "Attached", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else MessageBox.Show("Failed to Attach RATModzV6!\n\nMake sure your ingame!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void metroRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.SNMAPI);
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
