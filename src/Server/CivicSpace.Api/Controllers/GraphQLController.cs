using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.SystemTextJson;
using GraphQL.Transport;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace CivicSpace.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphQLRequest request)
        {
            var startTime = DateTime.UtcNow;

            var result = await _documentExecuter.ExecuteAsync(s =>
            {
                s.Schema = _schema;
                s.Query = request.Query;
                s.Variables = request.Variables;
                s.OperationName = request.OperationName;
                s.RequestServices = HttpContext.RequestServices;
                //s.UserContext = new GraphQLUserContext
                //{
                //    User = HttpContext.User,
                //};
                s.CancellationToken = HttpContext.RequestAborted;
            });

            return new ExecutionResultActionResult(result);
        }
    }
}
