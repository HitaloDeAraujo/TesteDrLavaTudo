//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesteRestful.Models
{
    using System;
    using System.Collections.Generic;

    public partial class OrdemServico
    {
        public OrdemServico()
        {
            this.ServicoPorOS = new HashSet<ServicoPorOS>();
        }

        public int IdOS { get; set; }
        public string IdCliente { get; set; }
        public Nullable<System.DateTime> DataContratacao { get; set; }
        public Nullable<System.DateTime> DataExecucao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ServicoPorOS> ServicoPorOS { get; set; }
    }
}
