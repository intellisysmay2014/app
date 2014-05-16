using System;
using System.Data;

namespace app.data.core
{
  public interface ICreateConnections
  {
    IManageADatabase create();
  }

  public delegate void IConfigureAConnection(IDbConnection connection);

  public interface IManageADatabase : IDisposable
  {
    IRunRawQueries create_command_to_run(IEncapsulateAQuery query);
    void open();
    void configure_underlying_connection(IConfigureAConnection configuration);
  }
}