using Microsoft.AspNetCore.Mvc;
using TodoAspNetAPI.Dto.StepDtos;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Mappers;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Controllers
{
    [Route("api/v1/step")]
    [ApiController]
    public class StepController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<StepDto>>> GetSteps([FromServices] IStepInterface stepInterface)
        {
            try
            {
                var steps = await stepInterface.GetSteps();
                return Ok(steps.Select(x => x.ToStepDto()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível obter a lista de passos: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<StepDto>> GetStepById(
            [FromRoute] int Id,
            [FromServices] IStepInterface stepInterface)
        {
            try
            {
                var step = await stepInterface.GetStepById(Id);
                if (step == null)
                    return NotFound("Passo não localizado!");
                return Ok(step.ToStepDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível localizar o passo: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<IEnumerable<StepDto>>> CreateStep(
            [FromBody] CreateStepDto createStepDto,
            [FromServices] IStepInterface stepInterface, ITargetInteface targetInteface)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var target = await targetInteface.GetTargetById(createStepDto.IdTarget);
                if (target == null)
                    return NotFound("Tarefa não localizada");
                var stepModel = new Step
                {
                    Description = createStepDto.Description,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    Target = target
                };
                var stepResult = await stepInterface.CreateStep(stepModel);
                return Ok(stepResult.ToStepDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível criar o passo: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<IEnumerable<StepDto>>> UpdateStep(
            [FromRoute] int Id,
            [FromBody] UpdateStepDto updateStepDto,
            [FromServices] IStepInterface stepInterface)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var step = await stepInterface.GetStepById(Id);
                if (step == null)
                    return NotFound("Passo não localizada");
                step.Description = updateStepDto.Description;
                var stepResult = await stepInterface.UpdateStep(step);
                return Ok(stepResult.ToStepDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível atualizar o passo: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<IEnumerable<StepDto>>> DeleteStep(
            [FromRoute] int Id,
            [FromServices] IStepInterface stepInterface)
        {
            try
            {
                var step = await stepInterface.GetStepById(Id);
                if (step == null)
                    return NotFound("Passo não localizada");
                await stepInterface.DeleteStep(step);
                return Ok("Passo excluido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível Excluir o passo: {ex.Message}");
            }
        }
    }
}