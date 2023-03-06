using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kesha.vir
{
    static class Program
    {
        static Dictionary<int, string> formNames = new Dictionary<int, string>();

        [STAThread]
        static void Main(string[] args)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!File.Exists(@"C:\Windows\kesha.txt"))
            {
                if (!hasAdministrativeRight)
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                    processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                    processInfo.FileName = Application.ExecutablePath; //указываем исполняемый файл (программу) для запуска
                    try
                    {
                        Process.Start(processInfo); //пытаемся запустить процесс
                    }
                    catch (Win32Exception)
                    {
                        //Ничего не делаем
                    }
                    Application.Exit();
                }
                else
                {
                    try
                    {
                        string filePath = (@"C:\Windows\kesha.txt");

                        string st = Application.ExecutablePath + "\n" + @"" + "\n" + "\n" +
                            @"░░░██╗░░██╗███████╗░██████╗██╗░░██╗░█████╗░" + "\n" +
                            @"░░░██║░██╔╝██╔════╝██╔════╝██║░░██║██╔══██╗" + "\n" +
                            @"░░░█████═╝░█████╗░░╚█████╗░███████║███████║" + "\n" +
                            @"░░░██╔═██╗░██╔══╝░░░╚═══██╗██╔══██║██╔══██║" + "\n" +
                            @"██╗██║░╚██╗███████╗██████╔╝██║░░██║██║░░██║" + "\n" +
                            @"╚═╝╚═╝░░╚═╝╚══════╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝" + "\n" + "";

                        using (FileStream fileStream = File.Open(filePath, FileMode.Create))
                        {
                            using (StreamWriter output = new StreamWriter(fileStream))
                            {
                                output.Write(st);
                            }
                        }
                    }
                    catch { }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
