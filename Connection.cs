using PS3Lib;
using System;

namespace MW3_Projekt_Infinity_by_RATModz
{
    class Connection
    {
        public static bool IsConnected = false;
        public static bool IsAttached = false;
        public static PS3API PS3 = new PS3API();
        public static void SetApi(string input)
        {
            switch (input)
            {
                case "CCAPI": PS3.ChangeAPI(SelectAPI.ControlConsole); break;
                case "TMAPI": PS3.ChangeAPI(SelectAPI.TargetManager); break;
            }
        }

        public static string Connect(string ip)
        {
            try
            {
                IsConnected = PS3.ConnectTarget(ip);
                return IsConnected == true ? "Connected" : "Not Connected";
            }
            catch (Exception)
            {
                return "Not Connected";
            }
        }

        public static string Connect()
        {
            try
            {
                IsConnected = PS3.ConnectTarget();
                return IsConnected == true ? "Connected" : "Not Connected";
            }
            catch (Exception)
            {
                return "Not Connected";
            }
        }

        public static string Attach()
        {
            try
            {
                IsAttached = PS3.AttachProcess();
                return IsAttached == true ? "Attached" : "not Attached";
            }
            catch (Exception)
            {
                return "Not Attached";
            }
        }

        public static void Disconnect()
        {
            IsConnected = false;
            IsAttached = false;
            try
            {
                PS3.DisconnectTarget();
            }
            catch (Exception)
            {

            }
        }

        public static bool CheckConnection()
        {
            bool StillConnect = false;
            try
            {
                StillConnect = PS3.Extension.ReadString(0x10000).Contains("ELF");
            }
            catch (Exception)
            {
                StillConnect = false;
            }
            IsConnected = StillConnect;
            IsAttached = StillConnect;
            return StillConnect;
        }
    }
}
