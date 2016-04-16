using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class HotelRepository : IDisposable, IHotelRepository
    {
        private HotelDbContext ctx;

        public HotelRepository(HotelDbContext ctx)
        {
            this.ctx = ctx;
            // ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            if (!ctx.Hotels.Any()) {

                ctx.Hotels.Add(new Hotel {
                    Bezeichnung = "Hotel zur Post",
                    RegionId = 3,
                    Sterne = 2,
                    Buchungen = new List<Buchung> {
                        new Buchung {
                            Vorname = "Max",
                            Nachname = "Muster"
                        },
                        new Buchung {
                            Vorname = "Susi",
                            Nachname = "Sorglos"
                        }
                    }
                });

                SimpleRetryHelper.Exec(() => {
                    ctx.SaveChanges();
                });

            }
        }

        public List<Hotel> GetAll() {
            return SimpleRetryHelper.Exec(() => {
                return ctx.Hotels.ToList();
            });
        }

        public Hotel GetById(int id) {
            return SimpleRetryHelper.Exec(() => {
                return ctx.Hotels.Include(h => h.Buchungen).FirstOrDefault(h => h.HotelId == id);
            });
        }

        public List<Hotel> GetBySterne(int minSterne) {
            return SimpleRetryHelper.Exec(() => {
                return ctx.Hotels.Where(h => h.Sterne >= minSterne).ToList();
            });
        }

        public void Create(Hotel h) {
            SimpleRetryHelper.Exec(() => {
                ctx.Add(h);
                ctx.SaveChanges();
            });
        }

        public void Update(Hotel h) {

			// ctx.Attach(h);
            // ctx.Entry(h).State = EntityState.Modified;
            // ctx.Hotels.Update(h);
            ctx.ChangeTracker.TrackGraph(h, (state) => {
                var entity = state.Entry.Entity;
                state.Entry.State = EntityState.Modified;
            });

            SimpleRetryHelper.Exec(() => {
                ctx.SaveChanges();
            });
        }

        public void Dispose()
        {
            this.ctx.Dispose();
        }
    }
}
