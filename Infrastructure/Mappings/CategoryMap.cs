using Domain.Categories;
using NHibernate.Mapping.ByCode.Conformist;


namespace Infrastructure.Mappings
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x  => x.Id);
            Property(x => x.Name);
        }
    }
}
