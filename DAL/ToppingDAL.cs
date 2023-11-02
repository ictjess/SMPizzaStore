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
    public class ToppingDAL
    {
        private SqlConnection _sqlConnection;
        
        public List<ToppingModel> LoadRecords()
        {
            List<ToppingModel> output = new List<ToppingModel>();
            try
            {
                string proc = "proc_LoadToppings ";
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
                                var topping = new ToppingModel()
                                {
                                    Id = Convert.ToInt32(item[LIB.Constants.COL_TOPPING_ID]),
                                    Name = item[LIB.Constants.COL_TOPPING_NAME].ToString(),
                                    IsActive = item[LIB.Constants.COL_TOPPING_ISACTIVE].ToString() == "1" ? true : false,
                                    CreateBy = item[LIB.Constants.COL_TOPPING_CREATE_BY].ToString(),
                                    CreateDate = Convert.ToDateTime(item[LIB.Constants.COL_TOPPING_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
                                    ModifyBy = item[LIB.Constants.COL_TOPPING_MODIFY_BY].ToString(),
                                    ModifyDate = item[LIB.Constants.COL_TOPPING_MODIFY_DATE].ToString() == "" ? "" : Convert.ToDateTime(item[LIB.Constants.COL_TOPPING_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),

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

        public ToppingModel LoadRecordsById(int id)
        {
            ToppingModel output = new ToppingModel();
            try
            {
                string proc = "proc_LoadToppingsbyId ";
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
                            var topping = new ToppingModel()
                            {
                                Id = Convert.ToInt32(dt.Rows[0][LIB.Constants.COL_TOPPING_ID]),
                                Name = dt.Rows[0][LIB.Constants.COL_TOPPING_NAME].ToString(),
                                IsActive = dt.Rows[0][LIB.Constants.COL_TOPPING_ISACTIVE].ToString() == "1" ? true : false,
                                CreateBy = dt.Rows[0][LIB.Constants.COL_TOPPING_CREATE_BY].ToString(),
                                CreateDate = Convert.ToDateTime(dt.Rows[0][LIB.Constants.COL_TOPPING_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
                                ModifyBy = dt.Rows[0][LIB.Constants.COL_TOPPING_MODIFY_BY].ToString(),
                                ModifyDate = dt.Rows[0][LIB.Constants.COL_TOPPING_MODIFY_DATE].ToString() == "" ? "" : Convert.ToDateTime(dt.Rows[0][LIB.Constants.COL_TOPPING_CREATE_DATE]).ToString("MM/dd/yyyy hh:mm:tt"),
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

        public void Create(ToppingModel topping)
        {
			try
			{
                string proc = "proc_CreateToppings";
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

        public void Update(int id, ToppingModel topping)
        {
            try
            {
                string proc = "proc_UpdateToppings";
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
                        cmd.Parameters.AddWithValue("@Name", topping.Name);
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

        public void Remove(int id, ToppingModel topping)
        {
            try
            {
                string proc = "proc_DeleteToppings";
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

        public List<ToppingModel> LoadAvailableToppings(int pizzaId)
        {
            List<ToppingModel> output = new List<ToppingModel>();
            try
            {
                string proc = "proc_LoadAvailablePizzaToppings ";
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
                        cmd.Parameters.AddWithValue("@pizzaId", pizzaId);
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
                                var topping = new ToppingModel()
                                {
                                    Id = Convert.ToInt32(item[LIB.Constants.COL_TOPPING_ID]),
                                    Name = item[LIB.Constants.COL_TOPPING_NAME].ToString(),
                                    IsAddedToPizza = false,
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

        public List<ToppingModel> LoadAddedToppings(int pizzaId)
        {
            List<ToppingModel> output = new List<ToppingModel>();
            try
            {
                string proc = "proc_LoadAddedPizzaToppings ";
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
                        cmd.Parameters.AddWithValue("@pizzaId", pizzaId);
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
                                var topping = new ToppingModel()
                                {
                                    Id = Convert.ToInt32(item[LIB.Constants.COL_TOPPING_ID]),
                                    Name = item[LIB.Constants.COL_TOPPING_NAME].ToString(),
                                    IsAddedToPizza = true,
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

        public void AddToppingToPizza(int id, ToppingModel topping)
        {
            try
            {
                string proc = "proc_AddToppingToPizza";
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
                        cmd.Parameters.AddWithValue("@PizzaId", id);
                        cmd.Parameters.AddWithValue("@ToppingId", topping.Id);
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

        public void RemoveToppingFromPizza(int id, ToppingModel topping)
        {
            try
            {
                string proc = "proc_RemoveToppingFromPizza";
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
                        cmd.Parameters.AddWithValue("@PizzaId", id);
                        cmd.Parameters.AddWithValue("@ToppingId", topping.Id);
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