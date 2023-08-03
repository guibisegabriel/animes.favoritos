namespace AnimesFavoritos.Interfaces;

public interface IRepository<T> where T : class
{
    void Create(T model); // Add 

    List<T> ReadAll(); // Get 

    T ReadById(int? id); // Get(id)

    void Update(T model); //Edit

    void Delete(int? id);
}