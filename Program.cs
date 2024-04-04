using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using System.Management;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace OsLab_HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("choose what do you want to do.");
            Console.WriteLine("1.Run a process.");
            Console.WriteLine("2.Show list of all processes.");
            Console.WriteLine("3.Kill a process by name.");
            Console.WriteLine("4.Kill a process by id.");
            Console.WriteLine("5.Show parent of the process by name.");
            Console.WriteLine("6.Show parent of the process by id.");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine("Please enter process name you want to run:");
                    string prname_start = Console.ReadLine();
                    Process.Start(prname_start);
                    break;

                case 2:
                    foreach (Process prlist in Process.GetProcesses())
                    {
                        Console.WriteLine(prlist.Id + "\t" + prlist.ProcessName);
                    }
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Please enter process name you want to kill:");
                    string prname_kill = Console.ReadLine();
                    Process[] prkill = Process.GetProcessesByName(prname_kill);
                    foreach (Process pr in prkill)
                    {
                        pr.Kill();
                    }
                    break;

                case 4:
                    Console.WriteLine("Please enter process id you want to kill:");
                    int pid = int.Parse(Console.ReadLine());
                    Process[] prList = Process.GetProcesses();
                    foreach (Process p in prList)
                    {
                        Console.WriteLine(p.Id + "\t" + p.ProcessName);
                    }
                    foreach (Process p in prList)
                    {
                        if (p.Id == pid)
                            p.Kill();
                    }
                    break;

                case 5:
                    Console.WriteLine("Please Enter the name of the process that you want to know its parent:");
                    string processName = Console.ReadLine();
                    Process[] processes = Process.GetProcessesByName(processName);
                    foreach (Process process in processes)
                    {
                        var performanceCounter = new PerformanceCounter("Process", "Creating Process ID", process.ProcessName);
                        int parentProcessId = (int)performanceCounter.RawValue;
                        Process parentProcess = Process.GetProcessById(parentProcessId);
                        Console.WriteLine("Parent for {0} is {1} and pid: {2}", process.Id, parentProcess.ProcessName, parentProcess.Id);
                    }
                    Console.ReadKey();
                    break ;

                case 6:
                    Console.WriteLine("Please enter the id of the process that you want to know its parent: ");
                    int pidpr = Convert.ToInt32(Console.ReadLine());
                    Process proc = Process.GetProcessById(pidpr);
                    var perc = new PerformanceCounter("Process", "Creating Process ID", proc.ProcessName);
                    int parentpro = (int)perc.RawValue;
                    Process parentp = Process.GetProcessById(parentpro);
                    Console.WriteLine("Parent for {0} is {1} and pid: {2}", proc.ProcessName, parentp.ProcessName, parentp.Id);
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;

            }

        }

    }
}