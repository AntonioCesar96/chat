using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Chat.Infra.Util.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static T MapTo<T>(this object value)
        {
            if (value == null) return (T) value;
            return Mapper.Map<T>(value);
        }

        public static IEnumerable<T> EnumerableTo<T>(this object value)
        {
            return Mapper.Map<IEnumerable<T>>(value);
        }

        public static IQueryable<T> QueryableTo<T>(this object value)
        {
            return Mapper.Map<IQueryable<T>>(value);
        }
    }
}
