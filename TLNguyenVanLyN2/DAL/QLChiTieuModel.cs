using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TLNguyenVanLyN2.DAL
{
    public partial class QLChiTieuModel : DbContext
    {
        public QLChiTieuModel()
            : base("name=QLChiTieuCaNhanModel")
        {
        }

        public virtual DbSet<GiaoDich> GiaoDiches { get; set; }
        public virtual DbSet<LoaiGD> LoaiGDs { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vi> Vis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoDich>()
                .Property(e => e.IdLoai)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiGD>()
                .Property(e => e.IdLoaiGD)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiGD>()
                .HasMany(e => e.GiaoDiches)
                .WithOptional(e => e.LoaiGD)
                .HasForeignKey(e => e.IdLoai);

            modelBuilder.Entity<Person>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Vis)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.IdPerson);
        }
    }
}
