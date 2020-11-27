using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stefanini.Data.Extensions
{
    public static class AutoMapperExtensions
    {
        public static async Task<T> MapTo<T>(this object src, IMapper mapper)
        {
            if (src is null)
            {
                return await Task.FromResult((T)src);
            }

            return await Task.FromResult((T)mapper.Map(src, src.GetType(), typeof(T)));
        }


        public static IList<T> MapListTo<T>(this object src, IMapper mapper)
        {

            if (src is null)
            {
                return (IList<T>)src;
            }

            return (IList<T>)mapper.Map(src, src.GetType(), typeof(IList<T>));
        }
    }
}
