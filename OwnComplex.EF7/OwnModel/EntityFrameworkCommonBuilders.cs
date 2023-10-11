using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnComplex.Domain.ValueObjects;

namespace OwnComplex.EF7.OwnModel;

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
}
