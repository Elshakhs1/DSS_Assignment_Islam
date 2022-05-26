using DSS_Assignment_Islam.Models;

namespace DSS_Assignment_Islam.Services
{
    public interface IActor
    {

        IEnumerable<Actor> GetActors { get; }
        Actor GetActor(int ID);
        void Add(Actor _Actor);
        void Remove(int ID);
    }
}
