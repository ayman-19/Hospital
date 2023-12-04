using Infrastructure.CashedRepository;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CashController : ControllerBase
	{
		private readonly IAppointmentRepository casheRepository;

		public CashController(IAppointmentRepository casheRepository)
        {
			this.casheRepository = casheRepository;
		}
		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await casheRepository.GetAsync(c => c.Id == id));
		}
    }
}
