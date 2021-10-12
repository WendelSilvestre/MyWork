using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegração.model
{
    class Opportunity
    {
        public string TableName = "opportunity";

        public IOrganizationService Service { get; set; }

        public Opportunity(IOrganizationService service)
        {
            this.Service = service;
        }

        public void UpdateOpportunity(double desconto)
        {
            //Update da table oportunidade no campo desconto recebendo 
            Entity opportunity = new Entity(this.TableName);
            opportunity["discountamount"] = desconto;
            this.Service.Update(opportunity);
        }
    }
}
