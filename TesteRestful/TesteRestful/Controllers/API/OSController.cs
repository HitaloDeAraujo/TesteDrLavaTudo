using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteRestful.Models;

namespace TesteRestful.Controllers.API
{
    public class OSController : ApiController
    {
        bdDesafioEntities bd = new bdDesafioEntities(); //Base de dados

        /// <summary>
        /// Busca ordem de servico com base no id
        /// </summary>
        public OrdemServico Get(int id)
        {
            //Desabilita o Proxy para possibilitar serializacao
            //[IgnoreDataMember] deve ser usado nas classes do modelo (ModeloDeDados.tt) para evitar ciclos
            bd.Configuration.ProxyCreationEnabled = false;

            //Busca a ordem de servico com base no id e faz o mapeamento das entidades associadas
            OrdemServico os = bd.OrdemServico.Include("ServicoPorOS").Where(m => m.IdOS == id).SingleOrDefault();
            bd.ServicoPorOS.Include("Servico").Where(m => m.IdOS == id).ToList();
            bd.OrdemServico.Include("Cliente").Where(m => m.IdOS == id).SingleOrDefault();

            //encerra a funcao e devolve a OS encontrada e suas associacoes
            return os;
        }

        //public IEnumerable<OrdemServico> Get()
        //{
        //    bd.Configuration.ProxyCreationEnabled = false;

        //    IEnumerable<OrdemServico> os = bd.OrdemServico.Include("ServicoPorOS").ToList();
        //    bd.ServicoPorOS.Include("Servico").ToList();
        //    bd.OrdemServico.Include("Cliente").ToList();

        //    return os;
        //}

        /// <summary>
        /// Cria nova Ordem de Servico
        /// </summary>
        public bool Post(OrdemServico os)
        {
            try
            {
                bd.OrdemServico.Add(os);    //Adiciona a OS
                bd.SaveChanges();           //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Atualiza a Ordem de Servico os
        /// </summary>
        public bool Put(OrdemServico os)
        {
            try
            {
                bd.Entry(os).State = System.Data.EntityState.Modified;  //Atualiza a OS
                bd.SaveChanges();                                       //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Exclui a Ordem de Servico
        /// </summary>
        public bool Delete(int id)
        {
            try
            {
                //Busca a OS
                OrdemServico os = bd.OrdemServico.Where(x => x.IdOS == id).SingleOrDefault();

                //Busca colecao de ServicoPorOS associadas
                IEnumerable<ServicoPorOS> ListaSPO = bd.ServicoPorOS.Where(x => x.IdOS == os.IdOS).ToList();

                foreach (ServicoPorOS SPO in ListaSPO)
                    bd.ServicoPorOS.Remove(SPO);    //Remove Servico por OS associada

                bd.OrdemServico.Remove(os); //Remove a OS

                bd.SaveChanges();   //Salva as alteracoes
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
