using System;
using System.Collections.Generic;
using System.Data;

namespace app.web.application.store_browsing
{
    public class ReadProductData: IQueryForData
    {
        private IDbConnection connection;

        public ReadProductData(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<TEntity> find_all_data_where<TEntity>(Func<TEntity, bool> @where)
        {
            throw new NotImplementedException();
        }
    }
}