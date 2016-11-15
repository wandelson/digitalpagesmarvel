using DP.Marvel.Infra.Config;
using DP.Marvel.Infra.Data.Repository;
using DP.Marvel.Models;
using Marvel.Api;
using Marvel.Api.Model.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DP.Marvel.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            Repository<Character> repo = new Repository<Character>(InMemorySessionFactoryProvider.Session);

            var client = new MarvelRestClient(viewModel.PublicKey, viewModel.PrivateKey);

            Session["PublicKey"] = viewModel.PublicKey;
            Session["PrivateKey"] = viewModel.PrivateKey;

            var list = new List<Character>();

            var exist = repo.GetAll();

            if (exist.Count() == 0)
            {
                var response = client.GetCharacters(1);

                var total = Convert.ToInt32(response.Data.Total);

                Parallel.ForEach(Enumerable.Range(0, total)
                    .Where(i => i % 100 == 0),
                     new ParallelOptions { MaxDegreeOfParallelism = 10 },
                     i =>
                {
                    var result = client.GetCharacters(i);
                    list.AddRange(result.Data.Results);
                });

                for (int i = 0; i < total; i = i + 100)
                {
                    repo.Save(list);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}