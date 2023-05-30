using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAO
{
    public interface CrudDao<T>
    {
        // T Save(T entity);
        // List<T> GetAll();
        // T GetById(int id);
        // T Update(T entity, int id);
        // void DeleteById(int id);

        Task<int> SaveAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> UpdateAsync(T entity, int id);
        Task<int> DeleteByIdAsync(int id);
    }
}
