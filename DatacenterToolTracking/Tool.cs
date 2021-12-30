using System;
using System.Collections.Generic;
using System.Text;

namespace DatacenterToolTracking
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string ToolType { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public string FullInfo
        {
            get
            {
                // 001 | STMK.USB.8.1 | BN6 Lockbox (USB: Running 3.1 version of SMTK )
                return $"{ToolName} | {Location}  |  {Status})";
            }
        }
    }
}
