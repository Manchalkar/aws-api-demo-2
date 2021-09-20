using Etools.Entities.DbContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Entities.Repositories
{
    public abstract class ContextRepository : IDisposable
    {
        private static EtoolsDbContext _joinContext;
        public ContextRepository()
        {

        }

        internal static EtoolsDbContext JoinContext
        {
            get
            {
                if (_joinContext == null)
                {
                    _joinContext = new EtoolsDbContext();
                }
                return _joinContext;
            }
        }

        public void Dispose()
        {
            if (_joinContext != null)
            {
                _joinContext.Dispose();
                _joinContext = null;
            }
        }
    }
}
