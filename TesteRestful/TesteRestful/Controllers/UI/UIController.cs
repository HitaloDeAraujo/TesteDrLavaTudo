using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteRestful.Controllers.UI
{
    public class UIController : Controller
    {
        //
        // GET: /UI/

        /// <summary>
        /// Busca ordem de servico com base no id
        /// </summary>
        public ActionResult OS(int id)
        {
            ViewBag.Title = "OS";

            ViewBag.id = id;

            return View();
        }

        /// <summary>
        /// Busca colecao de ordens de servico com base no id do cliente
        /// </summary>
        public ActionResult Cliente(int id)
        {
            ViewBag.Title = "Cliente";

            ViewBag.id = id;

            return View();
        }
    }
}
