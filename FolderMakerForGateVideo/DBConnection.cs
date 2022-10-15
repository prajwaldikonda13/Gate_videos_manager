using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Forms;

namespace FolderMakerForGateVideo
{
    public class DBConnection:DbContext
    {
        public DbSet<RootFolder> rootFolders { get; set; }
        public DbSet<SubjectFolder> subjectFolders { get; set; }
        public DbSet<TopicFolder> topicFolders { get; set; }
        public DbSet<Video> videos { get; set; }
        public DBConnection() : base("Data Source=your_data_source;Initial Catalog=your_database;Integrated Security=true")
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBConnection, DataContextConfiguration>());
            }
            catch(Exception ex)
            {
                Clipboard.SetText(ex.Message);
            }
        }
    }
    internal sealed class DataContextConfiguration : DbMigrationsConfiguration<DBConnection>
    {
        public DataContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DataContext";
        }
    }
}
