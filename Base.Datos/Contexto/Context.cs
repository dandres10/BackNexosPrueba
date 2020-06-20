namespace Base.Datos.Contexto
{
    using Base.Datos.Contexto.Entidades;
    using Microsoft.EntityFrameworkCore;

    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorPaciente> DoctorPaciente { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.CodigoDoctor)
                    .HasName("PK__Doctor__C4BA93673C9D76F0");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCredencial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EspecialidadNavigation)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.Especialidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorEspecialidad");

                entity.HasOne(d => d.HospitalNavigation)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.Hospital)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorHospital");
            });

            modelBuilder.Entity<DoctorPaciente>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.CodigoDoctorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorPacienteDoctor");

                entity.HasOne(d => d.CodigoPacienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorPacientePaciente");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.CodigoEspecialidad)
                    .HasName("PK__Especial__CA163B49C6AD3105");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.CodigoHospital)
                    .HasName("PK__Hospital__98CCC0B073047936");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.CodigoPaciente)
                    .HasName("PK__Paciente__204AE6F62CDFF651");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodPostal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}