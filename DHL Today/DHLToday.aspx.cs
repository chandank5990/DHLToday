using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace DHL_Today
{
    public partial class DHLToday : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=W:\test\Access\Tablas.mdb");
        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CSK\Tablas.mdb");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            Label2.Visible = false;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string txtObservation = TextBox1.Text;
            OleDbCommand cmd = con.CreateCommand();
            if (Pending.Checked && Delivered.Checked == false)
            {
                cmd = new OleDbCommand("SELECT NumOrd, Observaciones, Location, ArtOrd FROM [Ordenes de fabricación] WHERE Observaciones Like '%" + txtObservation + "%' and FinOrd is Null", con);
            }
            if (Delivered.Checked && Pending.Checked == false)
            {
                cmd = new OleDbCommand("SELECT NumOrd, Observaciones, Location, ArtOrd FROM [Ordenes de fabricación] WHERE Observaciones Like '%" + txtObservation + "%' and FinOrd is Not Null", con);
            }
            if (Pending.Checked && Delivered.Checked)
            {
                cmd = new OleDbCommand("SELECT NumOrd, Observaciones, Location, ArtOrd FROM [Ordenes de fabricación] WHERE Observaciones Like '%" + txtObservation + "%' ", con);
            }
            if (Pending.Checked == false && Delivered.Checked == false)
            {
                cmd = new OleDbCommand("SELECT NumOrd, Observaciones, Location, ArtOrd FROM [Ordenes de fabricación] WHERE Observaciones Like '%" + txtObservation + "%' and FinOrd is Null", con);
            }
            OleDbDataAdapter oleda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oleda.Fill(dt);
            //Removing Global....................
            foreach (DataRow dr in dt.Rows)
            {
                string Observation = Convert.ToString(dr["Observaciones"]);
                if (Observation.Contains("DHL"))
                {

                }
                else
                {
                    dr.Delete();
                }
            }
            Label2.Visible = true;
            dt.AcceptChanges();
            lblNoOfDHL.Text = (dt.Rows.Count).ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void lnkView_Click(object sender, EventArgs e)
        {

            //Pop up...........................
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int intId = 100;

            string strPopup = "<script language='javascript' ID='script1'>"

            // Passing intId to popup window.
            + "window.open('DrawingInPopup.aspx?UID=" + grdrow.Cells[0].Text + "&Article=" + grdrow.Cells[3].Text + "&testdrawing= kkk" + "data=" + HttpUtility.UrlEncode("UID=" + grdrow.Cells[0].Text + "&Article=" + grdrow.Cells[3].Text + "&testdrawing= kkk")

            + "','new window', 'top=70, left=250, width=470, height=590, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"

            + "</script>";

            ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopup, false);

        }
    }
}