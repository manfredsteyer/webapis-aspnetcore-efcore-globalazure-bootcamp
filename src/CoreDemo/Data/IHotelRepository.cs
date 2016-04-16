using System.Collections.Generic;

namespace Demo.Data
{
    public interface IHotelRepository
    {
        void Create(Hotel h);
        void Dispose();
        List<Hotel> GetAll();
        Hotel GetById(int id);
        List<Hotel> GetBySterne(int minSterne);
        void Update(Hotel h);
    }
}