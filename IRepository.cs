using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NDSSSF.DataRepository.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(int id, Expression<Func<T, Object>> predicate, bool recursiveLoad = false);

        //This "Expression" takes a delegate which returns a boolen and that delegate take tyoe T
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);
        Task<int> Delete(T entity);
        Task<int> Delete(int id);
       
    }
}