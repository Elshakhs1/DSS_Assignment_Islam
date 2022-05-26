using DSS_Assignment_Islam.Models;

namespace DSS_Assignment_Islam.Services
{
    public interface ITrick
    {

        IEnumerable<Trick> GetTricks { get; }
        Trick GetTrick(int ID);
        void Add(Trick _Trick);
        void Remove(int ID);
    }
}
