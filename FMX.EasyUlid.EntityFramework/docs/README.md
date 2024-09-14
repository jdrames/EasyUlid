# EasyUlid.EntityFramework
This library contains the helper methods to
generate and convert `FMX.EasyUlid` values for use in Entity Framework Core.

Example Value Generator:
```csharp
...
[EasyUlid]
public partial record class ItemId{}
...


public class ItemEntityConfig : IEntityTypeConfiguration<Gallery>
{
	public void Configure(EntityTypeBuilder<Item> builder)
	{
                ...
		builder.Property(x => x.Id).HasValueGenerator<EasyUlidValueGenerator<ItemId>>();
		...
	}
}
...
```
Example Value Converter:
```csharp
...
[EasyUlid]
public partial record class ItemId{}
...


protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
{
     configurationBuilder.Properties<ItemId>().HaveConversion<EasyUlidValueConverter<ItemId>>();
}
```