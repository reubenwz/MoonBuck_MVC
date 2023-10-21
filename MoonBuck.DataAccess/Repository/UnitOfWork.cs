﻿using MoonBuck.DataAccess.Data;
using MoonBuck.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBuck.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IRoleRepository Role { get; private set; }
        public ISlotRepository Slot { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Role= new RoleRepository(_db);
            Slot = new SlotRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
