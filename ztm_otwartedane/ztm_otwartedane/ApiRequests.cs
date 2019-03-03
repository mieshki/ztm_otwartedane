using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ztm_otwartedane
{
    class ApiRequests
    {
        public static string GET(string url, string username = "", string password = "")
        {
            try
            {
                WebClient client = new WebClient();
                if (username != "" && password != "")
                    client.Credentials = new NetworkCredential(username, password);

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string response = reader.ReadToEnd();
                data.Close();
                reader.Close();

                return response;
            }
            catch (Exception)
            {
                //DisplayAlert("GTAX is unreachable \n" + exc.Message);
                return "#ERR";
            }

        }
    }
}
