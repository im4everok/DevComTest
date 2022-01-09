using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        IQueryable<TModel> GetAll();
        Task<TModel> GetByIdAsync(int id);
        Task UpdateAsync(TModel model);
        Task DeleteByIdAsync(int modelId);
    }
}
