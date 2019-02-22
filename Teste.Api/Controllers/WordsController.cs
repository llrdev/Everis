using Microsoft.AspNetCore.Mvc;
using System;
using Teste.Business.Dto;
using Teste.Business.Contract;
using Teste.Helper;

namespace Teste.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        protected IWords iWords;

        public WordsController(IWords iWords)
        {
            this.iWords = iWords;
        }

        [Route("wordinword")]
        [HttpPost]
        public IActionResult SearchWordInWord([FromBody] WordDTO words)
        {

            try
            {

                if (!ModelState.IsValid)
                {
                    var errors = ErrorHandle.GetModelStateErrors(ModelState);
                    return BadRequest(errors);
                }
                else
                {
                    var result = iWords.TransformWord(words);

                    if ((int)result.status.Code == 1)
                    {
                        return Ok(result.Response);
                    }
                    else
                    {
                        return StatusCode(ErrorHandle.StatusCodeApi(result.status.Code), result.status.Description);
                    }
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}