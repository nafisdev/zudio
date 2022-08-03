using Neo4j.Driver;

namespace zudio.graph.api;

public class Neo4jClientImpl
{

    private GraphConfig _graphConfig;
    public IDriver driver;
    public Neo4jClientImpl(IConfiguration configuration)
    {
        // configuration.GetSection("NeO4jConnectionSettings").Bind(_graphConfig);
        driver = GraphDatabase.Driver("neo4j://localhost:7474/db/neo4j");
    }

}