﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DiplomaEntities : DbContext
{
    public DiplomaEntities()
        : base("name=DiplomaEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Authorization> Authorization { get; set; }

    public virtual DbSet<Clients> Clients { get; set; }

    public virtual DbSet<Documents> Documents { get; set; }

    public virtual DbSet<Expenses> Expenses { get; set; }

    public virtual DbSet<Finance> Finance { get; set; }

    public virtual DbSet<Notaries> Notaries { get; set; }

    public virtual DbSet<Payments> Payments { get; set; }

    public virtual DbSet<Price_list> Price_list { get; set; }

    public virtual DbSet<Services_client> Services_client { get; set; }

    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

    public virtual DbSet<Type_documents> Type_documents { get; set; }

    public virtual DbSet<Type_of_operation> Type_of_operation { get; set; }

}

}

