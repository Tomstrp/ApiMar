using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ApiMar.Services
{
	public class OracleService
	{
		string[] _connectionStrings;

		public OracleService(string[] connectionStrings)
		{
			_connectionStrings = connectionStrings;
		}

		public async Task<DataSet> FillDataset(string query, Dictionary<string, object>? dict = null, ILogger? logger = null)
		{
			OracleConnection? conn = null;
			var ds = new DataSet();

			foreach (string? connectionString in _connectionStrings)
			{
				try
				{
					conn = new OracleConnection(connectionString);
					conn.Open();
					var cmd = new OracleCommand(query, conn);
					if (dict != null)
						dict.Select(x => cmd.Parameters.Add(x.Key, x.Value)).ToList();

					cmd.BindByName = true;
					await cmd.ExecuteNonQueryAsync();

					var da = new OracleDataAdapter(cmd);
					var dt = new DataTable();
					da.Fill(dt);
					ds.Tables.Add(dt);
				}
				catch (Exception ex)
				{
					if (logger != null)
						logger.LogCritical(ex.Message);
				}
				finally
				{
					if (conn != null) conn.Close();
				}
			}
			return ds;
		}


		//public DataSet FillDataset(string query, Dictionary<string, object>? dict = null, ILogger? logger = null)
		//{
		//	var ds = new DataSet();

		//	foreach (string? connectionString in _connectionStrings)
		//	{
		//		try
		//		{
		//			using var conn = new OracleConnection(connectionString);
		//			conn.Open();

		//			using var cmd = new OracleCommand(query, conn) { BindByName = true };

		//			if (dict != null)
		//				foreach (var kv in dict)
		//					cmd.Parameters.Add(kv.Key, kv.Value);

		//			using var da = new OracleDataAdapter(cmd);
		//			var dt = new DataTable();
		//			da.Fill(dt);
		//			ds.Tables.Add(dt);
		//		}
		//		catch (Exception ex)
		//		{
		//			logger?.LogError(ex, "Errore durante l'esecuzione della query Oracle.");
		//		}
		//	}
		//	return ds;
		//}

	}
}
