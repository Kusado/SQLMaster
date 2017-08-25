using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Helpers {
  public class DnsMx {
    public enum QueryOptions {
      DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 1,
      DNS_QUERY_BYPASS_CACHE = 8,
      DNS_QUERY_DONT_RESET_TTL_VALUES = 0x100000,
      DNS_QUERY_NO_HOSTS_FILE = 0x40,
      DNS_QUERY_NO_LOCAL_NAME = 0x20,
      DNS_QUERY_NO_NETBT = 0x80,
      DNS_QUERY_NO_RECURSION = 4,
      DNS_QUERY_NO_WIRE_QUERY = 0x10,
      DNS_QUERY_RESERVED = -16777216,
      DNS_QUERY_RETURN_MESSAGE = 0x200,
      DNS_QUERY_STANDARD = 0,
      DNS_QUERY_TREAT_AS_FQDN = 0x1000,
      DNS_QUERY_USE_TCP_ONLY = 2,
      DNS_QUERY_WIRE_ONLY = 0x100
    }

    public enum QueryTypes {
      DNS_TYPE_A = 1,
      DNS_TYPE_NS,
      DNS_TYPE_MD,
      DNS_TYPE_MF,
      DNS_TYPE_CNAME,
      DNS_TYPE_SOA,
      DNS_TYPE_MB,
      DNS_TYPE_MG,
      DNS_TYPE_MR,
      DNS_TYPE_NULL,
      DNS_TYPE_WKS,
      DNS_TYPE_PTR,
      DNS_TYPE_HINFO,
      DNS_TYPE_MINFO,
      DNS_TYPE_MX,
      DNS_TYPE_TEXT,
      DNS_TYPE_RP,
      DNS_TYPE_AFSDB,
      DNS_TYPE_X25,
      DNS_TYPE_ISDN,
      DNS_TYPE_RT,
      DNS_TYPE_NSAP,
      DNS_TYPE_NSAPPTR,
      DNS_TYPE_SIG,
      DNS_TYPE_KEY,
      DNS_TYPE_PX,
      DNS_TYPE_GPOS,
      DNS_TYPE_AAAA,
      DNS_TYPE_LOC,
      DNS_TYPE_NXT,
      DNS_TYPE_EID,
      DNS_TYPE_NIMLOC,
      DNS_TYPE_SRV,
      DNS_TYPE_ATMA,
      DNS_TYPE_NAPTR,
      DNS_TYPE_KX,
      DNS_TYPE_CERT,
      DNS_TYPE_A6,
      DNS_TYPE_DNAME,
      DNS_TYPE_SINK,
      DNS_TYPE_OPT,
      DNS_TYPE_DS,
      DNS_TYPE_RRSIG,
      DNS_TYPE_NSEC,
      DNS_TYPE_DNSKEY,
      DNS_TYPE_DHCID,
      DNS_TYPE_UINFO,
      DNS_TYPE_UID,
      DNS_TYPE_GID,
      DNS_TYPE_UNSPEC,
      DNS_TYPE_ADDRS,
      DNS_TYPE_TKEY,
      DNS_TYPE_TSIG,
      DNS_TYPE_IXFR,
      DNS_TYPE_AXFR,
      DNS_TYPE_MAILB,
      DNS_TYPE_MAILA,
      DNS_TYPE_ALL,
      DNS_TYPE_ANY
    }


    [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true
    )]
    public static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)] ref string pszName, QueryTypes wType,
                                      QueryOptions options, int aipServers, ref IntPtr ppQueryResults, int pReserved);

    [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);

    public static string[] GetMXRecords(string domain) {
      IntPtr ptr1 = IntPtr.Zero;
      IntPtr ptr2 = IntPtr.Zero;
      MXRecord recMx;
      if (Environment.OSVersion.Platform != PlatformID.Win32NT) throw new NotSupportedException();

      ArrayList list1 = new ArrayList();
      int num1 = DnsQuery(ref domain, QueryTypes.DNS_TYPE_MX, QueryOptions.DNS_QUERY_BYPASS_CACHE, 0, ref ptr1, 0);
      if (num1 != 0) throw new Win32Exception(num1);

      for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = recMx.pNext) {
        recMx = (MXRecord) Marshal.PtrToStructure(ptr2, typeof(MXRecord));
        if (recMx.wType == 15) {
          string text1 = Marshal.PtrToStringAuto(recMx.pNameExchange);
          list1.Add(text1);
        }
      }

      DnsRecordListFree(ptr2, 0);
      return (string[]) list1.ToArray(typeof(string));
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MXRecord {
      public readonly IntPtr pNext;
      public readonly string pName;
      public readonly short wType;
      public readonly short wDataLength;
      public readonly int flags;
      public readonly int dwTtl;
      public readonly int dwReserved;
      public readonly IntPtr pNameExchange;
      public readonly short wPreference;
      public readonly short Pad;
    }
  }

  public class NS {
    [Serializable]
    public class Host {
      [NonSerialized] private readonly IPAddress[] addresses;

      [NonSerialized] public string Domain;

      [NonSerialized] public string Name;

      [JsonConstructor]
      private Host(string FQDN) {
        Host tmp = GetHostEntry(FQDN);
        //foreach (PropertyInfo property in tmp.GetType().GetProperties(BindingFlags.DeclaredOnly)) {
        //  this.GetType().GetProperties().First(x => x.Name == property.Name)=property;
        //}
        this.FQDN = tmp.FQDN;
        this.Domain = tmp.Domain;
        this.Name = tmp.Name;
        this.addresses = tmp.addresses;
      }

      private Host(IPHostEntry ipHostEntry) {
        this.FQDN = ipHostEntry.HostName;
        this.addresses = ipHostEntry.AddressList;
        int index = this.FQDN.IndexOf(".", StringComparison.InvariantCulture);
        if (index > 0) {
          this.Name = this.FQDN.Substring(0, index);
          this.Domain = this.FQDN.Remove(0, this.Name.Length + 1);
        }
        else {
          this.Name = this.FQDN;
          this.Domain = string.Empty;
        }
      }

      public string FQDN { get; set; }

      public override string ToString() { return this.FQDN; }

      public static Host GetHostEntry(string NameOrIp) {
        IPHostEntry ipHostEntry;
        try {
          ipHostEntry = Dns.GetHostEntry(NameOrIp);
        }
        catch (SocketException socketException) {
          if (socketException.NativeErrorCode == 11001) return null;

          throw;
        }
        catch (Exception e) {
          throw e;
        }

        return new Host(ipHostEntry);
      }
    }
  }
}