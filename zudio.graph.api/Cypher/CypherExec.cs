using zudio.graph.api;

public class CypherExec
{
    public Neo4jClientImpl _clientWrapper;
    public CypherExec(Neo4jClientImpl clientWrapper)
    {
        _clientWrapper = clientWrapper;
    }

    public async Task execute(GraphPayload graphPayload)
    {
        using (var session = _clientWrapper.driver.AsyncSession())
        {
            var greeting = session.WriteTransactionAsync(tx =>
            {
                var result = tx.RunAsync("CREATE (a:Product) " +
                                    "SET a.name = $message " +
                                    "RETURN a.message + ', from node ' + id(a)");
                                    return null;
            });
            Console.WriteLine(greeting);
        }
    }
}