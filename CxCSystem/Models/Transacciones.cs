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
    
    public partial class Transacciones
    {
        public int Id { get; set; }
        public string Id_transaccion { get; set; }
        public string Tipo_Mov { get; set; }
        public int TipoDoc_ID { get; set; }
        public string Num_doc { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Cliente_ID { get; set; }
        public int Monto { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Tipos_Documentos Tipos_Documentos { get; set; }
    }
}
