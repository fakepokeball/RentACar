using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Business.Responses.Model;
using Business.Requests.Model;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpGet]
    public GetModelListResponse GetList([FromQuery] GetModelListRequest request)
    {
        GetModelListResponse response = _modelService.GetList(request);
        return response;
    }

    [HttpPost]
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        try
        {
            AddModelResponse response = _modelService.Add(request);

            return CreatedAtAction(nameof(GetList), response);
        }
        catch (Core.CrossCuttingConcerns.Exeptions.BusinessException exception)
        {
            return BadRequest(
                new Core.CrossCuttingConcerns.Exeptions.BusinessProblemDetails()
                {
                    Title = "Business Exception",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message,
                    Instance = HttpContext.Request.Path
                }
            );
        }
    }
}
