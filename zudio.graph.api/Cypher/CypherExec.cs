using Neo4j.Driver;
using zudio.graph.api;

public class CypherExec
{
    public Neo4jClientImpl _clientWrapper;
    private readonly ILogger<CypherExec> _logger;
    public CypherExec(Neo4jClientImpl clientWrapper,ILogger<CypherExec> logger)
    {
        _clientWrapper = clientWrapper;
        _logger = logger;
    }

    public async Task CreateProductNodeExecute(GraphPayload graphPayload)
    {

        string data1 = graphPayload.Data;
        IAsyncSession session = _clientWrapper.driver.AsyncSession(o => o.WithDatabase("neo4j"));
        try
        {
            IResultCursor cursor = await session.RunAsync("CREATE (a:Product{name: $data1})", new{ data1});
            await cursor.ConsumeAsync();
        }
        finally
        {
            await session.CloseAsync();
        }
        await _clientWrapper.driver.CloseAsync();
    }

        public async Task CreateAnalyticsNodeExecute(GraphPayload graphPayload)
    {
        string data1 = graphPayload.Data;
        IAsyncSession session = _clientWrapper.driver.AsyncSession(o => o.WithDatabase("neo4j"));
        try
        {
            IResultCursor cursor = await session.RunAsync("CREATE (a:Analytics{name: $data1})", new{ data1});
            await cursor.ConsumeAsync();
        }
        finally
        {
            await session.CloseAsync();
        }
        await _clientWrapper.driver.CloseAsync();
    }

    public async Task CreateRelationshipExecute(GraphRelationshipPayload graphPayload)
    {

        string node1 = graphPayload.ProductName;
        string node2 = graphPayload.AnalyticsName;
        IAsyncSession session = _clientWrapper.driver.AsyncSession(o => o.WithDatabase("neo4j"));
        try
        {
            IResultCursor cursor = await session.RunAsync("MATCH (a:Product), (b:Analytics) WHERE a.name = $node1 AND b.name = $node2 CREATE (a)-[r:RELTYPE]->(b)"+
            "RETURN type(r)", new{ node1,node2});
            await cursor.ConsumeAsync();
        }
        catch(Exception e)
        {
            _logger.Log(LogLevel.Error, e.ToString());
        }
        finally
        {
            await session.CloseAsync();
        }
        await _clientWrapper.driver.CloseAsync();
    }
}