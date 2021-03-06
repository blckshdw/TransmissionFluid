﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace TransmissionFluid
{
    public sealed class SettingsManager : GalaSoft.MvvmLight.ViewModelBase
    {
        #region - Singleton -
        private static SettingsManager _instance = null;
        private static readonly object padlock = new object();

        SettingsManager()
        {
            this.Settings = new Settings();
            this.Settings.RecentFolders = new List<string>();
            this.Settings.RecentFolders.Add("test");
        }

        public static SettingsManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SettingsManager();
                    }
                    return _instance;
                }
            }
        }
        #endregion

        private const string AppName = "TransmissionFluid";


        public Settings Settings { get; set; }

        public void SaveSettings()
        {
            if (this.Settings != null)
            {
                var path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (!Directory.Exists(path + "\\" + AppName))
                {
                    try
                    {
                        Directory.CreateDirectory(path + "\\" + AppName);
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }

                if (Directory.Exists(path + "\\" + AppName))
                {
                    XmlSerializer ser = new XmlSerializer(this.Settings.GetType());
                    using (var fs = new FileStream(path + "\\" + AppName + "\\Settings.dat", FileMode.Create))
                    {
                        ser.Serialize(fs, this.Settings);
                    }
                }
            }
        }

        public void LoadSettings()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (File.Exists(path + "\\" + AppName + "\\Settings.dat"))
            {
                XmlSerializer ser = new XmlSerializer(this.Settings.GetType());
                using (var fs = new FileStream(path + "\\" + AppName + "\\Settings.dat", FileMode.Open))
                {
                    try
                    {
                        var settings = (Settings)ser.Deserialize(fs);
                        this.Settings = settings;
                        RaisePropertyChanged("Settings");
                    }
                    catch (InvalidOperationException ex) { }

                }
            }
        }
    }

    public class Settings : GalaSoft.MvvmLight.ViewModelBase
    {
        private WindowState _MainWindowState = WindowState.Normal;
        public WindowState MainWindowState
        {
            get { return _MainWindowState; }
            set { Set(ref _MainWindowState, value); }
        }

        private int _MainWindowHeight = 768;
        public int MainWindowHeight
        {
            get { return _MainWindowHeight; }
            set { Set(ref _MainWindowHeight, value); }
        }

        private int _MainWindowWidth = 1024;
        public int MainWindowWidth
        {
            get { return _MainWindowWidth; }
            set { Set(ref _MainWindowWidth, value); }
        }

        private List<string> _RecentFolders;
        public List<string> RecentFolders
        {
            get { return _RecentFolders; }
            set { Set(ref _RecentFolders, value); }
        }
    }
}


