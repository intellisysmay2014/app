using System.Data;

namespace app.data.core
{
  public class DatabaseConnection : IManageADatabase
  {
    IDbConnection connection;
    IConfigureACommand initial_command_config;
    ICreateRawQueriesFromCommands query_factory;

    public DatabaseConnection(IDbConnection connection, IConfigureACommand initial_command_config, ICreateRawQueriesFromCommands query_factory)
    {
      this.connection = connection;
      this.initial_command_config = initial_command_config;
      this.query_factory = query_factory;
    }

    public void Dispose()
    {
      connection.Dispose();
    }

    public void configure_underlying_connection(IConfigureAConnection configuration)
    {
      configuration(connection);
    }

    public IRunRawQueries create_command_to_run(IEncapsulateAQuery query)
    {
      var command = connection.CreateCommand();
      initial_command_config(command);
      query.prepare(command);
      return query_factory(command);
    }

    public void open()
    {
      connection.Open();
    }
  }
}