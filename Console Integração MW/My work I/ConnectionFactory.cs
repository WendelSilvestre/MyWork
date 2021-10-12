using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegração
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetCrmService()
        {
            string connectionString =
                "AuthType=OAuth;" +
                "Username=admin@t3grupo07.onmicrosoft.com;" +
                "Password=P@ssw0rd;" +
                "Url=https://org42afc0c4.crm2.dynamics.com/;" +
                "AppId=d81f9f2a-6125-ec11-b6e6-0022483725a9;" +
                "RedirectUri=app://58145891-0C36-4500-8554-080854F2AC97;";

            CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
            return crmServiceClient.OrganizationWebProxyClient;

        }
    }
}
