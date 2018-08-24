using Logger.ILogic;
using Logger.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Entity;

namespace Logger.Logic
{
    public class LoggerFileLogic: ILoggerFileLogic
    {
        private Operation oOperation = Operation.GetSingleton();

        public Operation SaveLogger(Entity.JobLogger oJobLogger)
        {
            string line = String.Empty;
            string path = WebConfig.LogFileDirectory;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            string ruta = string.Format("{0}{1}{2}.{3}", path, "LogFile_", DateTime.Now.ToString("yyyyMMdd"), "txt");
            List<string> listText = new List<string>();
            try
            {
                if (!File.Exists(ruta)) File.Create(ruta);
                else
                {
                    char[] delimiters = new char[] { '\r', '\n' };
                    System.IO.StreamReader sr = new System.IO.StreamReader(ruta);
                    string rtt = sr.ReadToEnd();
                    listText = rtt.Split(delimiters).ToList();
                    sr.Close();
                }

                line = string.Format("{0}:{1}", DateTime.Now.ToString("ddMMyyyyHHmm"), oJobLogger.Message);
                listText.Add(line);
                File.WriteAllLines(ruta, listText);

                oOperation = new Operation { Success = true, Message = "Operation Successfully Completed." };
            }
            catch (Exception e)
            {
                oOperation.Success = false;
                oOperation.Message = e.Message;
            }

            return oOperation;
        }
    }
}
