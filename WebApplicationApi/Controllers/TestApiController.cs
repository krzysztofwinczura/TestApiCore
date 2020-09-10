using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly IActions _iActions;

        public TestApiController(IActions iActions)
        {
            _iActions = iActions;
        }

        [HttpGet("byAddition")]
        [ActionName("Addition")]
        public string GetAddition([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.Addition(firstArgument, secondArgument);
        }

        [HttpGet("byAdditionList")]
        [ActionName("AdditionList")]
        public string GetAdditionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            return _iActions.Addition(firstArgument, secondArgument);
        }

        [HttpGet("bySubtraction")]
        [ActionName("Subtraction")]
        public string GetSubtraction([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.Subtraction(firstArgument, secondArgument);
        }

        [HttpGet("bySubtractionList")]
        [ActionName("SubtractionList")]
        public string GetSubtractionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            return _iActions.Subtraction(firstArgument, secondArgument);
        }

        [HttpGet("byMultiplication")]
        [ActionName("Multiplication")]
        public string GetMultiplication([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.Multiplication(firstArgument, secondArgument);
        }

        [HttpGet("byMultiplicationList")]
        [ActionName("MultiplicationList")]
        public string GetMultiplicationList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            return _iActions.Multiplication(firstArgument, secondArgument);
        }

        [HttpGet("byDivision")]
        [ActionName("Division")]
        public string GetDivision([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.Division(firstArgument, secondArgument);
        }

        [HttpGet("byDivisionList")]
        [ActionName("DivisionList")]
        public string GetDivisionList([FromQuery] string firstArgument, [FromQuery] string[] secondArgument)
        {
            return _iActions.Division(firstArgument, secondArgument);
        }

        [HttpGet("byCurveApproximation")]
        [ActionName("CurveApproximation")]
        public string GetCurveApproximation([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.CurveApproximation(firstArgument, secondArgument);
        }

        [HttpGet("byCurveInterpolation")]
        [ActionName("CurveInterpolation")]
        public string GetCurveInterpolation([FromQuery] string firstArgument, [FromQuery] string secondArgument)
        {
            return _iActions.CurveInterpolation(firstArgument, secondArgument);
        }
    }
}