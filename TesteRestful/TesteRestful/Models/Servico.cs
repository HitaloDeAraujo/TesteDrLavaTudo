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
    using System.Runtime.Serialization;
    
    public partial class Servico
    {
        public Servico()
        {
            this.ServicoPorOS = new HashSet<ServicoPorOS>();
        }
    
        public int IdServico { get; set; }
        public string Nome { get; set; }
        public Nullable<float> ValorFinal { get; set; }
        public Nullable<float> Custo { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<ServicoPorOS> ServicoPorOS { get; set; }
    }
}
