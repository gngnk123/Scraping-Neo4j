using Aspose.Email.Clients.Graph;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Class1
    {
        //make sure Neo4J service is running before opening the db
        var graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "myPassword");
        GraphClient.Connect();
    }
}