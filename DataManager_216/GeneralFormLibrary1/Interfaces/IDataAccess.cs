using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1
{
    public interface IDataAccess<T> where T: class
    {
        Task<T> Get(int Id, int CommandTimeout = 45);

        Task<List<T>> GetAll(int CommandTimeout = 45);

        Task<bool> Delete(T entity, int CommandTimeout = 45);

        Task<bool> Delete(List<T> entity, int CommandTimeout = 45);

        Task<int> Insert(T entity, int CommandTimeout = 45);

        Task<int> Insert(List<T> entity, int CommandTimeout = 45);

        Task<bool> Update(T entity, int CommandTimeout = 45);

        Task<bool> Update(List<T> entity, int CommandTimeout = 45);
    }
}
