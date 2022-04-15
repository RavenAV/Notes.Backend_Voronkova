using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    //интерфейс с реализацией по умолчанию
    public interface IMapWith<T>
    {
        // создает конфигурация из исходного типа Т и назначение
        void Mapping(Profile profile)=>
            profile.CreateMap(typeof(T), GetType());
    }
}
