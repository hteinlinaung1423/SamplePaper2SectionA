using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePaper2SectionA
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Code = new string[100];
            int[] qty = new int[100];
            decimal[] price = new decimal[100];
            char member;
            string memberID; decimal memberdis=0.0M;
            decimal[] discount = new decimal[100];
            decimal[] net = new decimal[100];
            decimal[] cost = new decimal[100];
            decimal grosstotal=0.0M;
            decimal amtpayable;
            decimal GST;
            char exit = 'N';
            int i = 0;
            do
            {
                Console.Write("Enter Item Code :");
                Code[i] = Console.ReadLine();                
                Console.Write("Enter Qty :");
                qty[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Unit Price :");
                price[i] = Convert.ToDecimal(Console.ReadLine());
                Console.Write("To enter more items press Y; to end press N: ");
                exit = Convert.ToChar(Console.ReadLine());
                i++;

            }
            while (exit == 'Y');
          
            for (int j = 0; j < i; j++)
            {
                cost[j] = qty[j] * price[j];
            }
                
            DayOfWeek day = DateTime.Today.DayOfWeek;

            if (day == DayOfWeek.Wednesday)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Code[j].Substring(0, 1) == "F")
                    {
                        discount[j] = cost[j] * 0.2M;
                    }
                    else
                    {
                        discount[j] = 0.0M;
                    }

                    net[j] = cost[j] - discount[j];
                    grosstotal += net[j];
                }
            }
            else
            {
                for (int j = 0; j < i; j++)
                {                    
                    discount[j] = 0.0M;                   
                    net[j] = cost[j] - discount[j];
                    grosstotal += net[j];
                }
            }

            Console.Write("The shopper a loyalty member? ");
            member = Convert.ToChar(Console.ReadLine());

            if (member == 'Y')
            {
                Console.WriteLine("Member No:");
                memberID = Console.ReadLine();

                memberdis = grosstotal * 0.1M;
                GST = grosstotal - memberdis * 0.07M;
                amtpayable = grosstotal - memberdis + GST;
            }
            else
            {
                GST = grosstotal * 0.07M;
                amtpayable = grosstotal + GST;
            }

            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3:0.00}\t {4:0.00}\t {5:0.00}\t {6:0.00}", j, Code[j], qty[j], price[j], cost[j], discount[j], net[j]);
            }

            Console.WriteLine("Gross Total : ${0:0.00}", grosstotal);
            Console.WriteLine("Member Discount : - ${0:0.00}", memberdis);
            Console.WriteLine("GST @ 7% : + ${0:0.00}", GST);
            Console.WriteLine();
            Console.WriteLine("Please Pay : ${0:0.00}", amtpayable);









        }
    }
}
