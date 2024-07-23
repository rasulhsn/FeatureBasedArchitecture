using System;
using System.Linq;
using System.Reflection;

using AutoMapper;

namespace TMOnline.Shared.Infrastructure.AutoMapper
{
    public static class AutoMapperFactory
    {
        /// <param name="assembly">Assembly.GetExecutingAssembly()</param>
        public static IMapper Create(Assembly assembly)
        {
            var profileType = typeof(Profile);
            var profiles = assembly.GetTypes()
                .Where(q => profileType.IsAssignableFrom(q)
                            && q.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            return new MapperConfiguration(conf =>
            {
                if (profiles != null)
                    foreach (var item in profiles)
                        conf.AddProfile(item);

            }).CreateMapper();
        }
    }
}
