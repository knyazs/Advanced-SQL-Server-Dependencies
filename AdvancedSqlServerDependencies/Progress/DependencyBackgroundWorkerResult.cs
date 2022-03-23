using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedSqlServerDependencies.Progress
{
    public class DependencyBackgroundWorkerResult
    {
        public EResultType ResultType;
        public object ResultObject;
    }

    public enum EResultType
    {
        SHOW_RESULTS,
        RERUN
    }
}
