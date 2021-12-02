using System;
using System.Threading.Tasks;
using WebApi.Core.Entities;

namespace WebApi.Core.Repositories
{
    public interface IPlatilloRepository : IRepository<Platillo>
    {
        //Task<IEnumerable<Platillo>> GetAll();
        Task<Platillo> GetById(Guid id);
        Task<int> Insert(Platillo reg);
        Task<int> Update(Platillo reg);
        Task<int> Delete(Guid id);
        //Task Delete(Platillo reg);
    }
}
