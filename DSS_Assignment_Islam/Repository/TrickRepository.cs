using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Services;
using Microsoft.EntityFrameworkCore;

namespace DSS_Assignment_Islam.Repository
{
    public class TrickRepository : ITrick
    {
        private DBContext db;
        public TrickRepository(DBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Trick> GetTricks => db.Tricks;


        public void Add(Trick _Trick)
        {

            db.Tricks.Add(_Trick);
            db.SaveChanges();
        }
    

        public Trick GetTrick(int ID)
        {
            Trick dbEntity = db.Tricks.Include(t => t.Acts)
               .ThenInclude(g => g.Actor)
               .SingleOrDefault(s => s.TrickID == ID); ;
            return dbEntity;
        }

        public void Remove(int ID)
        {

           Trick dbEntity = db.Tricks.Find(ID);
            db.Tricks.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}

