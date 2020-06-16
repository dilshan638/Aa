using Microsoft.Data.SqlClient;
using RegBackEndNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBackEndNew.DataAccess
{
    public class RegisterManage
    {
        public static List<Register> GetAllRegister()
        {
            try
            {

                List<Register> registerlist = new List<Register>();
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();

                String sql = "SELECT *FROM RGT";
                SqlCommand command = new SqlCommand(sql,con);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Register item = new Register();
                       item.Id = reader.GetInt32(0);
                        item.RegCode = reader.GetString(0);
                        item.RegName = reader.GetString(1);
                        item.RegAge = reader.GetInt32(2);
                        registerlist.Add(item);
                    }
                }
                return registerlist;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

       
        public static  bool InsertReg(Register register)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();

                String sql = "INSERT INTO RGT(REG_CODE,REG_NAME,REG_AGE) VALUES(REG_CODE,REG_NAME,REG_AGE)";
                SqlCommand command = new SqlCommand(sql, con); 
                //command.Parameters.AddWithValue("@ID", register.id);
                command.Parameters.AddWithValue("@RED_CODE", register.RegCode);

                command.Parameters.AddWithValue("@RED_NAME", register.RegName);

                command.Parameters.AddWithValue("@RED_AGE", register.RegAge);
                command.ExecuteNonQuery();
                command.Dispose();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
