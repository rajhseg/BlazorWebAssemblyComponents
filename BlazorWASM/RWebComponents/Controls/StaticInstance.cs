using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace RWebComponents.Controls;


public static class Extensions {
    public static void AddRComponentServices(this IServiceCollection collection){
        collection.AddTransient<IJsConsole, JsConsole>();
        collection.AddScoped<IRObjectCollection, RObjectCollection>();
    }
}

public interface IRObjectCollection {
    void AddInstance<T>(Type type, T ins) where T: IEntity, new ();

    List<IEntity> GetAllObjectsOfType(Type type);
}

public class RObjectCollection : IRObjectCollection
{    
    private Dictionary<Type, List<IEntity>> objects = new Dictionary<Type, List<IEntity>>();

    public RObjectCollection() {

    }

    public void AddInstance<T>(Type type, T ins) where T: IEntity, new ()
    {
        var obj = objects.GetValueOrDefault(type);

        if(obj==null){
            objects.Add(type, new List<IEntity>{ins});
        } else {            
            var exists = objects[type].Any(x=> ins._id == x._id);
            if(!exists)
                objects[type].Add(ins);
        }
    }

    public List<IEntity> GetAllObjectsOfType(Type type){
        return objects.GetValueOrDefault(type) ?? [];
    }
}

public interface IEntity {

    string? _id {get;}

}