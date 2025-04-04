using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kobi_v1
{
    public class ClockManager
    {
        private Timer timer;
        private Label targetlabel;

        public ClockManager(Label label)
        {
            targetlabel = label;
            SetupClock();
        }
        private void SetupClock()
        {
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += new EventHandler(UpdateClock);
            timer.Start();
            UpdateClock(null, null);
        }
        private void UpdateClock(object sender, EventArgs e)
        {
            if(targetlabel != null)
             {
                    targetlabel.Text = DateTime.Now.ToString("HH:mm:ss");
             }
        }
    }

    
}
