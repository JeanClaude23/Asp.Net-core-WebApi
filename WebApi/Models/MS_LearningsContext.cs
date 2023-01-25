using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class MS_LearningsContext : DbContext
    {
        public MS_LearningsContext()
        {
        }

        public MS_LearningsContext(DbContextOptions<MS_LearningsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AxisTest> AxisTests { get; set; } = null!;
        public virtual DbSet<CoreMvcCustomer> CoreMvcCustomers { get; set; } = null!;
        public virtual DbSet<CoreMvcCustomerDetail> CoreMvcCustomerDetails { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<IsgAsset> IsgAssets { get; set; } = null!;
        public virtual DbSet<MetabaseSource> MetabaseSources { get; set; } = null!;
        public virtual DbSet<MetabaseTicket> MetabaseTickets { get; set; } = null!;
        public virtual DbSet<MetabaseUser> MetabaseUsers { get; set; } = null!;
        public virtual DbSet<MetabaseUserSource> MetabaseUserSources { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<OfficeAssignment> OfficeAssignments { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<RankDetail> RankDetails { get; set; } = null!;
        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;
        public virtual DbSet<StudentScore> StudentScores { get; set; } = null!;
        public virtual DbSet<TblAuthUser> TblAuthUsers { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;
        public virtual DbSet<TblStudentCopy> TblStudentCopies { get; set; } = null!;
        public virtual DbSet<TestTable> TestTables { get; set; } = null!;
        public virtual DbSet<Teststudent> Teststudents { get; set; } = null!;
        public virtual DbSet<Testview> Testviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<WebApiUser> WebApiUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Data Source=192.168.8.4;Initial Catalog=MS_Learnings;User ID=ms_learning;Password=$Lsme123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AxisTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AXIS_Test");

                entity.Property(e => e.TicketId).HasColumnName("TicketID");
            });

            modelBuilder.Entity<CoreMvcCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Customer");

                entity.ToTable("CoreMVC_Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<CoreMvcCustomerDetail>(entity =>
            {
                entity.HasKey(e => e.CustomerDetailId)
                    .HasName("PK_CustomerDetail");

                entity.ToTable("CoreMVC_CustomerDetail");

                entity.Property(e => e.CustomerDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerDetailID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CoreMvcCustomerDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerDetail_Customer");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.DepartmentId, "IX_DepartmentID");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.Course_dbo.Department_DepartmentID");

                entity.HasMany(d => d.Instructors)
                    .WithMany(p => p.Courses)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseInstructor",
                        l => l.HasOne<Person>().WithMany().HasForeignKey("InstructorId").HasConstraintName("FK_dbo.CourseInstructor_dbo.Person_InstructorID"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId").HasConstraintName("FK_dbo.CourseInstructor_dbo.Course_CourseID"),
                        j =>
                        {
                            j.HasKey("CourseId", "InstructorId").HasName("PK_dbo.CourseInstructor");

                            j.ToTable("CourseInstructor");

                            j.HasIndex(new[] { "CourseId" }, "IX_CourseID");

                            j.HasIndex(new[] { "InstructorId" }, "IX_InstructorID");

                            j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");

                            j.IndexerProperty<int>("InstructorId").HasColumnName("InstructorID");
                        });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.InstructorId, "IX_InstructorID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Budget).HasColumnType("money");

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_dbo.Department_dbo.Person_InstructorID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.HasIndex(e => e.CourseId, "IX_CourseID");

                entity.HasIndex(e => e.StudentId, "IX_StudentID");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Enrollment_dbo.Person_StudentID");
            });

            modelBuilder.Entity<IsgAsset>(entity =>
            {
                entity.ToTable("ISG_Assets");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HighResolutionPath).IsUnicode(false);

                entity.Property(e => e.PreviewPath).IsUnicode(false);

                entity.Property(e => e.ThumbPath).IsUnicode(false);
            });

            modelBuilder.Entity<MetabaseSource>(entity =>
            {
                entity.ToTable("Metabase_Source");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SourceName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_NAME");
            });

            modelBuilder.Entity<MetabaseTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Metabase__7F5E71D603244B5D");

                entity.ToTable("Metabase_Ticket");

                entity.Property(e => e.TicketId).HasColumnName("TICKET_ID");

                entity.Property(e => e.AccountTier)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_TIER");

                entity.Property(e => e.Agent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AGENT");

                entity.Property(e => e.CompanyDomains)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_DOMAINS");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_NAME");

                entity.Property(e => e.ContactId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.CustomerInteractions).HasColumnName("CUSTOMER_INTERACTIONS");

                entity.Property(e => e.CustomerSignature)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_SIGNATURE");

                entity.Property(e => e.FirstResponseTimeHr).HasColumnName("FIRST_RESPONSE_TIME_HR");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.HealthScore)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HEALTH_SCORE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY");

                entity.Property(e => e.InitialResponseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("INITIAL_RESPONSE_TIME");

                entity.Property(e => e.Priority)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Product)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.RenewalDate)
                    .HasColumnType("datetime")
                    .HasColumnName("RENEWAL_DATE");

                entity.Property(e => e.Source).HasColumnName("SOURCE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Subject)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.Type)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.MetabaseTickets)
                    .HasForeignKey(d => d.Source)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TICKET_SOURCE");
            });

            modelBuilder.Entity<MetabaseUser>(entity =>
            {
                entity.ToTable("Metabase_User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<MetabaseUserSource>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Metabase_UserSource");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.SourceId).HasColumnName("SOURCE_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Source)
                    .WithMany()
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOURCE");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<OfficeAssignment>(entity =>
            {
                entity.HasKey(e => e.InstructorId)
                    .HasName("PK_dbo.OfficeAssignment");

                entity.ToTable("OfficeAssignment");

                entity.HasIndex(e => e.InstructorId, "IX_InstructorID");

                entity.Property(e => e.InstructorId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstructorID");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.HasOne(d => d.Instructor)
                    .WithOne(p => p.OfficeAssignment)
                    .HasForeignKey<OfficeAssignment>(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.OfficeAssignment_dbo.Person_InstructorID");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discriminator).HasMaxLength(128);

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Grade)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Total)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentScore>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__StudentS__A2F4E9AC6B8CC737");

                entity.ToTable("StudentScore");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Student_ID");

                entity.Property(e => e.Class)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CLASS")
                    .IsFixedLength();

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .HasColumnName("Student_Name");

                entity.Property(e => e.StudentScore1).HasColumnName("Student_Score");
            });

            modelBuilder.Entity<TblAuthUser>(entity =>
            {
                entity.ToTable("tblAuthUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__tbl_stud__AA2FFB8534AEFAD3");

                entity.ToTable("tbl_student");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStudentCopy>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__tbl_stud__AA2FFB859C92FA42");

                entity.ToTable("tbl_student_copy");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestTable");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");
            });

            modelBuilder.Entity<Teststudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TESTSTUDENT");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Testview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("testview");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserInfo");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<WebApiUser>(entity =>
            {
                entity.ToTable("WebApiUser");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
