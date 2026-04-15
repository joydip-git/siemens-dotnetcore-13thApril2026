using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo
{
    public class SiemensDbSetting
    {
        public string? Server { get; set; }
        public string? Database { get; set; }

        public Authentication? Authentication { get; set; }        
    }
}
