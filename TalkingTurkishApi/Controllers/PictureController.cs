using Microsoft.AspNetCore.Mvc;

namespace TalkingTurkishApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Picture")]
    public class PictureController : Controller
    {
        [HttpGet]
        public void GetPicture(int pictureId)
        {

        }

    }
}