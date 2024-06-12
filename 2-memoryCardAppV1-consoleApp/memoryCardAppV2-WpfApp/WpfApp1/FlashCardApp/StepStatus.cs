using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.FlashCardApp
{
    public enum Status
    {
        NotReached, //0
        Succeed, //1
        Failed, //2
        Absent //3
    }
    public class StepStatus
    {
        public int Step { get; set; }
        public Status Status { get; set; }
    }
}
