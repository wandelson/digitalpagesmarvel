using FluentNHibernate.Mapping;
using Marvel.Api.Model.DomainObjects;

namespace DP.Marvel.CaractereMap
{
    public class CharacterMap : ClassMap<Character>
    {
        public CharacterMap()
        {
            Not.LazyLoad();

            Id(x => x.Id).GeneratedBy.Assigned(); 
            Map(x => x.Modified);
            Map(x => x.Name);
            Map(x => x.Description);
        }
    }
}