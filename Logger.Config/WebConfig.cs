using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class WebConfig
{
    public static string VirtualPath
    {
        get
        {
            return ConfigurationManager.AppSettings["VirtualPath"] ?? string.Empty;
        }
    }

    public static string WSKey
    {
        get
        {
            return ConfigurationManager.AppSettings["WSKey"] ?? string.Empty;
        }
    }

    public static string LogFileDirectory
    {
        get
        {
            return ConfigurationManager.AppSettings["LogFileDirectory"] ?? string.Empty;
        }
    }

    public static int ConfigurationFile
    {
        get
        {
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ConfigurationFile"]))
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigurationFile"]);
            }
            return 1;
        }
    }

    public static int ConfigurationDatabase
    {
        get
        {
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ConfigurationDatabase"]))
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigurationDatabase"]);
            }
            return 2;
        }
    }

    public static int TypeMessageError
    {
        get
        {
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["TypeMessageError"]))
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["TypeMessageError"]);
            }
            return 1;
        }
    }

    public static int TypeMessageWarning
    {
        get
        {
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["TypeMessageWarning"]))
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["TypeMessageWarning"]);
            }
            return 2;
        }
    }

    public static int TypeMessageMessage
    {
        get
        {
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["TypeMessageMessage"]))
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["TypeMessageMessage"]);
            }
            return 3;
        }
    }
}
