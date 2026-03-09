using Microsoft.AspNetCore.Mvc;
using minhaApi.Interface.Service;
using minhaApi.Dtos;

namespace minhaApi.Controller
{

    [ApiController]
    [Route("api/[Controller]")]

    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            this._urlService = urlService;
        }


        [HttpPost("shortUrl")]

        public async Task<IActionResult> ShortUrlAsync([FromBody] RequestUrlDto dto)
        {

            if (string.IsNullOrEmpty(dto.OriginalUrl))
            {
                return BadRequest(new { mensagem = "Url invalid" });
            }

            var result = await _urlService.ShortUrlAsync(dto);

            var code = result.ShortCode;

            var scheme = Request.Scheme;
            var host = Request.Host;

            var shortUrl = $"{scheme}://{host}/{code}";

            return Ok(new ResponseUrlDto
            {
                ShortCode = shortUrl,
                CreatedAt = DateTime.UtcNow
            });
        }

        [HttpGet("/{code}")]

        public async Task<IActionResult> RedirectUrlAsync([FromRoute] string code)
        {

            var originalUrl = await _urlService.GetOriginalUrlByCodeAsync(code);

            if (originalUrl == null)
            {
                return NotFound(new { mensagem = "Link not found " });
            }

            return Redirect(originalUrl);
        }
    }
}
