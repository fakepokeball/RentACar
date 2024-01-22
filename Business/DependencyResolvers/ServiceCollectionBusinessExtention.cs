using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtention
{
    //Extention Method
    //Method'un ve barındığı class'ın static olması gerekiyor.
    //ilk parametre genişleteceğimiz tip olmalı ve başında this keyword'u olmalı.
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IModelDal, InMemoryModelDal>()
            .AddSingleton<IModelService, ModelManager>()
            .AddSingleton<ModelBusinessRules>();
        services
            .AddSingleton<ITransmissionDal, InMemoryTransmissionDal>()
            .AddSingleton<ITransmissionService, TransmissionManager>()
            .AddSingleton<TransmissionBusinessRules>();
        services
            .AddSingleton<IFuelDal, InMemoryFuelDal>()
            .AddSingleton<IFuelService, FuelManager>()
            .AddSingleton<FuelBusinessRules>();
        services
            .AddSingleton<IBrandDal, InMemoryBrandDal>()
            .AddSingleton<IBrandService, BrandManager>()
            .AddSingleton<BrandBusinessRules>(); // Fluent
        

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper.Extentions.Microsoft.DependencyInjection NuGet
        // Reflection yöntemiyle Profile class'ını kalıtım alan tüm class'ları bulur ve Automapper'a ekler.

        return services;
    }
}
