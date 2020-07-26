using CSharpAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpAssignment
{
    public partial class CosmeticSale : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool CheckLogin(string username, string password)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=THE-HIEN;Initial Catalog=CSharpAssignment;Integrated Security=SSPI");
            conn.Open();
            SqlCommand com = new SqlCommand("Select [ID],[Fullname],[StatusID],[Email] From Account Where Username = @username and Password = @password", conn);
            com.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            com.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                int id = dr.GetInt32(0);
                string fullname = dr.GetString(1);
                int statusId = dr.GetInt32(2);
                string email = dr.GetString(3);
                AccountDTO userInfo = new AccountDTO(id, username, fullname, statusId, email);
                
                Session["USER"] = userInfo;
                return true;
            }
            return false;
        }

        private int InsertAccount(string username, string password, string fullname, string email)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=THE-HIEN;Initial Catalog=CSharpAssignment;Integrated Security=SSPI");
            conn.Open();
            SqlCommand com = new SqlCommand("INSERT INTO [dbo].[Account] ([Username],[Password],[Fullname],[StatusID],[Email]) OUTPUT Inserted.ID VALUES(@username, @password, @fullname, @statusId, @email)", conn);
            com.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            com.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            com.Parameters.Add("@fullname", SqlDbType.VarChar).Value = fullname;
            com.Parameters.Add("@statusId", SqlDbType.Int).Value = 1;
            com.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                int id = dr.GetInt32(0);
                Console.WriteLine(id);
                return id;
            }
            return -1;
        }
        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            string fullname = TxtFullname.Text;
            string email = TxtEmail.Text;
            
            int idInsert = InsertAccount(username, password, fullname, email);
            if(idInsert != -1)
            {

            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsernameLogin.Text;
            string password = TxtPasswordLogin.Text;
            bool check = CheckLogin(username, password);
            if (check)
            {
                AccountDTO userInfo = (AccountDTO) Session["USER"];
            }
        }

    }
}