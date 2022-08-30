using System;
using System.Linq;
using EFProject.Models;
using EFProject.Utility;
using EntityFramework.Exceptions.Common;
using Microsoft.Data.SqlClient;

namespace EFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Database!");
            EFCoreInsert();
            //EFCoreUpdate();
            //EFCoreDelete();
        }

        static void EFCoreInsert()
        {
            try
            {
                var db = new POSAgentsContext();
                var agen = new AgentProfile();
                agen.AgentName = "Nealson Wyeth";
                agen.AgentId = 1;
                agen.PhoneNumber = "279-770-9825";
                agen.Gender = "Male";
                db.AgentProfiles.Add(agen);
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
                var db = new POSAgentsContext();
                var wantedAgen = db.AgentProfiles.Where(a => a.AgentId == 1).FirstOrDefault();
                db.AgentProfiles.Remove(wantedAgen);
                var deletedRow = db.SaveChanges();
                Console.WriteLine($"{deletedRow} row(s) was deleted successfully");
            }

            catch (UniqueConstraintException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EFCoreUpdate()
        {
            try
            {
                var db = new POSAgentsContext();
                var wantedAgen = db.AgentProfiles.Where(a => a.AgentId == 1).FirstOrDefault();
                wantedAgen.AgentName = "Mark";
                wantedAgen.PhoneNumber = "209-970-8455";

                db.Update(wantedAgen);
                var updatedRows = db.SaveChanges();
                Console.WriteLine($"{updatedRows} row(s) was updated successfully");
            }

            catch (UniqueConstraintException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        //static void MethodChain()
        //{
        //    string[] tasks = { "collect", "pay" };

        //    var eod = new EndOfDay(tasks.ToList());

        //    var output = eod
        //        .CheckSystem()
        //        .AddApproval("Mac")
        //        .RemoveTax()
        //        .CloseDay();



    }
}