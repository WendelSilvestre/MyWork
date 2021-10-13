using ConsoleIntegração.model;
using Microsoft.Xrm.Sdk;
using My_work_I.model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIntegração
{
    public class Program
    {
        static void Main(string[] args)
        {

            int x;

            Console.WriteLine("Qual oportunidade você deseja aplicar o desconto?");
            String oportunidadeId = Console.ReadLine(); 
            //IdOportunidade a ser usado: 7b1795da-ce27-ec11-b6e6-002248372ef6 

            //Conexão com o servidor
            IOrganizationService service = ConnectionFactory.GetCrmService(); 
            Contact contact = new Contact(service);

            //Buscar oportunidade 
            EntityCollection contactsCRM = contact.RetrieveMultipleContactsByOpportunity(new Guid(oportunidadeId)); 

            foreach (Entity contactCRM in contactsCRM.Entities)
            {
                //string nivel = (string)((AliasedValue)contactCRM["conta.g07_niveldocliente"]).Value;

                //Perceba que não consegui transformar o nivel do cliente em texto ou int então não consegui utiliza-lo
                Console.WriteLine("O desconto é de: " + contactCRM["conta.g07_niveldocliente"]);

                //Money bruto = (Money)((AliasedValue)contactCRM["totallineitemamount"]).Value;

                //Colocando valores fixos para que tenha algo para dar update na tabela, mas seriam substituidos se o cast funcionasse
                Double bruto = 200;
                Double nivel = 3;
                Double descount = bruto * (nivel/ 100);

                do
                {
                    x = 1;
                    Console.WriteLine("Você deseja atualizar essa oportunidade? Y/N");
                    char resp = (char)Console.Read();
                    if (resp == 'Y' || resp == 'y')
                    {
                        //Update da oportunidade
                        Opportunity opportunity = new Opportunity(service);
                        opportunity.UpdateOpportunity(descount, oportunidadeId);
                        Console.WriteLine("Valor atualizado!");
                    }
                    else if (resp == 'N' || resp == 'n')
                    {
                        Console.WriteLine("Ok! Obrigado!");
                    }
                    else
                    {
                        Console.WriteLine("Valor inserido não é valido");
                        x = 0;
                    }
                } while (x == 0);
            }
            Console.ReadKey();
        }
    }
}
