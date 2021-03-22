using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSystem.SourceCode
{
    class ComboList
    {

        public static void FillDriverType(ComboBox cmb)
        {

            DataTable dtDriverType = new DataTable();
            dtDriverType.Columns.Add("DriverTypeID");
            dtDriverType.Columns.Add("DriverType");
            dtDriverType.Rows.Add("0", "---Select---");

            try
            {
                DataTable dt = DatabaseAccess.Select("select DriverTypeID, DriverType from DriverTypeTable");
                if(dt != null)
                {
                    if(dt.Rows.Count > 0)
                    {
                        foreach(DataRow userType in dt.Rows)
                        {
                            dtDriverType.Rows.Add(userType["DriverTypeID"], userType["DriverType"]);
                        }
                    }
                }

                cmb.DataSource = dtDriverType;
                cmb.ValueMember = "DriverTypeID";
                cmb.DisplayMember = "DriverType";
            }
            catch
            {
                cmb.DataSource = dtDriverType;
                cmb.ValueMember = "DriverTypeID";
                cmb.DisplayMember = "DriverType";
            }


        }


        public static void FillCarType(ComboBox cmb)
        {

            DataTable dtDriverType = new DataTable();
            dtDriverType.Columns.Add("CarTypeID");
            dtDriverType.Columns.Add("CarType");
            dtDriverType.Rows.Add("0", "---Select---");

            try
            {
                DataTable dt = DatabaseAccess.Select("select CarTypeID, CarType from CarTypeTable");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow userType in dt.Rows)
                        {
                            dtDriverType.Rows.Add(userType["CarTypeID"], userType["CarType"]);
                        }
                    }
                }

                cmb.DataSource = dtDriverType;
                cmb.ValueMember = "CarTypeID";
                cmb.DisplayMember = "CarType";
            }
            catch
            {
                cmb.DataSource = dtDriverType;
                cmb.ValueMember = "CarTypeID";
                cmb.DisplayMember = "CarType";
            }


        }

    }
}
