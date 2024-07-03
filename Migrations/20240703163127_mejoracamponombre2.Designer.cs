﻿// <auto-generated />
using System;
using InfintyHibotPlt.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240703163127_mejoracamponombre2")]
    partial class mejoracamponombre2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Bitacora", b =>
                {
                    b.Property<long>("idBitacora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idBitacora"), 1L, 1);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("idConversation")
                        .HasColumnType("bigint");

                    b.Property<string>("jsonEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idBitacora");

                    b.ToTable("Bitacora");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Conversation", b =>
                {
                    b.Property<long>("idConversation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idConversation"), 1L, 1);

                    b.Property<string>("agente")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("agenteEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("assigend")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("closed")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("contactName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("contactPhoneWA")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset>("create")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idHibotConversation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("idItemInfinity")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("typing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idConversation");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Entrada", b =>
                {
                    b.Property<long>("idEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idEntrada"), 1L, 1);

                    b.Property<string>("JsonEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("fechaEntrada")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("idChat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idEntrada");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.ErroresBitacora", b =>
                {
                    b.Property<long>("idError")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idError"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("menssageError")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idError");

                    b.ToTable("ErroresBitacora");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Imagenes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Archivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("fecha")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("messagesidMessages")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("messagesidMessages");

                    b.ToTable("Imagenes");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Messages", b =>
                {
                    b.Property<long>("idMessages")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idMessages"), 1L, 1);

                    b.Property<long>("ConversationidConversation")
                        .HasColumnType("bigint");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("created")
                        .IsRequired()
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("idHibotMessages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("media")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mediaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("personContent")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idMessages");

                    b.HasIndex("ConversationidConversation");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Imagenes", b =>
                {
                    b.HasOne("InfintyHibotPlt.Datos.Models.Messages", "messages")
                        .WithMany()
                        .HasForeignKey("messagesidMessages")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("messages");
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Messages", b =>
                {
                    b.HasOne("InfintyHibotPlt.Datos.Models.Conversation", null)
                        .WithMany("messages")
                        .HasForeignKey("ConversationidConversation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InfintyHibotPlt.Datos.Models.Conversation", b =>
                {
                    b.Navigation("messages");
                });
#pragma warning restore 612, 618
        }
    }
}
