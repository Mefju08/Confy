namespace Confy.Infrastructure.DAL.Options
{
    internal sealed class DbOptions
    {
        public const string SectionName = "sqlserver";
        public string ConnectionString { get; set; }
    }
}
