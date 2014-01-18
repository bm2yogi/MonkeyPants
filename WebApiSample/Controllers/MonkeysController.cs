using System.Web.Http;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    public class MonkeysController : ApiController
    {
        public Monkey Get(int id=0)
        {
            return MonkeyFactory.Create();
        }

    }
}
