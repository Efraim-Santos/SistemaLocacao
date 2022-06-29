using Microsoft.AspNetCore.Mvc;
using SistemaLocacao.API.Model;

namespace SistemaLocacao.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult<TviewModel> ExecutarGetAsync<TviewModel>(TviewModel viewModel) where TviewModel : class
        {
            if (viewModel == null)
                return NotFound();

            return viewModel;
        }
        public ActionResult<ResponseModel<TviewModel>> ExecutarRequestAsync<TviewModel>(ResponseModel<TviewModel> response) where TviewModel : class
        {
            if (response.Resultado == null)
                return BadRequest(response.Messagens);

            return response;
        }
    }
}
