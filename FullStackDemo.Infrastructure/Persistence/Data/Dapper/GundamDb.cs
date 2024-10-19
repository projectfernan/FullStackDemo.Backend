using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDemo.Infrastructure.Persistence.Data.Dapper
{
    // Interface for GundamDb providing methods for data access
    public interface IGundamDb 
    {
        Task<IEnumerable<T>> ReadDataAsync<T, U>(string sql, U parameter);
        Task<(IEnumerable<T1> Data, int TotalCount)> ReadMultipleDataAsync<T1, U>(string sql, U parameter);
    }

    // Implementation of IGundamDb using Dapper for database operations
    public class GundamDb : IGundamDb
    {
        private readonly IConfiguration _configuration; 

        public GundamDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Reads a single dataset asynchronously
        public async Task<IEnumerable<T>> ReadDataAsync<T, U>(string sql, U parameter)
        {
            IEnumerable<T> list = new List<T>();

            try
            {
                using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("GundamDb")))
                {
                    list = parameter != null
                         ? await conn.QueryAsync<T>(sql, parameter) // Use parameterized query
                         : await conn.QueryAsync<T>(sql); // Execute without parameters
                }
            }
            catch (Exception ex) {
                throw new ApplicationException(
                  ex.InnerException != null ? "InnerException Error: " : "Exception Error: ",
                  ex.InnerException ?? ex
                  );
            }

            return list;  // Return the list of results
        }

        // Reads multiple datasets asynchronously and returns a tuple with data and total count
        public async Task<(IEnumerable<T1> Data, int TotalCount)> ReadMultipleDataAsync<T1, U>(string sql, U parameter)
        {
            IEnumerable<T1> data = new List<T1>();
            int totalCount = 0;

            try
            {
                using (IDbConnection conn = new SqlConnection(_configuration.GetConnectionString("GundamDb")))
                {
                    using (var multi = await conn.QueryMultipleAsync(sql, parameter, commandType: CommandType.StoredProcedure))
                    {
                        data = multi.Read<T1>().ToList(); // Map first result set to T1 (Data)
                        totalCount = multi.Read<int>().Single(); // Map second result set to TotalCount
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                ex.InnerException != null ? "InnerException Error: " : "Exception Error: ",
                ex.InnerException ?? ex
                );
            }

            return (data, totalCount); // Return a tuple containing Data and TotalCount
        }
    }
}
