using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client1_Csharp.utils
{
    public class SetInfos
    {
        public static string DisplayLocalHostName()
        {
            string hostName = "?";
            try
            {
                hostName = Dns.GetHostName();
                Console.WriteLine("Computer name :" + hostName);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            return hostName;
        }

        public static string LocalUserName()
        {
            return Environment.UserName;
        }


        public static DateTime GetTimeStamp()
        {
            return DateTime.Now;
        }
    }
}
