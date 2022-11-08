using Microsoft.EntityFrameworkCore;
using assignment.Models;

namespace assignment.Repository
{
    public class ImplementRepo<T> : IRepo<T> where T : class
    {
        public readonly ExpenseDbContext db;
        public readonly DbSet<T> table;
        public ImplementRepo(ExpenseDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public void UpdateData(T obj)
        {
            table.Update(obj);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            
            #pragma warning disable CS8603 // Possible null reference return.
            return table.Find(id);
            #pragma warning restore CS8603 // Possible null reference return.
            
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
