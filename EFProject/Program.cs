using EFProject.Models;
using EFProject.Utility;

namespace EFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //EFCoreInsert();
            //EFCoreUpdate();
            EFCoreDelete();
        }

        static void EFCore()
        {
            try
            {
                var db = new POSAgentsContext();
                var agen = new AgentProfile();
                agen.AgentName = "Nealson Wyeth";
                agen.AgentId = 1;
                agen.PhoneNumber = "279-770-9825";
                agen.Gender = "Male";
                db.AgentProfile.Add(agen);
                var noOfInsertRows = db.SaveChanges();
                Console.WriteLine($"{noOfInsertRows} row(s) was inserted successfully");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        static void EFCoreDelete()
        {
            try
            {
                var db = new POSAgentsdbContext();
            }
        }

        static void MethodChain()
        {
            string[] tasks = { "collect", "pay" };

            var eod = new EndOfDay(tasks.ToList());

            var output = eod
                .CheckSystem()
                .AddApproval("Mac")
                .RemoveTax()
                .CloseDay();


        }
    }

    internal class POSAgentsdbContext
    {
        public POSAgentsdbContext()
        {
        }
    }
}