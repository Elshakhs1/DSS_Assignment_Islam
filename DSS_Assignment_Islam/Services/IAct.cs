using DSS_Assignment_Islam.Models;

namespace DSS_Assignment_Islam.Services
{
    public interface IAct
    {

        IEnumerable<Act> GetActs { get; }
        Act GetAct(int ID);
        void Add(Act _Act);
        void Remove(int ID);
    }
}
