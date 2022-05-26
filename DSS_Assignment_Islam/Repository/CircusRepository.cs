using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Islam.Repository
{
    public class CircusRepository : ICircus
    {
        private readonly DBContext db;
        
        public CircusRepository (DBContext _db) { db = _db; }
        public IEnumerable<Circus> GetCircuses => db.Circuses;

        public void Add(Circus _Circus)
        {
           db.Circuses.Add(_Circus);
            db.SaveChanges();
        }

        public Circus GetCircus(int ID)
        {
            Circus dbEntity = db.Circuses.Include(c => c.Actors).SingleOrDefault(x => x.CircusID == ID);
            return dbEntity;
        }

        public void Remove(int ID)
        {
            Circus dbEntity = db.Circuses.Find(ID);
            db.Circuses.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
