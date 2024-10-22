namespace Task_22_10_2024.Services
{
    public interface IServiceScrittura<T>
    {
        bool Inserisci(T entity);
        bool Aggiorna (T entity);   
        bool Elimina(string Codice);    


    }
}
