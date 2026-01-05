using ProductWebAPI.Entities;
using ProductWebAPI.Helpers;

namespace ProductWebAPI.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly string _filePath = "Data/flowers.json";

        public List<Flower> GetAll()
        {
            return JsonFileHelper.ReadFromJson<Flower>(_filePath);
        }

        public Flower? GetById(int id)
        {
            return GetAll().FirstOrDefault(f => f.Id == id);
        }

        public void Add(Flower flower)
        {
            var flowers = GetAll();
            flower.Id = flowers.Any() ? flowers.Max(f => f.Id) + 1 : 1;
            flowers.Add(flower);
            JsonFileHelper.WriteToJson(_filePath, flowers);
        }

        public bool Update(int id, Flower updatedFlower)
        {
            var flowers = GetAll();
            var flower = flowers.FirstOrDefault(f => f.Id == id);
            if (flower == null) return false;

            flower.Name = updatedFlower.Name;
            flower.Color = updatedFlower.Color;
            flower.Price = updatedFlower.Price;
            flower.Stock = updatedFlower.Stock;

            JsonFileHelper.WriteToJson(_filePath, flowers);
            return true;
        }

        public bool Delete(int id)
        {
            var flowers = GetAll();
            var flower = flowers.FirstOrDefault(f => f.Id == id);
            if (flower == null) return false;

            flowers.Remove(flower);
            JsonFileHelper.WriteToJson(_filePath, flowers);
            return true;
        }
    }
}
