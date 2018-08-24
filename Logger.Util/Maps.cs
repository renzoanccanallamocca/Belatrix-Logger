using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO = Logger.Model;
using DOE = Logger.Entity;

namespace Logger.Util
{
    public static class Maps
    {
        public static void register()
        {
            AutoMapper.Mapper.Initialize(map =>
            {
                map.CreateMap<DTO.JobLoggerModel, DOE.JobLogger>();
                map.CreateMap<DOE.JobLogger, DTO.JobLoggerModel>();
            });
        }
    }
}
