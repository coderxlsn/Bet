using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library1.Model;
using Library1.Data;
namespace Library1
{
    public class Class1
    {
        private List<User> user;
        private static int Sizes = 1000;
        /// <summary>
        /// заполняем начальные данные для массива юзеров
        /// </summary>
        private void initData()
        {
            user = new List<User>();
            for(var i = 0;i< Sizes; i++)
            {
                string name = Generator.GetRandomString(3, "string");
                DateTime date = DateTime.Now;
                string addD = Generator.GetRandomString(3, "number");
                DateTime startDate = date.AddSeconds(Double.Parse(addD));
                addD = Generator.GetRandomString(3, "number");
                startDate = startDate.AddDays(Double.Parse(addD));
                string summRaw = Generator.GetRandomString(3, "number")+","+Generator.GetRandomString(2, "number");
                double summ = Double.Parse(summRaw);
                User u = new User();
                u.ID1 = i;
                u.Name1 = "partner_"+name;
                u.IdPartner1 = 1;
                u.Summ = summ;
                u.DateShet1 = startDate;
                user.Add(u);
            }
        }

        public void Main()
        {
            initData();
            user.Sort();
            int sizePeriod = 15;
            User min = user.Min();
            User max = user.Max();
            TimeSpan d = max.DateShet1.Subtract(min.DateShet1);
            /**
             * 
             * число периодов для
             * */
            int period = d.Days / sizePeriod;

            for(var i = 0;i < period; i++)
            {

            }
            Console.WriteLine("Length period {0}",  period);

            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine("Delta day {0}", d.Days);
        }
    }
}
