using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TodoAspNetAPI.Dto.UserDtos;
using TodoAspNetAPI.Interfaces;
using TodoAspNetAPI.Mappers;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Controllers
{
    [Route("api/v1/User")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromServices] IUserInterface userInterface)
        {
            try
            {
                var users = await userInterface.GetUsers();
                return Ok(users.Select(x => x.ToUserDto()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter a lista dos utilizadores: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int Id, [FromServices] IUserInterface userInterface)
        {
            try
            {
                var user = await userInterface.GetUserById(Id);
                return (user != null) ? Ok(user.ToUserDto()) : NotFound("Não foi possível localizar o utilizador");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter os dados do utilizador: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto, [FromServices] IUserInterface userInterface)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    var userModel = new User
                    {
                        Email = createUserDto.Email,
                        UserName = createUserDto.UserName,
                        Password = createUserDto.Password
                    };
                    await userInterface.CreateUser(userModel);
                    return Ok(userModel.ToUserDto());
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o utilizador: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(
            [FromRoute] int Id,
            [FromServices] IUserInterface userInterface,
            [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                else
                {
                    var user = await userInterface.GetUserById(Id);
                    if (user == null)
                        return NotFound("Não foi possível localizar o utilizador");
                    else
                    {
                        var userModel = new User
                        {
                            Email = updateUserDto.Email,
                            UserName = updateUserDto.UserName,
                            Password = updateUserDto.Password,
                        };
                        var userResult = await userInterface.UpdateUser(user);
                        return Ok(userResult.ToUserDto());
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualiar o utilizador: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<string>> DeleteUser(
            [FromRoute] int Id,
            [FromServices] IUserInterface userInterface)
        {
            try
            {
                var user = await userInterface.GetUserById(Id);
                if (user == null)
                    return NotFound("Não foi possível localizar o utilizador");
                await userInterface.DeleteUser(user);
                return Ok("Utilizador removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao remover o utilizador: {ex.Message}");
            }
        }

    }
}