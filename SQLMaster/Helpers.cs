using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace SQLMaster {
  public class Helpers {
    public static bool PingHost(string nameOrAddress, int timeout = 500) {
      return PingHost(nameOrAddress, timeout, out IPStatus b);
    }
    public static bool PingHost(string nameOrAddress, int timeout, out IPStatus status) {
      status = IPStatus.Unknown;
      bool pingable = false;
      Ping pinger = new Ping();
      try {
        PingReply reply = pinger.Send(nameOrAddress, timeout);
        status = reply.Status;
        pingable = status == IPStatus.Success;
      }
      catch (PingException) {
        // Discard PingExceptions and return false;
      }
      return pingable;
    }

  }
}