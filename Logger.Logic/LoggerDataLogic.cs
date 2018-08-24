using Logger.ILogic;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Entity;

namespace Logger.Logic
{
    public class LoggerDataLogic: ILoggerDataLogic
    {
        protected DbContext Context = new JobLoggerDBContainer();
        protected DbSet<JobLogger> DbSet;

        public Operation Save(Entity.JobLogger oJobLogger)
        {
            DbSet = Context.Set<JobLogger>();

            Operation oOperation = null;
            try
            {
                DbSet.Add(oJobLogger);
                Context.SaveChanges();

                oOperation = new Operation()
                {
                    Success = true,
                    Message = "Operation Successfully Completed."
                };
            }
            catch (Exception e)
            {
                oOperation = new Operation()
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return oOperation;
        }
    }
}
