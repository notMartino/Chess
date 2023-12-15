using Chess.Application.DTOs;
using Chess.Domain.Entities;
using Mapster;

namespace Chess.Application.Mapper
{
    public class MapConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Map
            config.NewConfig<Map, MapDTO>()
                .Map(d => d.Id, s => BCrypt.Net.BCrypt.HashString(s.Id.ToString(), BCrypt.Net.SaltRevision.Revision2B))
                //.PreserveReference(true)
                .MaxDepth(4)
                .ShallowCopyForSameType(true)
                //.Map(d => d.Name, s => s.Name)
                .IgnoreNonMapped(true)
                //.Map(d => d.Boxes, s => s.Boxes)
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
