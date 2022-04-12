﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proje.data.Concrete.EfCore;

namespace proje.data.Migrations
{
    [DbContext(typeof(ProjeContext))]
    [Migration("20220320170403_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("proje.entity.Araba", b =>
                {
                    b.Property<int>("ArabaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("isim")
                        .HasColumnType("TEXT");

                    b.HasKey("ArabaId");

                    b.ToTable("Arabas");
                });

            modelBuilder.Entity("proje.entity.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TelNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("isim")
                        .HasColumnType("TEXT");

                    b.Property<string>("kullaniciAdi")
                        .HasColumnType("TEXT");

                    b.Property<string>("soyisim")
                        .HasColumnType("TEXT");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicis");
                });

            modelBuilder.Entity("proje.entity.KullaniciArabalari", b =>
                {
                    b.Property<int>("ArabaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArabaId", "KullaniciId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciArabalaris");
                });

            modelBuilder.Entity("proje.entity.KullaniciArabalari", b =>
                {
                    b.HasOne("proje.entity.Araba", "Araba")
                        .WithMany()
                        .HasForeignKey("ArabaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("proje.entity.Kullanici", "Kullanici")
                        .WithMany("KullaniciArabalari")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Araba");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("proje.entity.Kullanici", b =>
                {
                    b.Navigation("KullaniciArabalari");
                });
#pragma warning restore 612, 618
        }
    }
}
