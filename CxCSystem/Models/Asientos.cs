//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CxCSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asientos
    {
        public int Id { get; set; }
        public string Id_Asiento { get; set; }
        public string Descripcion { get; set; }
        public int Cliente_ID { get; set; }
        public string CuentaDB { get; set; }
        public string CuentaCR { get; set; }
        public int MontoDB { get; set; }
        public int MontoCR { get; set; }
    
        public virtual Clientes Clientes { get; set; }
    }
}
