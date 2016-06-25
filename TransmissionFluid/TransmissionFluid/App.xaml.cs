using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System.Threading;
using System.Windows.Navigation;
using System;
using System.IO.Pipes;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace TransmissionFluid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDisposable
    {
        Mutex _Mutex;
        private const string PIPE_NAME = "TransmissionFluid";
        public static TransmissionRemote.RPC.Client Client;

        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            //Enforce Single Instance
            bool aIsNewInstance = false;
            _Mutex = new Mutex(true, "TransmissionFluid", out aIsNewInstance);
            if (!aIsNewInstance)
            {
                if (args.Length > 0)
                {
                    //Named Pipe Client
                    using (var client = new NamedPipeClientStream(PIPE_NAME))
                    {
                        client.Connect();

                        StreamReader reader = new StreamReader(client);
                        StreamWriter writer = new StreamWriter(client);

                        writer.WriteLine(args[1]);
                        writer.Flush();

                        client.Close();
                    }
                }

                //Shutdown this instance
                App.Current.Shutdown();
            }

            StartServer();

            if (args.Length > 1)
            {
                AddTorrentView win = new AddTorrentView();
                win.Show(args[1]);
                win.Activate();
            }
                        

            SettingsManager.Instance.LoadSettings();
            //TODO: Add RPC Session DownloadDir to list.
            string defaultDir = @"/home/";
            if (!SettingsManager.Instance.Settings.RecentFolders.Contains(defaultDir))
                SettingsManager.Instance.Settings.RecentFolders.Add(defaultDir);

            base.OnStartup(e);
        }

        static void StartServer()
        {
            Task.Factory.StartNew(() =>
            {
                var server = new NamedPipeServerStream(PIPE_NAME);
                
                while (true)
                {
                    server.WaitForConnection();
                    StreamReader reader = new StreamReader(server);
                    StreamWriter writer = new StreamWriter(server);
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            AddTorrentView win = new AddTorrentView();
                            win.Show(line);
                            win.Activate();
                        }, System.Windows.Threading.DispatcherPriority.Send);
                    }
                    server.Disconnect();
                }


            });
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
        }

        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);

            SettingsManager.Instance.LoadSettings();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            SettingsManager.Instance.SaveSettings();
            base.OnExit(e);
        }

        private void Dispose(Boolean disposing)
        {
            if (disposing && (_Mutex != null))
            {
                _Mutex.ReleaseMutex();
                _Mutex.Close();
                _Mutex = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
