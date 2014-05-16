using System.Collections.Generic;
using app.data.core;

namespace app.web.application.store_browsing
{
  public class QueryGateway : IQueryForData
  {
    ICreateConnections connection_factory;

    public QueryGateway(ICreateConnections connection_factory)
    {
      this.connection_factory = connection_factory;
    }

    public IEnumerable<Result> query_using<Result>(IEncapsulateAQuery query)
    {
      using (var connection = connection_factory.create())
      using (var command = connection.create_command_to_run(query))
      {
        connection.open();
        return command.execute_for<Result>();
      }
    }
  }
}