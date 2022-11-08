namespace assignment.Repository
{
    public interface IRepo<T> where T : class
    {

        List<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void UpdateData(T obj);
        void Delete(T obj);
        void Save();
    }
}
