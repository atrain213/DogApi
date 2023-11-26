using Microsoft.EntityFrameworkCore;

namespace DogApi
{
    public class DogContext : DbContext
    {
        private readonly string _connect = @"Server=tcp:mysqlserver2132.database.windows.net,1433;Initial Catalog=DogTrainingApp;Persist Security Info=False;User ID=azureuser;Password=Villanova2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DogOwner> DogOwners  { get; set; }
        public DbSet<DogTrainer> DogTrainers  { get; set; }
        public DbSet<Dog> Dogs  { get; set; }
        public DbSet<Owner> Owners  { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Trainer> Trainers  { get; set; }
        public DbSet<TrainingTrick> TrainingTricks  { get; set; }
        public DbSet<Training> Trainings  { get; set; }
        public DbSet<TrickCategory> TrickCategories  { get; set; }
        public DbSet<TrickIcon> TrickIcons  { get; set; }
        public DbSet<Trick> Tricks  { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
        

        public DogContext(DbContextOptions<DogContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connect);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<DogOwner>().ToTable("Dog Owner");
            modelBuilder.Entity<DogTrainer>().ToTable("Dog Trainer");
            modelBuilder.Entity<Dog>().ToTable("Dog");
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<Trainer>().ToTable("Trainer");
            modelBuilder.Entity<TrainingTrick>().ToTable("Training Trick");
            modelBuilder.Entity<Training>().ToTable("Training");
            modelBuilder.Entity<TrickCategory>().ToTable("Trick Category");
            modelBuilder.Entity<TrickIcon>().ToTable("Trick Icon");
            modelBuilder.Entity<Trick>().ToTable("Trick");
            modelBuilder.Entity<DogBreed>().ToTable("Dog Breeds");


        }
    }
}
