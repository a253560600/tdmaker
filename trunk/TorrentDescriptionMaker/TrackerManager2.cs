using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace TDMaker
{
    class TrackerManager2
    {
        public DataSet Trackers { get; set; }

        public TrackerManager2()
        {
            Trackers = new DataSet("Settings");
        }

        public DataSet Read()
        {
            if (File.Exists("trackers.xml"))
            {
                Trackers.ReadXml("trackers.xml");
            }

            else
            {
                Trackers = getDataSet(); 
            }

            return Trackers;
        }

        private DataSet getDataSet()
        {
            DataSet ds = new DataSet("Settings");
            DataTable dt = new DataTable("Trackers");
            dt.Columns.Add("Name");
            dt.Columns.Add("AnnounceURL");
            ds.Tables.Add(dt);

            return ds;
        }

        public void Write(DataGridView dgv)
        {
            DataSet ds = getDataSet();
            DataTable  dt = ds.Tables[0];

            for (int i = 0; i < dgv.Rows.Count-1; i++)
            {
                DataRow row;
                row = dt.NewRow();
                row[0] = dgv.Rows[i].Cells[0].Value;
                row[1] = dgv.Rows[i].Cells[1].Value;
                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            ds.WriteXml("trackers.xml");
        }
    }
}
