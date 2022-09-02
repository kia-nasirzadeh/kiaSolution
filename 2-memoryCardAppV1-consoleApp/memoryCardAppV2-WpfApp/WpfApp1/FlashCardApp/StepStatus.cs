using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.FlashCardApp
{
    public enum Status
    {
        NotReached,
        Succeed,
        Failed,
        Absent
    }
    public class StepStatus
    {
        public int Step { get; set; }
        public Status Status { get; set; }
    }
}
