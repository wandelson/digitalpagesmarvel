using DP.Marvel.Infra.Config;
using DP.Marvel.Infra.Data.Repository;
using Marvel.Api;
using Marvel.Api.Model.DomainObjects;
using System.Web.Mvc;

namespace DP.Marvel.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Repository<Character> repo = new Repository<Character>(InMemorySessionFactoryProvider.Session);
            var model = repo.Get<Character>(id);

            string publicKey = Session["PublicKey"].ToString();
            string privateKey = Session["PrivateKey"].ToString();
            var client = new MarvelRestClient(publicKey, privateKey);

            ViewBag.Comics = client.GetCharacterComics(id.ToString()).Data.Results;

            return View(model);
        }
    }
}