using Chess.Application.DTOs;
using Chess.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Application.Mapper
{
    public class MapConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map
            config.NewConfig<Map, MapDTO>()
                //.PreserveReference(true)
                .MaxDepth(2)
                .ShallowCopyForSameType(true)
                //.Map(d => d.Name, s => s.Name)
                //.IgnoreNonMapped(true)
                //.Map(d => d, s => s)
                ;

            // Box
            config.NewConfig<Box, BoxDTO>()
                .ShallowCopyForSameType(true)
                //.PreserveReference(true)
                .MaxDepth(2)
                ;
        }
    }
}
