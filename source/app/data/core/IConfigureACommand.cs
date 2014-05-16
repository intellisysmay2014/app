using System.Data;

namespace app.data.core
{
  public delegate void IConfigureACommand(IDbCommand command);
}