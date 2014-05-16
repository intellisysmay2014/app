using System.Collections.Generic;
using app.data.core;

namespace app.web.application.store_browsing
{
  public interface IQueryForData
  {
    IEnumerable<Result> query_using<Result>(IEncapsulateAQuery query);
  }
}