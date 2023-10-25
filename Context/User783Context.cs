using System;
using System.Collections.Generic;
using MarathonSkills2016.Models;
using Microsoft.EntityFrameworkCore;

namespace MarathonSkills2016.Context;

public partial class User783Context : DbContext
{
    public User783Context()
    {
    }

    public User783Context(DbContextOptions<User783Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Charity> Charities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Eventtype> Eventtypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Marathon> Marathons { get; set; }

    public virtual DbSet<Myresult> Myresults { get; set; }
    
    public virtual DbSet<Runnerinf> Runnerinf { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Racekitoption> Racekitoptions { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Registrationevent> Registrationevents { get; set; }

    public virtual DbSet<Registrationstatus> Registrationstatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Runner> Runners { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Sponsorship> Sponsorships { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Database = user783; Username = user783; Host = 192.168.0.4; Password = 49242");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Charity>(entity =>
        {
            entity.HasKey(e => e.Charityid).HasName("charity_pkey");

            entity.ToTable("charity", "Test2");

            entity.Property(e => e.Charityid).HasColumnName("charityid");
            entity.Property(e => e.Charitydescription)
                .HasMaxLength(2000)
                .HasColumnName("charitydescription");
            entity.Property(e => e.Charitylogo)
                .HasMaxLength(50)
                .HasColumnName("charitylogo");
            entity.Property(e => e.Charityname)
                .HasMaxLength(100)
                .HasColumnName("charityname");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countrycode).HasName("country_pkey");

            entity.ToTable("country", "Test2");

            entity.Property(e => e.Countrycode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("countrycode");
            entity.Property(e => e.Countryflag)
                .HasMaxLength(100)
                .HasColumnName("countryflag");
            entity.Property(e => e.Countryname)
                .HasMaxLength(100)
                .HasColumnName("countryname");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("event_pkey");

            entity.ToTable("event", "Test2");

            entity.Property(e => e.Eventid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("eventid");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Eventname)
                .HasMaxLength(50)
                .HasColumnName("eventname");
            entity.Property(e => e.Eventtypeid)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("eventtypeid");
            entity.Property(e => e.Marathonid).HasColumnName("marathonid");
            entity.Property(e => e.Maxparticipants).HasColumnName("maxparticipants");
            entity.Property(e => e.Starttimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttimestamp");

            entity.HasOne(d => d.Eventtype).WithMany(p => p.Events)
                .HasForeignKey(d => d.Eventtypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_eventtypeid_fkey");

            entity.HasOne(d => d.Marathon).WithMany(p => p.Events)
                .HasForeignKey(d => d.Marathonid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("event_marathonid_fkey");
        });

        modelBuilder.Entity<Eventtype>(entity =>
        {
            entity.HasKey(e => e.Eventtypeid).HasName("eventtype_pkey");

            entity.ToTable("eventtype", "Test2");

            entity.Property(e => e.Eventtypeid)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("eventtypeid");
            entity.Property(e => e.Eventtypename)
                .HasMaxLength(50)
                .HasColumnName("eventtypename");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Gender1).HasName("gender_pkey");

            entity.ToTable("gender", "Test2");

            entity.Property(e => e.Gender1)
                .HasMaxLength(10)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Marathon>(entity =>
        {
            entity.HasKey(e => e.Marathonid).HasName("marathon_pkey");

            entity.ToTable("marathon", "Test2");

            entity.Property(e => e.Marathonid).HasColumnName("marathonid");
            entity.Property(e => e.Cityname)
                .HasMaxLength(80)
                .HasColumnName("cityname");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("countrycode");
            entity.Property(e => e.Marathonname)
                .HasMaxLength(80)
                .HasColumnName("marathonname");
            entity.Property(e => e.Yearheld).HasColumnName("yearheld");

            entity.HasOne(d => d.CountrycodeNavigation).WithMany(p => p.Marathons)
                .HasForeignKey(d => d.Countrycode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("marathon_countrycode_fkey");
        });

        modelBuilder.Entity<Myresult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("myresult", "Test2");

            entity.Property(e => e.Bibnumber).HasColumnName("bibnumber");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Eventid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("eventid");
            entity.Property(e => e.Eventname)
                .HasMaxLength(50)
                .HasColumnName("eventname");
            entity.Property(e => e.Eventtypename)
                .HasMaxLength(50)
                .HasColumnName("eventtypename");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Racetime).HasColumnName("racetime");
            entity.Property(e => e.Registrationtimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationtimestamp");
        });
        
        modelBuilder.Entity<Runnerinf>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("runnerinf", "Test2");
            
            entity.Property(e => e.Runnerid).HasColumnName("runnerid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Firstname)
                .HasMaxLength(80)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .HasColumnName("lastname");
            entity.Property(e => e.Bibnumber).HasColumnName("bibnumber");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("countrycode");
            entity.Property(e => e.Sponsorname)
                .HasMaxLength(150)
                .HasColumnName("sponsorname");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Positionid).HasName("position_pkey");

            entity.ToTable("position", "Test2");

            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Positiondescription)
                .HasMaxLength(80)
                .HasColumnName("positiondescription");
            entity.Property(e => e.Positionname)
                .HasMaxLength(80)
                .HasColumnName("positionname");
        });

        modelBuilder.Entity<Racekitoption>(entity =>
        {
            entity.HasKey(e => e.Racekitoptionid).HasName("racekitoption_pkey");

            entity.ToTable("racekitoption", "Test2");

            entity.Property(e => e.Racekitoptionid)
                .HasMaxLength(1)
                .ValueGeneratedNever()
                .HasColumnName("racekitoptionid");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Racekitoption1)
                .HasMaxLength(80)
                .HasColumnName("racekitoption");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Registrationid).HasName("registration_pkey");

            entity.ToTable("registration", "Test2");

            entity.Property(e => e.Registrationid).HasColumnName("registrationid");
            entity.Property(e => e.Charityid).HasColumnName("charityid");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Racekitoptionid)
                .HasMaxLength(1)
                .HasColumnName("racekitoptionid");
            entity.Property(e => e.Registrationstatusid).HasColumnName("registrationstatusid");
            entity.Property(e => e.Registrationtimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registrationtimestamp");
            entity.Property(e => e.Runnerid).HasColumnName("runnerid");
            entity.Property(e => e.Sponsorshiptarget)
                .HasPrecision(10, 2)
                .HasColumnName("sponsorshiptarget");

            entity.HasOne(d => d.Charity).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Charityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_charityid_fkey");

            entity.HasOne(d => d.Racekitoption).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Racekitoptionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_racekitoptionid_fkey");

            entity.HasOne(d => d.Registrationstatus).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Registrationstatusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_registrationstatusid_fkey");

            entity.HasOne(d => d.Runner).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.Runnerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registration_runnerid_fkey");
        });

        modelBuilder.Entity<Registrationevent>(entity =>
        {
            entity.HasKey(e => e.Registrationeventid).HasName("registrationevent_pkey");

            entity.ToTable("registrationevent", "Test2");

            entity.Property(e => e.Registrationeventid).HasColumnName("registrationeventid");
            entity.Property(e => e.Bibnumber).HasColumnName("bibnumber");
            entity.Property(e => e.Eventid)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("eventid");
            entity.Property(e => e.Racetime).HasColumnName("racetime");
            entity.Property(e => e.Registrationid).HasColumnName("registrationid");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrationevents)
                .HasForeignKey(d => d.Eventid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registrationevent_eventid_fkey");

            entity.HasOne(d => d.Registration).WithMany(p => p.Registrationevents)
                .HasForeignKey(d => d.Registrationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registrationevent_registrationid_fkey");
        });

        modelBuilder.Entity<Registrationstatus>(entity =>
        {
            entity.HasKey(e => e.Registrationstatusid).HasName("registrationstatus_pkey");

            entity.ToTable("registrationstatus", "Test2");

            entity.Property(e => e.Registrationstatusid).HasColumnName("registrationstatusid");
            entity.Property(e => e.Registrationstatus1)
                .HasMaxLength(80)
                .HasColumnName("registrationstatus");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");

            entity.ToTable("role", "Test2");

            entity.Property(e => e.Roleid)
                .HasMaxLength(1)
                .ValueGeneratedNever()
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Runner>(entity =>
        {
            entity.HasKey(e => e.Runnerid).HasName("runner_pkey");

            entity.ToTable("runner", "Test2");

            entity.Property(e => e.Runnerid).HasColumnName("runnerid");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("countrycode");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");

            entity.HasOne(d => d.CountrycodeNavigation).WithMany(p => p.Runners)
                .HasForeignKey(d => d.Countrycode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("runner_countrycode_fkey");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Runners)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("runner_email_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Runners)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("runner_gender_fkey");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Schedulesid).HasName("schedules_pkey");

            entity.ToTable("schedules", "Test2");

            entity.Property(e => e.Schedulesid).HasColumnName("schedulesid");
            entity.Property(e => e.Schedulesname)
                .HasMaxLength(80)
                .HasColumnName("schedulesname");
        });

        modelBuilder.Entity<Sponsorship>(entity =>
        {
            entity.HasKey(e => e.Sponsorshipid).HasName("sponsorship_pkey");

            entity.ToTable("sponsorship", "Test2");

            entity.Property(e => e.Sponsorshipid).HasColumnName("sponsorshipid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Registrationid).HasColumnName("registrationid");
            entity.Property(e => e.Sponsorname)
                .HasMaxLength(150)
                .HasColumnName("sponsorname");

            entity.HasOne(d => d.Registration).WithMany(p => p.Sponsorships)
                .HasForeignKey(d => d.Registrationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sponsorship_registrationid_fkey");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Staffid).HasName("staff_pkey");

            entity.ToTable("staff", "Test2");

            entity.Property(e => e.Staffid).HasColumnName("staffid");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(80)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Fullname)
                .HasMaxLength(80)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Payperiod)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("payperiod");
            entity.Property(e => e.Positionid).HasColumnName("positionid");
            entity.Property(e => e.Schedulesid).HasColumnName("schedulesid");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Positionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("staff_positionid_fkey");

            entity.HasOne(d => d.Schedules).WithMany(p => p.Staff)
                .HasForeignKey(d => d.Schedulesid)
                .HasConstraintName("staff_schedulesid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("users_pkey");

            entity.ToTable("users", "Test2");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(80)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Roleid)
                .HasMaxLength(1)
                .HasColumnName("roleid");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roleid_fkey");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.Volunteerid).HasName("volunteer_pkey");

            entity.ToTable("volunteer", "Test2");

            entity.Property(e => e.Volunteerid).HasColumnName("volunteerid");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("countrycode");
            entity.Property(e => e.Firstname)
                .HasMaxLength(80)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(80)
                .HasColumnName("lastname");

            entity.HasOne(d => d.CountrycodeNavigation).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.Countrycode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("volunteer_countrycode_fkey");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("volunteer_gender_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
