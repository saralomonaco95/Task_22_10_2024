namespace Task_22_10_2024.Repos
{
    public interface IRepoScrittura<T>
    {
        bool Create (T entity); 
        bool Update (T entity);     

        bool Delete (int id); 


    }
}
