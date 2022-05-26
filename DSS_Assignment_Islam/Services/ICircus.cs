using DSS_Assignment_Islam.Models;

namespace DSS_Assignment_Islam.Services
{
        public interface ICircus
        {

            IEnumerable<Circus> GetCircuses { get; }
            Circus GetCircus(int ID);
            void Add(Circus _Circus);
            void Remove(int ID);
        }
    
}
