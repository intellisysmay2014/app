using System.Data;
using app.data.core;

namespace app.web.application.store_browsing
{
  public class GetMainCategoriesQuery : IEncapsulateAQuery
  {
    public void prepare(IDbCommand command)
    {
      command.CommandType = CommandType.Text;
      command.CommandText = "SELECT * FROM MainCategories";
    }
  }
}