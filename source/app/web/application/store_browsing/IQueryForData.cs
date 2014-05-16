using System;
using System.Collections;
using System.Collections.Generic;

namespace app.web.application.store_browsing
{
    public interface IQueryForData
    {
        IEnumerable<TEntity> find_all_data_where<TEntity>(Func<TEntity, bool> where);

    }
}