using System.Data;

namespace app.data.core
{
  public delegate IRunRawQueries ICreateRawQueriesFromCommands(IDbCommand command);
}