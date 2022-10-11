using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace Agent_Portal_form
{
    public partial class Login : Form
    {
        private string resellerID;
        private string userID;
        private string password;
        public Login()
        {
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.resellerID = txtReseller.Text;
            this.userID = txtUser.Text;
            this.password = txtPassword.Text;

            var body = @"7|0|8|http://195.94.12.113:8081/agentportal/agentportal/|68B62360E6B3C6E5E4AE2B72ED9B474A|com.seamless.ers.client.agentPortal.client.common.AgentPortalService|login|java.lang.String/2004016611|" + this.resellerID + "|" + this.userID + "|" + this.password + "|1|2|3|4|4|5|5|5|5|6|7|8|0|";
            var res = Request(body);
            var state = res.Substring(2, 2);
            if(state == "OK")
            {
                this.Visible = false;
                Transactions f_transaction = new Transactions();
                f_transaction.Show();
            }
            else
            {
                MessageBox.Show("Login failed!");
            }
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {

            //Transactions f_transaction = new Transactions();
            //f_transaction.Show();
            this.resellerID = "";
            this.userID = "";
            this.password = "";
            txtReseller.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
        }

        public string Request(string body)
        {
            var client = new RestClient("http://195.94.12.113:8081/agentportal/agentportal/agentportal_service");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9,ko;q=0.8");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Type", "text/x-gwt-rpc; charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=96EFCFF561E98613DF676DAA0BA9246F");
            request.AddHeader("Origin", "http://195.94.12.113:8081");
            request.AddHeader("Referer", "http://195.94.12.113:8081/agentportal/agentportal/Application.html?locale=en");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36";
            request.AddHeader("X-GWT-Module-Base", "http://195.94.12.113:8081/agentportal/agentportal/");
            request.AddHeader("X-GWT-Permutation", "C4BC6D7A0AF75AD1AE083E450F49C38B");
            request.AddParameter("text/x-gwt-rpc; charset=UTF-8", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
