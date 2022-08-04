using Neo4j.Driver;
using zudio.graph.api;

public class CypherExec
{
    public Neo4jClientImpl _clientWrapper;
    public CypherExec(Neo4jClientImpl clientWrapper)
    {
        _clientWrapper = clientWrapper;
    }

    public async Task CreateNodeExecute(GraphPayload graphPayload)
    {

        string data = "productA";
        IAsyncSession session = _clientWrapper.driver.AsyncSession(o => o.WithDatabase("neo4j"));
        try
        {

            IResultCursor cursor = await session.RunAsync("CREATE (a:Product{name:$data})", new{ data});
            await cursor.ConsumeAsync();
        }
        finally
        {
            await session.CloseAsync();
        }
        await _clientWrapper.driver.CloseAsync();
    }

    public async Task CreateRelationshipExecute(GraphPayload graphPayload)
    {

        string data = "productA";
        IAsyncSession session = _clientWrapper.driver.AsyncSession(o => o.WithDatabase("neo4j"));
        try
        {

            IResultCursor cursor = await session.RunAsync("CREATE (a:Product)", new{ data});
            await cursor.ConsumeAsync();
        }
        finally
        {
            await session.CloseAsync();
        }
        await _clientWrapper.driver.CloseAsync();
    }
}