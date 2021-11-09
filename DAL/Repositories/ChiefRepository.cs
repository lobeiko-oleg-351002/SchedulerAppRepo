﻿using DAL.Exceptions;
using DAL.Repositories.Interface;
using SchedulerMigrations.Data;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ChiefRepository : Repository<Chief>, IChiefRepository
    {
        public ChiefRepository(SchedulerDbContext context) : base(context)
        {
            
        }

        public List<Chief> GetByProfile(string tag)
        {
            var elements = Context.Set<Chief>().Where(e => e.Profile.Contains(tag));
            if (elements.Any())
            {
                return elements.ToList();
            }
            else throw new NoElementsException();
        }

        public override Chief Create(Chief entity)
        {
            entity.Role = Context.Roles.FirstOrDefault(role => role.Id == entity.Role.Id);
            var result = Context.Set<Chief>().Add(entity).Entity;
            Context.SaveChanges();
            return result;
        }
    }
}
