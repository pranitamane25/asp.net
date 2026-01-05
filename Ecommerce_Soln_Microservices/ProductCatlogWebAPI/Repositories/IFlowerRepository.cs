using ProductWebAPI.Entities;

namespace ProductWebAPI.Repositories
{
    public interface IFlowerRepository
    {
        List<Flower> GetAll();
        Flower? GetById(int id);
        void Add(Flower flower);
        bool Update(int id, Flower flower);
        bool Delete(int id);
    }
}
