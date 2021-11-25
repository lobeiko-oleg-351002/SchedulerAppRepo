﻿using AppConfiguration;
using BLL.Caching;
using BLL.Caching.Base;
using SchedulerApp.Caching;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Caching
{
    public class CacheTypeResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppSettings _appSettings;

        public CacheTypeResolver(IServiceProvider serviceProvider, AppSettings appSettings)
        {
            _serviceProvider = serviceProvider;
            _appSettings = appSettings;
        }

        public ICacheService<StudentViewModel> Resolve()
        {
            string cacheType = _appSettings.CacheType;

            if (cacheType == "InMemory")
            {
                return (ICacheService<StudentViewModel>)_serviceProvider.GetService(typeof(MemoryCacheService<StudentViewModel>));
            }
            if (cacheType == "Distributed")
            {
                return (ICacheService<StudentViewModel>)_serviceProvider.GetService(typeof(RedisCacheService<StudentViewModel>));
            }
            throw new Exception("Invalid Cache type");
        }
    }
}
