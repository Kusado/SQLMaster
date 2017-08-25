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
      CheckConnection(Connection);
      SqlCommand command = new SqlCommand(query, Connection);
      DataTable dt = new DataTable();
      try {
        dt.Load(command.ExecuteReader());
      }
      catch (SqlException e) {
        Console.WriteLine(e);
        throw;
      }

      return dt;
    }

    public static IAsyncResult ExecuteNonQuery(string query, SqlConnection Connection, int timeout = 30) {
      CheckConnection(Connection);
      SqlCommand command = new SqlCommand(query, Connection) {CommandTimeout = timeout};
      DataTable dt = new DataTable();
      //int result = ;
      return command.BeginExecuteNonQuery();
    }

    public static T ExecuteScalar<T>(string query, SqlConnection Connection) {
      CheckConnection(Connection);
      SqlCommand command = new SqlCommand(query, Connection);
      return (T) command.ExecuteScalar();
    }

    public static string ExecuteScalar(string query, SqlConnection Connection) {
      CheckConnection(Connection);
      SqlCommand command = new SqlCommand(query, Connection);
      string result = command.ExecuteScalar().ToString();

      return result;
    }

    public static void CheckConnection(SqlConnection connection) {
      switch (connection.State) {
        case ConnectionState.Closed:
          connection.Open();
          break;
        case ConnectionState.Open:
          break;
        case ConnectionState.Connecting:
        case ConnectionState.Executing:
        case ConnectionState.Fetching:
        case ConnectionState.Broken:
          connection.Close();
          connection.Open();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}