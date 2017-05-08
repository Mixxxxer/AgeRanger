using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;

namespace AgeRanger.Data.Contexts
{
    public class BaseDbContext<T> : DbContext where T : DbContext
    {
        #region Protected Members

        protected const int DefaultCommandTimeout = 60 * 2;
        protected const int LongCommandTimeout = 60 * 20;

        #endregion

        #region Constructor

        protected BaseDbContext(string connString)
            : base(connString)
        {
            Database.SetInitializer<T>(null);
            Database.CommandTimeout = DefaultCommandTimeout;
        }

        public BaseDbContext(DbConnection connection)
            : base(connection, true)
        {
            Database.CommandTimeout = DefaultCommandTimeout;
        }

        #endregion
    }
}
