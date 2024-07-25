using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    //to allow any class to be injected in this class
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);


        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);


        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);

        //save all not  included because it can vary 

    }
}
