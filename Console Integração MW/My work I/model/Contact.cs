using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_work_I.model
{
    public class Contact
    {
        public IOrganizationService Service { get; set; }

        public string TableName = "opportunity";

        public Contact(IOrganizationService service)
        {
            this.Service = service;
        }

        public EntityCollection RetrieveMultipleContactsByOpportunity(Guid oportunidadeId)
        {
            QueryExpression queryContacts = new QueryExpression(this.TableName);
            queryContacts.ColumnSet.AddColumns("parentaccountid"); //Valor do Id da conta linkada a oportunidade
            queryContacts.Criteria.AddCondition("opportunityid", ConditionOperator.Equal, oportunidadeId); //Condição 
            queryContacts.AddLink("account", "parentaccountid", "accountid", JoinOperator.Inner); //Achar o nivel do cliente de acordo com o Id recebido
            queryContacts.LinkEntities[0].Columns.AddColumns("g07_niveldocliente"); //Valor no nivel do cliente
            queryContacts.LinkEntities[0].EntityAlias = "conta";

            return this.Service.RetrieveMultiple(queryContacts); ; //Erro de objeto, funcionava antes e continuava o programa
            //obs: caso queira continuar o programa, apagar a chamada desse método no Program.cs
        }
    }
}
