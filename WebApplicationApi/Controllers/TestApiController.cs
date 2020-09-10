using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using WebApplicationApi.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly IActions _iActions;
        private readonly ILogger<TestApiController> _logger;

        public TestApiController(
            ILogger<TestApiController> logger,
            IActions iActions)
        {
            _iActions = iActions;
            _logger = logger;
        }

        [HttpGet("byAddition")]
        [ActionName("Addition")]
        public IActionResult GetAddition([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.Addition(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse
                {
                    Error = "ServerError",
                    Description = ex.Message
                });
            }
        }

        [HttpGet("byAdditionList")]
        [ActionName("AdditionList")]
        public IActionResult GetAdditionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            try
            {
                return Ok(_iActions.Addition(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("bySubtraction")]
        [ActionName("Subtraction")]
        public IActionResult GetSubtraction([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.Subtraction(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("bySubtractionList")]
        [ActionName("SubtractionList")]
        public IActionResult GetSubtractionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            try
            {
                return Ok(_iActions.Subtraction(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("byMultiplication")]
        [ActionName("Multiplication")]
        public IActionResult GetMultiplication([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.Multiplication(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpPost("byMultiplicationList")]
        [ActionName("MultiplicationList")]
        public IActionResult GetMultiplicationList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            try
            {
                return Ok(_iActions.Multiplication(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("byDivision")]
        [ActionName("Division")]
        public IActionResult GetDivision([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.Division(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("byDivisionList")]
        [ActionName("DivisionList")]
        public IActionResult GetDivisionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            try
            {
                return Ok(_iActions.Division(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("byCurveApproximation")]
        [ActionName("CurveApproximation")]
        public IActionResult GetCurveApproximation([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.CurveApproximation(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpGet("byCurveInterpolation")]
        [ActionName("CurveInterpolation")]
        public IActionResult GetCurveInterpolation([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            try
            {
                return Ok(_iActions.CurveInterpolation(firstArgument, secondArgument));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }

        [HttpPost("byCurveInterpolation")]
        [ActionName("CurveInterpolation")]
        public IActionResult GetCurveInterpolation([FromBody] PointXy[] pointXy)
        {
            try
            {
                return Ok(_iActions.CurveInterpolation(pointXy));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return StatusCode(500, new ErrorResponse { Error = "ServerError", Description = ex.Message });
            }
        }
    }
}