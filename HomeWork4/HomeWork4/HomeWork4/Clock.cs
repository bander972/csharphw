using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    class Clock
    {
        public delegate void MyClock();
        
        private int SettledMinute { get; set; }
        private int SettledHour { get; set; }

        private DateTime time;
     
        public Clock(int hour,int minute)
        {
            SettledHour = hour;
            SettledMinute =minute;
            this.time = DateTime.Now;
        }
        public void Tick() {
            while(time.Hour <=SettledHour && time.Minute <SettledMinute)
            {
                Console.WriteLine(" " + time.ToString() + "tick tick,it's time to do something!!");
                System.Threading.Thread.Sleep(1000);
                time = DateTime.Now;
            }
        }
        public void Alarm() {
            if (time.Hour >= SettledHour && time.Minute>= SettledMinute)
            {
                Console.WriteLine(" "+time.ToString() + " Time Alarming , time to rest!");
            }
        }
    }
}
