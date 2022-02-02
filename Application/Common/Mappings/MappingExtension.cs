using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Application.Common.Mappings
{
    public static class MappingExtension
    {
        //public static Task<List<TDestination>> ListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        //   => List<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
