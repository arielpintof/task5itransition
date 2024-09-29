namespace task5itransition.Data;

public interface IDataGenerator<T>
{
    Task<IEnumerable<T>> Generate(int count,  int seed, double error);
}