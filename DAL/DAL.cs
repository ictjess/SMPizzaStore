using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace SMPizzaStore.DAL
{
    public class DAL: IDisposable
    {
        public DAL()
        {
                    
        }
        #region -- VARIABLES -- 
        private SqlConnection _sqlConnection;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposed = false;
        #endregion -- VARIABLES -- 

        #region -- METHODS --
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SMPizzaStore.ConnectionString"].ConnectionString;
        }

        public SqlConnection Connection()
        {
            try
            {
                return new SqlConnection(GetConnectionString());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }
            // Free any unmanaged objects here.
            //
            _disposed = true;
        }
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion -- METHODS --
    }
}