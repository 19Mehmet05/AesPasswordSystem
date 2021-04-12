using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Net;

namespace AesPasswordSystem
{

    public static class Operation
    {
        private static string Computer_name = Dns.GetHostName();
        private static string fingerPrint = string.Empty;
        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                string plainText = "\nCPU >> " + CPUSeriNoCek() +

                    "\nMother >> " + Mother_Board_No() +

                    "\nVIDEO >> " + Display_Card_No() +

                    "\nComputer >> " + Computer_name;


                fingerPrint = plainText;
            }
            return fingerPrint;
        }


        public static String CPUSeriNoCek()
        {
            String processorID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                processorID = obj["ProcessorId"].ToString();
            }

            return processorID;
        }
        public static String Display_Card_No()
        {

            string displaycard = null;
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            foreach (var o in managementObjectSearcher.Get())
            {
                var managementObject = (ManagementObject)o;
                foreach (PropertyData properties in managementObject.Properties)
                {
                    if (properties.Name == "SerialNumber")
                    {
                        displaycard = properties.Value.ToString();
                    }
                }
            }
            return displaycard;
        }

        public static String Mother_Board_No()
        {
            string motherBoardSerialNumber = null;
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (var o in managementObjectSearcher.Get())
            {
                var managementObject = (ManagementObject)o;
                foreach (PropertyData properties in managementObject.Properties)
                {
                    if (properties.Name == "SerialNumber")
                    {
                        motherBoardSerialNumber = properties.Value.ToString();
                        if (motherBoardSerialNumber != null)
                        {
                            break;
                        }
                    }
                }
            }
            return motherBoardSerialNumber;
        }


    }
}
