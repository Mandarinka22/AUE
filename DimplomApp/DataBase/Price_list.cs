
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
    
public partial class Price_list
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Price_list()
    {

        this.Documents = new HashSet<Documents>();

    }


    public int ID_price { get; set; }

    public Nullable<int> Type_documentID { get; set; }

    public Nullable<decimal> Sum { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Documents> Documents { get; set; }

    public virtual Type_documents Type_documents { get; set; }

}

}