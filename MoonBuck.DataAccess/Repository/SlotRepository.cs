using MoonBuck.DataAccess.Data;
using MoonBuck.DataAccess.Repository.IRepository;
using MoonBuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBuck.DataAccess.Repository
{
    public class SlotRepository : Repository<Slot>, ISlotRepository
    {
        private ApplicationDbContext _db;
        public SlotRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;        
        }

        public void Update(Slot obj)
        {
            _db.Slots.Update(obj);
        }
    }
}
