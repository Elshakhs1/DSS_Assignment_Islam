using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Islam.Repository
{
    public class ActorRepository : IActor
    {
        private DBContext db;
        public ActorRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Actor> GetActors => db.Actors.Include(x => x.Circus);

        public void Add(Actor _Actor)
        {

            db.Actors.Add(_Actor);
            db.SaveChanges();
        }

        public Actor GetActor(int ID)
        {
            Actor dbEntity = db.Actors
               .Include(a => a.Circus)
               .Include(t => t.Acts)
               .ThenInclude(g => g.Trick)
               .SingleOrDefault(s => s.ActorID == ID);

            return dbEntity;
        }

        public void Remove(int ID)
        {
            Actor dbEntity = db.Actors.Find(ID);
            db.Actors.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
