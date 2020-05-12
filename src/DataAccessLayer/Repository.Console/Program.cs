using System.Linq;
using Repository.Contexts;
using Repository.Contract.Repositories;
using Repository.Repositories;

namespace Repository.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DocManagerDbContext())
            {
                IStatusRepository statusRepository = new StatusRepository(db);
                statusRepository.Delete(
                    statusRepository.Get(e => e.Id == 4).First()
                );

                db.SaveChanges();
            }
        }
    }
}