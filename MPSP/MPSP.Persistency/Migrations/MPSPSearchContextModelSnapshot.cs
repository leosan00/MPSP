﻿// <auto-generated />
using System;
using MPSP.Persistency.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MPSP.Persistency.Migrations
{
    [DbContext(typeof(MPSPSearchContext))]
    partial class MPSPSearchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MPSP.Model.Search.ClasseTeste", b =>
                {
                    b.Property<Guid>("ClasseTesteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("ClasseTesteId");

                    b.ToTable("Teste");
                });

            modelBuilder.Entity("MPSP.Model.Search.Jucesp", b =>
                {
                    b.Property<Guid>("JucespId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Capital");

                    b.Property<string>("Cep");

                    b.Property<string>("Cnpj");

                    b.Property<string>("Complemento");

                    b.Property<string>("Descricao");

                    b.Property<string>("Dt_constituicao");

                    b.Property<string>("Inicio_atv");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Municipio");

                    b.Property<string>("Numero_end");

                    b.Property<string>("Tipo_empresa");

                    b.Property<string>("Uf");

                    b.HasKey("JucespId");

                    b.ToTable("Jucesp");
                });

            modelBuilder.Entity("MPSP.Model.Search.Siel", b =>
                {
                    b.Property<Guid>("SielId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<string>("DataDom");

                    b.Property<string>("DataNascimento");

                    b.Property<string>("Endereco");

                    b.Property<string>("Municipio");

                    b.Property<string>("Naturalidade");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeMae");

                    b.Property<string>("NomePai");

                    b.Property<string>("Titulo");

                    b.Property<string>("Uf");

                    b.Property<string>("Zona");

                    b.HasKey("SielId");

                    b.ToTable("Siel");
                });
#pragma warning restore 612, 618
        }
    }
}
