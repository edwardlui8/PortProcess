using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PortProcess
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Process> systemProcesses = new ObservableCollection<Process>();

        public MainPage()
        {
            this.InitializeComponent();

            IReadOnlyList<ProcessDiagnosticInfo> processes = ProcessDiagnosticInfo.GetForProcesses();
            if (processes != null)
            {
                foreach (ProcessDiagnosticInfo process in processes)
                {
                    string exeName = process.ExecutableFileName;
                    string pid = process.ProcessId.ToString();

                    systemProcesses.Add(new Process { Name = exeName, ProcessID = pid });
                    Debug.WriteLine(exeName + " " + pid);
                }
            }
        }

        public ObservableCollection<Process> Processes
        {
            get
            {
                return systemProcesses;
            }
        }
    }
}
