using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

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

    public static DataTable GetDatatable(string query, SqlConnection Connection) {
      SqlCommand command = new SqlCommand(query, Connection);
      DataTable dt = new DataTable();
      dt.Load(command.ExecuteReader());
      return dt;
    }
    public static int ExecuteNonQuery(string query, SqlConnection Connection) {
      SqlCommand command = new SqlCommand(query, Connection);
      DataTable dt = new DataTable();
      int result = command.ExecuteNonQuery();
      return result;
    }
    public static T ExecuteScalar<T>(string query, SqlConnection Connection) {
      SqlCommand command = new SqlCommand(query, Connection);
      T result = (T)command.ExecuteScalar();
      return result;
    }
    public static string ExecuteScalar(string query, SqlConnection Connection) {
      SqlCommand command = new SqlCommand(query, Connection);
      string result = command.ExecuteScalar().ToString();

      return result;
    }

  }
}