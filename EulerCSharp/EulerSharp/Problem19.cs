using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSharp {
    class Problem19 {
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int dayname = 1;
        int day = 1;
        int month = 1;
        int year = 1900;

        int Dayname {
            get { return dayname; }
            set { dayname = value % 7; }
        }

        int Year {
            get { return year; }
            set {
                year = value;
                if(Leap)
                    Console.WriteLine(Year);
            }
        }
        int Day {
            get { return day; }
            set {
                day = value;
                while(day > Days) {
                    day -= Days;
                    Month++;
                }
            }
        }
        int Month {
            get { return month; }
            set {
                month = value;
                while(month >= 13) {
                    month -= 12;
                    Year++;
                }
            }
        }
        int Days {
            get {
                if(Month == 2 && Leap) {
                    return days[Month - 1] + 1;
                } else {
                    return days[Month - 1];
                }
            }
        }

        bool Leap {
            get { return Year % 4 == 0 && Year % 100 != 0 || Year % 400 == 0; }

        }

        private void oneDay() {
            Dayname++;
            Day++;
        }

        public int Solve() {
            int count = 0;
            Console.WriteLine("{0}.{1}.{2} - {3}", Day, Month, Year, Dayname);
            while(Year < 2001) {
                oneDay();
                if(Year > 1900 && Dayname == 0 && Day == 1) {
                    count++;
                    //Console.WriteLine("{0}.{1}.{2} - {3}", Day, Month, Year, Dayname);
                };
            }
            Console.Write(count);
            Console.ReadKey(true);
            return count;
        }
    }
}
