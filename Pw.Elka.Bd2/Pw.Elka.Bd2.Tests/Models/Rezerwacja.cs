//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pw.Elka.Bd2.Tests.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezerwacja
    {
        public int id_rezerwacja { get; set; }
        public System.DateTime data_rezerwacji { get; set; }
        public Nullable<System.DateTime> gotowe_od { get; set; }
        public int id_pozycja { get; set; }
        public int id_klient { get; set; }
    
        public virtual Klient Klient { get; set; }
        public virtual Pozycja Pozycja { get; set; }
    }
}
