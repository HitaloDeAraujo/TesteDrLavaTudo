using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteRestful.Models;

namespace TesteRestful.Controllers
{
    public class ClienteController : ApiController
    {
        bdDesafioEntities bd = new bdDesafioEntities(); //Base de dados

        /// <summary>
        /// Busca ordem de servico com base no id do cliente
        /// </summary>
        public IEnumerable<OrdemServico> Get(string id)
        {
            //Desabilita o Proxy para possibilitar serializacao
            //[IgnoreDataMember] deve ser usado nas classes do modelo (ModeloDeDados.tt) para evitar ciclos
            bd.Configuration.ProxyCreationEnabled = false;

            //Busca a ordem de servico com base no id do cliente e faz o mapeamento das entidades associadas
            IEnumerable<OrdemServico> ColecaoOS = bd.OrdemServico.Include("ServicoPorOS").Where(x => x.IdCliente == id).ToList();
            bd.ServicoPorOS.Include("Servico").Where(m => m.OrdemServico.IdCliente == id).ToList();
            bd.OrdemServico.Include("Cliente").Where(m => m.IdCliente == id).ToList();

            //encerra a funcao e devolve a colecao de OS encontrada e suas associacoes
            return ColecaoOS;
        }

        //public IEnumerable<OrdemServico> Get()
        //{
        //    bd.Configuration.ProxyCreationEnabled = false;

        //    IEnumerable<OrdemServico> ColecaoOS = bd.OrdemServico.Include("ServicoPorOS").ToList();
        //    bd.ServicoPorOS.Include("Servico").ToList();
        //    bd.OrdemServico.Include("Cliente").ToList();

        //    return ColecaoOS;
        //}

        /// <summary>
        /// Cria novo Cliente
        /// </summary>
        public bool Post(Cliente cliente)
        {
            try
            {
                bd.Cliente.Add(cliente);    //Adiciona o Cliente
                bd.SaveChanges();           //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Atualiza o Cliente
        /// </summary>
        public bool Put(Cliente cliente)
        {
            try
            {
                bd.Entry(cliente).State = System.Data.EntityState.Modified; //Atualiza o Cliente
                bd.SaveChanges();                                           //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Exclui o Cliente
        /// </summary>
        public bool Delete(string id)
        {
            try
            {
                //Busca as Ordens de Servico associadas ao Cliente
                IEnumerable<OrdemServico> ListaOS = bd.OrdemServico.Where(x => x.IdCliente == id).ToList();

                foreach (OrdemServico OS in ListaOS)    //Para cada OS
                {
                    //Busca colecao de ServicoPorOS associada
                    IEnumerable<ServicoPorOS> ListaSPO = bd.ServicoPorOS.Where(x => x.IdOS == OS.IdOS).ToList();

                    foreach (ServicoPorOS SPO in ListaSPO)  //Para cada ServicoPorOS
                        bd.ServicoPorOS.Remove(SPO);        //Remove a ServicoPorOS

                    bd.OrdemServico.Remove(OS);             //Remove a OS
                }
                
                Cliente cliente = bd.Cliente.Find(id);      //Busca o Cliente
                bd.Cliente.Remove(cliente);                 //Remove o Cliente

                bd.SaveChanges();                           //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
