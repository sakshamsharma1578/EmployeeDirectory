using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using AddressBookApp.VO;
using AddressBookApp.DL.ITF;

namespace AddressBookApp.DL
{
    public class AddressDL : IAddressDL
    {
        private readonly string connectionString;

        public AddressDL(string conn)
        {
            connectionString = conn;
        }

        public int Insert(AddressVO address)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO AddressEntries (FullName, Phone, Email, Gender, DOB, Address, City, Pincode, Department, Status, Skills, MaritalStatus) " +
                                   "OUTPUT INSERTED.Id VALUES (@FullName, @Phone, @Email, @Gender, @DOB, @Address, @City, @Pincode, @Department, @Status, @Skills, @MaritalStatus)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", address.FullName);
                        cmd.Parameters.AddWithValue("@Phone", address.Phone);
                        cmd.Parameters.AddWithValue("@Email", (object)address.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", (object)address.Gender ?? DBNull.Value);

                        var dobParam = new SqlParameter("@DOB", SqlDbType.Date);
                        dobParam.Value = (address.DOB == default(DateTime)) ? (object)DBNull.Value : address.DOB;
                        cmd.Parameters.Add(dobParam);

                        cmd.Parameters.AddWithValue("@Address", (object)address.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@City", (object)address.City ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Pincode", (object)address.Pincode ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@Department", (object)address.Department ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", (object)address.Status ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Skills", (object)address.Skills ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaritalStatus", (object)address.MaritalStatus ?? DBNull.Value);

                        conn.Open();
                        object res = cmd.ExecuteScalar();
                        return res != null ? Convert.ToInt32(res) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public bool Update(AddressVO address)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE AddressEntries SET FullName=@FullName, Phone=@Phone, Email=@Email, Gender=@Gender, DOB=@DOB, " +
                                   "Address=@Address, City=@City, Pincode=@Pincode, Department=@Department, Status=@Status, Skills=@Skills, MaritalStatus=@MaritalStatus WHERE Id=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", address.Id);
                        cmd.Parameters.AddWithValue("@FullName", address.FullName);
                        cmd.Parameters.AddWithValue("@Phone", address.Phone);
                        cmd.Parameters.AddWithValue("@Email", (object)address.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Gender", (object)address.Gender ?? DBNull.Value);

                        var dobParam = new SqlParameter("@DOB", SqlDbType.Date);
                        dobParam.Value = (address.DOB == default(DateTime)) ? (object)DBNull.Value : address.DOB;
                        cmd.Parameters.Add(dobParam);

                        cmd.Parameters.AddWithValue("@Address", (object)address.Address ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@City", (object)address.City ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Pincode", (object)address.Pincode ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@Department", (object)address.Department ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Status", (object)address.Status ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Skills", (object)address.Skills ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaritalStatus", (object)address.MaritalStatus ?? DBNull.Value);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM AddressEntries WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public AddressVO GetById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM AddressEntries WHERE Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapReader(reader);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        public List<AddressVO> GetAll()
        {
            List<AddressVO> list = new List<AddressVO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM AddressEntries ORDER BY FullName";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(MapReader(reader));
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return list;
        }

        private AddressVO MapReader(SqlDataReader reader)
        {
            return new AddressVO
            {
                Id = (int)reader["Id"],
                FullName = reader["FullName"].ToString(),
                Phone = reader["Phone"].ToString(),
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : null,
                DOB = reader["DOB"] != DBNull.Value ? (DateTime)reader["DOB"] : default(DateTime),
                Age = reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                City = reader["City"] != DBNull.Value ? reader["City"].ToString() : null,
                Pincode = reader["Pincode"] != DBNull.Value ? reader["Pincode"].ToString() : null,
                CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : default(DateTime),
                Department = reader["Department"] != DBNull.Value ? reader["Department"].ToString() : null,
                Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : null,
                Skills = reader["Skills"] != DBNull.Value ? reader["Skills"].ToString() : null,
                MaritalStatus = reader["MaritalStatus"] != DBNull.Value ? reader["MaritalStatus"].ToString() : null
            };
        }
    }
}
