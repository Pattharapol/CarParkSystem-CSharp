using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSystem.SourceCode
{
    public class PortConfiguration
    {
        public static int portNo;
        public static int baudRate;
        public static int timeOut;

        public void setPortNo(int setPort)
        {
            portNo = setPort;
        }

        public void setBaudRate(int setBaudRate)
        {
            baudRate = setBaudRate;
        }

        public void setTimeOut(int setTimeOut)
        {
            timeOut = setTimeOut;
        }

    }

    public class GSMConfiguration
    {
        public static string SendSMS5MinTest(string smsText, string contactList, int COMNO, int baudRate, int TimeOut)
        {
            bool result;
            try
            {
                SMSLibrary.ManageSmsGsm mngGsm = new SMSLibrary.ManageSmsGsm();
                result = mngGsm.SendSMSQueu(SMSLibrary.GsmComSetting.DefaultInfo(COMNO, baudRate, TimeOut), SMSLibrary.GsmComSetting.SelectMessageContact(smsText, contactList));
                if (result == true)
                    return "success";
                else
                    return "sending failed";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
