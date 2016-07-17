using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTool.Data.Repositories
{
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="transaction">the db transaction.</param>
        public RepositoryBase(IDbTransaction transaction)
        {
            this.Transaction = transaction;
        }

        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection
        {
            get
            {
                return this.Transaction.Connection;
            }
        }
    }
}
