using ProductWebAPI.Entities;

namespace ProductWebAPI.Services
{
    public interface IFlowerService
    {
        List<Flower> GetAllFlowers();
        Flower? GetFlowerById(int id);
        void AddFlower(Flower flower);
        bool UpdateFlower(int id, Flower flower);
        bool DeleteFlower(int id);
    }
}
