[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DP.Marvel.MVCGridConfig), "RegisterGrids")]

namespace DP.Marvel
{
    using global::Marvel.Api.Model.DomainObjects;
    using Infra.Config;
    using Models;
    using MVCGrid.Models;
    using MVCGrid.Web;
    using NHibernate;
    using NHibernate.Linq;
    using System;
    using System.Linq;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("CharacterGrid", new MVCGridBuilder<CharactersViewModel>()
             .WithAuthorizationType(AuthorizationType.AllowAnonymous)
             .AddColumns(cols =>
             {
                 cols.Add("Name").WithHeaderText("Nome")
                     .WithValueExpression(p => p.Name);
                 cols.Add("Description").WithHeaderText("Descrição")
                   .WithValueExpression(p => p.Description);
                 cols.Add("UpdatedAt").WithHeaderText("Última atualização")
                   .WithValueExpression(p => p.UpdatedAt);

                 cols.Add("Details").WithHtmlEncoding(false)
                  .WithSorting(false)
                  .WithHeaderText(" ")
                  .WithValueExpression((p, c) => c.UrlHelper.Action("Details", "Home", new { id = p.Id }))
                  .WithValueTemplate("<a href='{Value}' class='btn btn-primary' role='button'>Visualizar</a>");
             })
               .WithAdditionalQueryOptionNames("Search")
               .WithPaging(true, 10)
                 .WithRetrieveDataMethod((context) =>
                 {
                     var options = context.QueryOptions;
                     var result = new QueryResult<CharactersViewModel>();

                     ISession db = InMemorySessionFactoryProvider.Session;
                     var query = db.Query<Character>();
                     result.TotalRecords = query.Count();

                     string globalSearch = options.GetAdditionalQueryOptionString("Search");

                     if (!string.IsNullOrEmpty(globalSearch))
                     {
                         query = query.Where(x => x.Name.ToLower().Contains(globalSearch.ToLower()));
                     }

                     if (options.GetLimitOffset().HasValue)
                     {
                         var skip = Convert.ToInt32(options.GetLimitOffset().Value);
                         var take = Convert.ToInt32(options.GetLimitRowcount().Value);

                         query = query.Skip(skip).Take(take);
                     }

                     result.Items = query.ToList().Select(res =>
                               new CharactersViewModel
                               {
                                   Id = res.Id,
                                   Name = res.Name,
                                   Description = res.Description,
                                   UpdatedAt = DateTime.Parse(res.Modified).ToString("dd/MM/yyyy HH:mm:ss")
                 }).ToList();

                     return result;
                 })
             );
        }
    }
}