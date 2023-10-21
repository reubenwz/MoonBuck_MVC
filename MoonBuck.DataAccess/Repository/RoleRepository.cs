﻿using MoonBuck.DataAccess.Data;
using MoonBuck.DataAccess.Repository.IRepository;
using MoonBuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonBuck.DataAccess.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;        
        }

        public void Update(Role obj)
        {
            _db.Roles.Update(obj);
        }
    }
}
