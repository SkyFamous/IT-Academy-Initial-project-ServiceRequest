using BAL.Core;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public SRDBContext Context { get; set; }

        public UnitOfWork(SRDBContext context)
        {
            Context = context;
        }

        public void SaveChanges ()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}