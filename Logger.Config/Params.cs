using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Params
{
    private static string _sysversion;

    public static string SysVersion
    {
        get
        {
            if (String.IsNullOrEmpty(_sysversion))
            {
                _sysversion = Guid.NewGuid().ToString().Substring(0, 7);
            }
            return _sysversion;
        }
        set
        {
            _sysversion = value;
        }
    }
}