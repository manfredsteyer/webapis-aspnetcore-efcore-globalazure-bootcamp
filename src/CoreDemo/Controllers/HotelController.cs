using Demo.Data;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    public class HotelController: Controller
    {
        private IHotelRepository repo;

        public HotelController(IHotelRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public List<Hotel> GetAll() {
            return repo.GetAll();
        }

        // api/[controller]/{id}
        [HttpGet("{id}")]
        public Hotel GetById(int id) {
            return repo.GetById(id);
        }

        [HttpGet("bySterne/{id}")]
        public List<Hotel> GetBySterne(int minSterne)
        {
            return repo.GetBySterne(minSterne);
        }

        [HttpPost]
        public Hotel Create(Hotel hotel) {
            repo.Create(hotel);
            return hotel;
        }

        [HttpPut("{id?}")]
        public Hotel Save([FromBody]Hotel hotel, int id=0) {
            if (id != 0) hotel.HotelId = id;
            repo.Update(hotel);
            
            return hotel;

        }
    }
}
