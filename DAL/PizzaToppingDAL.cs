using SMPizzaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SMPizzaStore.DAL;
using System.Data.Common;
using System.IO;
using SMPizzaStore.LIB;

namespace SMPizzaStore.DAL
{
    public class PizzaToppingDAL
    {
        private SqlConnection _sqlConnection;
        
        public List<PizzaModel> LoadRecords()
        {
            List<PizzaModel> output = new List<PizzaModel>();
            try
            {
                string proc = "proc_LoadPizzas ";
                using (DAL dal = new DAL())
                {
                    using (_sqlConnection = dal.Connection())
                    {
                        if (_sqlConnection.State.Equals(ConnectionState.Closed))
                        {
                            _sqlConnection.Open();
                        }

                        SqlCommand cmd = new SqlCommand(proc, _sqlConnection);
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        if (dr != null)
                        {
                            dt.Load(dr);
                        }
                        if (dt.Rows.Count > 0) 
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                var topping = new PizzaModel()
                                {
                                    Id = Convert.ToInt32(item[LIB.Constants.COL_PIZZA_ID]),
                                    Name = item[LIB.Constants.COL_PIZZA_NAME].ToString(),
                                    IsActive = item[LIB.Constants.COL_PIZZA_ISACTIVE].ToString() == "1" ? true : false,
                                    CreateBy = item[LIB.Constants.COL_PIZZA_CREATE_BY].ToString(),
                                    CreateDate = Convert.ToDateTime(item[LIB.Constants.COL_PIZZA_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
                                    ModifyBy = item[LIB.Constants.COL_PIZZA_MODIFY_BY].ToString(),
                                    ModifyDate = item[LIB.Constants.COL_PIZZA_MODIFY_DATE].ToString() == "" ? "" : Convert.ToDateTime(item[LIB.Constants.COL_PIZZA_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),

                                };
                                output.Add(topping);
                            }
                        }
                    }
                    return output;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PizzaModel LoadRecordsById(int id)
        {
            PizzaModel output = new PizzaModel();
            try
            {
                string proc = "proc_LoadPizzasbyId ";
                using (DAL dal = new DAL())
                {
                    using (_sqlConnection = dal.Connection())
                    {
                        if (_sqlConnection.State.Equals(ConnectionState.Closed))
                        {
                            _sqlConnection.Open();
                        }

                        SqlCommand cmd = new SqlCommand(proc, _sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        if (dr != null)
                        {
                            dt.Load(dr);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            var topping = new PizzaModel()
                            {
                                Id = Convert.ToInt32(dt.Rows[0][LIB.Constants.COL_PIZZA_ID]),
                                Name = dt.Rows[0][LIB.Constants.COL_PIZZA_NAME].ToString(),
                                IsActive = dt.Rows[0][LIB.Constants.COL_PIZZA_ISACTIVE].ToString() == "1" ? true : false,
                                CreateBy = dt.Rows[0][LIB.Constants.COL_PIZZA_CREATE_BY].ToString(),
                                CreateDate = Convert.ToDateTime(dt.Rows[0][LIB.Constants.COL_PIZZA_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
                                ModifyBy = dt.Rows[0][LIB.Constants.COL_PIZZA_MODIFY_BY].ToString(),
                                ModifyDate = dt.Rows[0][LIB.Constants.COL_PIZZA_MODIFY_DATE].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[0][LIB.Constants.COL_PIZZA_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
                            };
                            output = topping;
                        }
                    }
                    return output;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Create(PizzaModel topping)
        {
			try
			{
                string proc = "proc_CreatePizzas";
                using (DAL dal = new DAL())
                {
                    using (_sqlConnection = dal.Connection())
                    {
                        if (_sqlConnection.State.Equals(ConnectionState.Closed))
                        {
                            _sqlConnection.Open();
                        }
                        SqlCommand cmd = new SqlCommand(proc, _sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", topping.Name);
                        cmd.Parameters.AddWithValue("@CreateBy", "User");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
			catch (Exception ex)
			{
				throw;
			}
        }

        public void Update(int id, PizzaModel pizza)
        {
            try
            {
                string proc = "proc_UpdatePizzas";
                using (DAL dal = new DAL())
                {
                    using (_sqlConnection = dal.Connection())
                    {
                        if (_sqlConnection.State.Equals(ConnectionState.Closed))
                        {
                            _sqlConnection.Open();
                        }
                        SqlCommand cmd = new SqlCommand(proc, _sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", pizza.Name);
                        cmd.Parameters.AddWithValue("@ModifyBy", "User");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Remove(int id, PizzaModel topping)
        {
            try
            {
                string proc = "proc_DeletePizzas";
                using (DAL dal = new DAL())
                {
                    using (_sqlConnection = dal.Connection())
                    {
                        if (_sqlConnection.State.Equals(ConnectionState.Closed))
                        {
                            _sqlConnection.Open();
                        }
                        SqlCommand cmd = new SqlCommand(proc, _sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@ModifyBy", "User");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}