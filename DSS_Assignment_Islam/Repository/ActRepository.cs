using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Islam.Repository
{
    public class ActRepository : IAct
    {
        private DBContext db;
        public ActRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Act> GetActs => db.Acts.Include(x => x.Trick).Include(y => y.Actor);

        public void Add(Act _Act)
        {
            db.Acts.Add(_Act);
            db.SaveChanges();
        }
        public Act GetAct(int ID)
        {
            return db.Acts.Include(c => c.Actor)
                   .Include(d => d.Trick)
                   .SingleOrDefault(e => e.ActID == ID);
        }
        public void Remove(int ID)
        {
            Act model = db.Acts.Find(ID);
            db.Acts.Remove(model);
            db.SaveChanges();
        }
    }
}

