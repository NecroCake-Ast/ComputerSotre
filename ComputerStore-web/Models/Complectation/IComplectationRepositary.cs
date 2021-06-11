using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    public interface IComplectationRepositary
    {
        public Task<List<Complectation>> List();
        public Task<Complectation> FindByID(int id);
    }
}
