using System.Data.Entity;
using NDSSSF.Dictionary.Infrastructure.Entities;

namespace NDSSSF.EFDictionaryRepository
{
    public class DictionaryDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<WordType> Types { get; set; }

        public DictionaryDbContext():base("DefaultConnection")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Word>().HasMany(w => w.WordTypes).WithMany(wt => wt.Words);
            modelBuilder.Entity<Word>().HasMany(w => w.Synonyms).WithMany().Map(w => w.ToTable("Synonyms").MapLeftKey("WordId").MapRightKey("SynonymId"));
        }
    }
}
