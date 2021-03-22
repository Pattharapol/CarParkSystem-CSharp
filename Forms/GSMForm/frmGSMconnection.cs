using CarParkSystem.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.Forms.GRMForm
{
    public partial class frmGSMconnection : Form
    {
        public frmGSMconnection()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RetriveDevice();
            tBoxTimeOut.Text = "1500";
            tBoxBaudRate.Text = "19600";
        }

        private void RetriveDevice()
        {
            List<string> lsts = new List<string>();
            cmbPortNo.Items.Clear();
            if(cmbPortNo.Items.Count == 0)
            {

                var usbDevices = GetUSBDevices();
                string CmbItem = "";
                foreach(var usbDevice in usbDevices)
                {
                    CmbItem = "";
                    CmbItem = usbDevice.DeviceID + " (" + usbDevice.Name + ")";
                    cmbPortNo.Items.Add(CmbItem);
                }
                if(CmbItem.Trim().Length > 0)
                {
                    btnReset.Enabled = true;
                }
                else
                {
                    btnReset.Enabled = false;
                }
            }
        }

        private static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("select * from Win32_SerialPort");
            collection = ManObjSearch.Get();
            foreach(var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Name"),
                    (string)device.GetPropertyValue("Caption"),
                    (string)device.GetPropertyValue("Description"),
                    (string)device.GetPropertyValue("ProviderType"),
                    (string)device.GetPropertyValue("Status")
                    ));
            }

            collection.Dispose();
            return devices;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            epConfiguration.Clear();
            if(cmbPortNo.Text.Trim().Length == 0 || !cmbPortNo.Text.Trim().Contains("M"))
            {
                epConfiguration.SetError(cmbPortNo, "Please Connect Device or Enter our Device Prot No.");
                cmbPortNo.Focus();
                cmbPortNo.SelectAll();
                return;
            }

            if (tBoxBaudRate.Text.Trim().Length == 0)
            {
                epConfiguration.SetError(tBoxBaudRate, "Please Enter BaudRate or Press Reset label!");
                tBoxBaudRate.Focus();
                tBoxBaudRate.SelectAll();
                return;
            }

            if (tBoxTimeOut.Text.Trim().Length == 0)
            {
                epConfiguration.SetError(tBoxTimeOut, "Please Enter TimeOut or Press Reset label!");
                tBoxTimeOut.Focus();
                tBoxTimeOut.SelectAll();
                return;
            }

            int indx = cmbPortNo.Text.IndexOf("M");
            int COMNO = Convert.ToInt32(cmbPortNo.Text.Trim().Substring(indx + 1, indx));

            int baudRate = Convert.ToInt32(tBoxBaudRate.Text.Trim());
            int timeOut = Convert.ToInt32(tBoxTimeOut.Text.Trim());
            PortConfiguration.portNo = COMNO;
            PortConfiguration.baudRate = baudRate;
            PortConfiguration.timeOut = timeOut;
            MessageBox.Show("Connection is OK!", "GSM System");
            this.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RetriveDevice();
            tBoxTimeOut.Text = "1500";
            tBoxBaudRate.Text = "19600";
        }

        private void FrmGSMconnection_Load(object sender, EventArgs e)
        {
            RetriveDevice();
        }
    }
}
