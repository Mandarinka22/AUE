
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DimplomApp.DataBase
{

using System;
    using System.Collections.Generic;

    public partial class Payments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payments()
        {
            this.Finance = new HashSet<Finance>();
        }

        public int ID_payments { get; set; }
        public Nullable<System.DateTime> Date_payments { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public string Description { get; set; }
        public Nullable<int> ServicesID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finance> Finance { get; set; }
        public virtual Services_client Services_client { get; set; }
    }

}
