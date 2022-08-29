using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD.Common.Model.Automapper
{
    public static class AutoMapperConfiguration
    {
        #region Fields
        private static MapperConfiguration mapperConfiguration;
        private static IMapper mapper;
        #endregion

        #region Init
        public static void Init()
        {
            mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            if (mapperConfiguration == null)
            {
                throw new ArgumentNullException("No configurations");
            }

            mapper = mapperConfiguration.CreateMapper();
        }
        #endregion

        #region Properties
        public static IMapper Mapper => mapper;

        public static MapperConfiguration MapperConfiguration => mapperConfiguration;
        #endregion
    }
}
