namespace Task_22_10_2024.Repos
{
    public interface IRepoLettura<T>
    {
        IEnumerable<T> GetAll();

        T? get(int id); 

    }
}
