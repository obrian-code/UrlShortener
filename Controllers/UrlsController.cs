using Microsoft.AspNetCore.Mvc;


namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlsController : ControllerBase
    {
        private static readonly Dictionary<string, UrlMapping> UrlMappings = new();
        private const string BaseUrl = "https://localhost:5184/api/urls/";

        [HttpPost]
        public ActionResult<string> ShortenUrl([FromBody] string originalUrl)
        {

            var id = GenerateId();
            var urlMapping = new UrlMapping { Id = id, OriginalUrl = originalUrl };
            UrlMappings[id] = urlMapping;
            return Ok($"{BaseUrl}{id}");
        }

        [HttpGet("{id}")]
        public ActionResult RedirectToOriginalUrl(string id)
        {
            if (UrlMappings.TryGetValue(id, out var mapping))
            {
                if (!string.IsNullOrEmpty(mapping.OriginalUrl))
                {
                    return Redirect(mapping.OriginalUrl);
                }
            }
            return NotFound();
        }


        private string GenerateId()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
