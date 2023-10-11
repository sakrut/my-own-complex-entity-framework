using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using OwnComplex.Domain.ValueObjects;

namespace OwnComplex.EF8.OwnModel;

public static class EntityFrameworkCommonBuilders
{
    public static void BuildNamedProperty<TEntity, TProperty>(OwnedNavigationBuilder<TEntity, TProperty> builder)
        where TProperty : NamedProperty
        where TEntity : class
    {
        builder.Property(np => np.Id);
        builder.Property(np => np.Name).HasMaxLength(100)
            .IsRequired(false);
    }

    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class, new()
    {
        ValueConverter<T, string> converter = new(
            v => JsonConvert.SerializeObject(v) ?? string.Empty,
            v => string.IsNullOrEmpty(v) ? new T() : JsonConvert.DeserializeObject<T>(v) ?? new T()
        );

        ValueComparer<T> comparer = new(
            (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
            v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
            v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v)) ?? new T()
        );

        propertyBuilder.HasConversion(converter);
        propertyBuilder.Metadata.SetValueConverter(converter);
        propertyBuilder.Metadata.SetValueComparer(comparer);
        propertyBuilder.IsRequired(false);

        return propertyBuilder;
    }

    public static ComplexTypePropertyBuilder<T> HasJsonConversion<T>(this ComplexTypePropertyBuilder<T> propertyBuilder) where T : class, new()
    {
        ValueConverter<T, string> converter = new(
            v => JsonConvert.SerializeObject(v) ?? string.Empty,
            v => string.IsNullOrEmpty(v) ? new T() : JsonConvert.DeserializeObject<T>(v) ?? new T()
        );

        ValueComparer<T> comparer = new(
            (l, r) => JsonConvert.SerializeObject(l) == JsonConvert.SerializeObject(r),
            v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
            v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v)) ?? new T()
        );

        propertyBuilder.HasConversion(converter);
        propertyBuilder.Metadata.SetValueConverter(converter);
        propertyBuilder.Metadata.SetValueComparer(comparer);
        propertyBuilder.IsRequired(false);

        return propertyBuilder;
    }
}
