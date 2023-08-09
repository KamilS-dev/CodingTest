using DigilizeCodingTest.Data.Models;
using System.Reflection;

namespace DigilizeCodingTest.Data.Validators;

public static class EntityValidator
{
    public static IEnumerable<T> ValidateAndFilter<T>(this IQueryable<T> entities) where T : EntityBase
    {
        foreach(var entity in entities)
        {
            if (entity.IsValidEntity())
            {
                yield return entity;
            }
        }
    }

    private static bool IsValidEntity<T>(this T entity) where T : EntityBase
    {
        if (entity.Id == Guid.Empty)
        {
            return false;
        }

        PropertyInfo[] properties = typeof(T).GetProperties();

        foreach (var property in properties) 
        {
            if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
            {
                var value = property.GetValue(entity);
                if (value == null || (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(value.ToString())))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
