using Microsoft.AspNetCore.Mvc;
using TodoAspNetAPI.Dto.TargetDtos;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Mappers;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Controllers
{
    [Route("api/v1/Target")]
    [ApiController]
    public class TargetController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TargetDto>>> GetTarget([FromServices] ITargetInteface targetInteface)
        {
            try
            {
                var targets = await targetInteface.GetTargets();
                return Ok(targets.Select(x => x.ToTargetDto()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível obter a lista de tarefas: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<IEnumerable<TargetDto>>> GetTargetById(
            [FromRoute] int Id,
            [FromServices] ITargetInteface targetInteface)
        {
            try
            {
                var target = await targetInteface.GetTargetById(Id);
                if (target == null)
                    return NotFound("Não foi possível localizar a tarefa");
                return Ok(target.ToTargetDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível localizar a tarefa: {ex.Message}");
            }

        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<IEnumerable<TargetDto>>> CreateTarget(
            [FromBody] CreateTargetDto createTargetDto,
            [FromServices] ITargetInteface targetInteface, IUserInterface userInterface)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = await userInterface.GetUserById(createTargetDto.IdUser);
                if (user == null)
                    return NotFound("Utilizador não localizado");
                var targetModel = new Target
                {
                    Title = createTargetDto.Title,
                    Description = createTargetDto.Description,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    User = user
                };
                var targetResult = await targetInteface.CreateTarget(targetModel);
                return Created("target", targetResult.ToTargetDto());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível criar a tarefa: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<IEnumerable<TargetDto>>> UpdateTarget(
            [FromRoute] int Id,
            [FromBody] UpdateTargetDto updateTargetDto,
            [FromServices] ITargetInteface targetInteface)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    var target = await targetInteface.GetTargetById(Id);
                    if (target == null)
                        return NotFound("Não foi possível localizar a tarefa");
                    target.Title = updateTargetDto.Title;
                    target.Description = updateTargetDto.Description;
                    target.UpdatedOn = DateTime.Now;

                    var targetResult = await targetInteface.UpdateTarget(target);
                    return Ok(targetResult.ToTargetDto());
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível atualizar a tarefa: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<IEnumerable<TargetDto>>> RemoveTarget(
                   [FromRoute] int Id,
                   [FromServices] ITargetInteface targetInteface)
        {
            try
            {
                var target = await targetInteface.GetTargetById(Id);
                if (target == null)
                    return NotFound("Não foi possível localizar a tarefa");
                await targetInteface.DeleteTarget(target);
                return Ok("Tarefa excluida com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível excluir a tarefa: {ex.Message}");
            }
        }
    }
}