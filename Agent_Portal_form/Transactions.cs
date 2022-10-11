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
using System.Web.UI;

namespace Agent_Portal_form
{
    public partial class Transactions : Form
    {
        private DateTime fromDate;
        private DateTime toDate;
        private string phoneNumber;

        public string encryptDate(DateTime date)
        {           
            var y = date.Year - 1900;
            var m = date.Month - 1;
            var d = date.Day;


            object[] o = new object[] { y, m, d };
            object result = this.webBrowser1.Document.InvokeScript("encrypt", o);
            
            return (string)result;
        }

        public Transactions()
        {
            InitializeComponent();
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            fromDate = dtpFromDate.Value.Date + dtpFromDate.Value.TimeOfDay;
            toDate = dtpToDate.Value.Date + dtpToTime.Value.TimeOfDay;
            phoneNumber = txtPhone.Text;
            var body = @"7|0|29|http://195.94.12.113:8081/agentportal/agentportal/|68B62360E6B3C6E5E4AE2B72ED9B474A|com.seamless.ers.client.agentPortal.client.common.AgentPortalService|searchTransactions|com.seamless.ers.interfaces.ersifcommon.dto.PrincipalId/2130773517|java.lang.String/2004016611|java.util.Map|java.util.List|java.lang.Boolean/476441737|java.util.Date/3385151746|I|" + phoneNumber + @"|RESELLERMSISDN|Receiver|java.util.HashMap/1797211028|java.util.ArrayList/4159755760|REVERSE_CREDIT_TRANSFER|CREDIT_TRANSFER|OTHER|POSTPAID_TOPUP|POSTPAID_BILLPAY|POSTPAID|REVERSAL|REVERSE_TOPUP|TOPUP|USSD_DENY_REVERSAL|VAS_BUNDLE|PURCHASE||1|2|3|4|11|5|6|7|8|8|9|10|10|11|11|6|5|12|13|14|15|0|16|12|6|17|6|18|6|19|6|20|6|21|6|22|6|23|6|24|6|25|6|26|6|27|6|28|0|0|10|" + encryptDate(fromDate) + "|10|" + encryptDate(toDate) + "|0|5|29|";
            var res = Request(body);
            MessageBox.Show(res);
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
