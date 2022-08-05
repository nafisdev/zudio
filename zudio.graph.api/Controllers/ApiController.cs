using Microsoft.AspNetCore.Mvc;

namespace zudio.graph.api.Controllers;

[ApiController]
[Route("[controller]")]
public class ZudioGraphController : ControllerBase
{


    private readonly ILogger<ZudioGraphController> _logger;
    public CypherExec _cypherExec;

    public ZudioGraphController(ILogger<ZudioGraphController> logger , CypherExec cypherExec)
    {
        _logger = logger;
        _cypherExec = cypherExec;
    }

    [HttpGet(Name = "GetProduct")]
    public IEnumerable<Product> Get()
    {
        // return _cypherExec.GetGProductNodeExecute(graphPayload);
        // .ToArray();
        return null;
    }

    
    [HttpPost("/Products",Name = "AddProductToGraph")]
    public void AddProducts(GraphPayload graphPayload)
    {
         _cypherExec.CreateProductNodeExecute(graphPayload);
    }

        
    [HttpPost("/Analytics",Name = "AddAnalyticsToGraph")]
    public void AddAnalytics(GraphPayload graphPayload)
    {
         _cypherExec.CreateAnalyticsNodeExecute(graphPayload);
    }

    [HttpPost("/Relationship",Name = "AssociateAnalyticsToProducts")]
    public void Relationship(GraphRelationshipPayload graphPayload)
    {
        _cypherExec.CreateRelationshipExecute(graphPayload);
    }
}
