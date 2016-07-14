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
        private static int Sizes = 324;
        /// <summary>
        /// заполняем начальные данные для массива юзеров
        /// </summary>
        private void initData()
        {
            user = new List<User>();

            DateTime date = DateTime.Now;
            for (var i = 0;i< Sizes; i++)
            {
                string name = Generator.GetRandomString(3, "string");

                string addD = Generator.GetRandomString(6, "number");
                DateTime startDate = date.AddSeconds(Double.Parse(addD));
                addD = Generator.GetRandomString(1, "number");
                startDate = startDate.AddDays(Double.Parse(addD));
                date = startDate;
                string summRaw = Generator.GetRandomString(4, "number")+","+Generator.GetRandomString(2, "number");
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
            int sizePeriod = 23;
            User min = user.Min();
            User max = user.Max();
            TimeSpan d = max.DateShet1.Subtract(min.DateShet1);
            /**
             * 
             * число периодов для
             * */
            int period = d.Days / sizePeriod;
            Console.WriteLine("count period {0}", period);
            
            double[] result = new double[period+1];
            for(var i = 0;i < period; i++)
            {
                DateTime start = min.DateShet1.AddDays(i * sizePeriod);
                DateTime end = min.DateShet1.AddDays((i+1) * sizePeriod);
                double sum = 0;
                foreach(var row in user)
                {
                    if(  row.DateShet1 > start && row.DateShet1 < end)
                    {
                        sum += row.Summ;
                    }
                }
               if (sum > 0)
                    result[i] = sum / sizePeriod;
                else
                    Console.WriteLine("row {0} summ {1}", i, sum);
            }

            result = result.Where(x => x >0).ToArray();

            Console.WriteLine("Average result: {0} sizeof {1} ", result.Average(),result.Length);
           
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine("Delta day {0}", d.Days);
        }
    }
}
