using System.Windows;
using GalaSoft.MvvmLight.Threading;
using System.Threading;
using System.Windows.Navigation;
using System;

namespace TransmissionFluid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDisposable
    {
        Mutex _Mutex;

        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            bool aIsNewInstance = false;
            _Mutex = new Mutex(true, "MyWPFApplication", out aIsNewInstance);
            if (!aIsNewInstance)
            {
                MessageBox.Show("Already an instance is running...");
                App.Current.Shutdown();
            }
            
            SettingsManager.Instance.LoadSettings();

            base.OnStartup(e);
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
