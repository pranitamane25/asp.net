using ProductWebAPI.Entities;
using ProductWebAPI.Repositories;

namespace ProductWebAPI.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IFlowerRepository _repository;

        public FlowerService(IFlowerRepository repository)
        {
            _repository = repository;
        }

        public List<Flower> GetAllFlowers()
        {
            return _repository.GetAll();
        }

        public Flower? GetFlowerById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddFlower(Flower flower)
        {
            _repository.Add(flower);
        }

        public bool UpdateFlower(int id, Flower flower)
        {
            return _repository.Update(id, flower);
        }

        public bool DeleteFlower(int id)
        {
            return _repository.Delete(id);
        }
    }
}
