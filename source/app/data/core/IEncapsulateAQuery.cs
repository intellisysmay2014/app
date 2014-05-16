using System.Data;

namespace app.data.core
{
  public interface IEncapsulateAQuery
  {
    void prepare(IDbCommand command);
  }
}