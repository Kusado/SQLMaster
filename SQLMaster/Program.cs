using System;
using System.Windows.Forms;

namespace SQLMaster {

  internal static class Program {

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
      //Application.ThreadException += Application_ThreadException;
      //AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1(@"d:\work\servers.json"));
    }

    private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
      MessageBox.Show(((Exception)e.ExceptionObject).Message);
    }

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
      MessageBox.Show(e.Exception.Message);
    }
  }
}