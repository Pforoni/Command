using System.Collections.Generic;

namespace Commander.Data
{
    public interface IRepository<T> where T: class
    {
        bool SaveChanges();
        IEnumerable <T> GetAll();  
        T Get(long id);  
        void Insert(T entity);  
        void Update(T entity);  
        void Delete(T entity); 
    }
}
