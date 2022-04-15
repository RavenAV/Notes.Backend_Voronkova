using System;
using System.Linq;
using System.Text;
using System.Reflection;
using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    // реализация конфигурации маппинга
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes() // сканирует сборку
                .Where(type => type.GetInterfaces() //и ищет любые типы, которые реализуют интерфейс IMapWith
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)  // затем вызывает метод маппинг от наследуемого типа или из интерфейса, если тип не реализует этот метод
            {
                var instance  = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}
