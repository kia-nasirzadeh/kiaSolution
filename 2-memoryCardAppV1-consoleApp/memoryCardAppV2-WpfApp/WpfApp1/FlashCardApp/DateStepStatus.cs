using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.FlashCardApp
{
    public class DateStepStatus
    {
        public DateTime dateTime { get; set; }
        public StepStatus? stepStatus { get; set; }
    }
    public class StringStepStatus
    {
        public string dateTime { get; set; }
        public StepStatus? stepStatus { get; set; }
    }
}
