using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLlite_Windows
{
    public class SqliteDataAccess
    {
        public static List<UniversityModel> LoadUniversity()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(GetConnectionString()))
                {
                    var lst = cnn.Query<UniversityModel>("Select * from University", new DynamicParameters());
                    return lst.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void SaveUniversity(UniversityModel universityModel)
        {
            try
            {


                using (SQLiteConnection conn = new SQLiteConnection(GetConnectionString()))
                {
                    conn.Open();

                    using (var cmd = new SQLiteCommand(@"Insert into university (" +
                        "Project_Code,Organisation,Programme_Name,Source_of_Funding," +
                        "Program_Leader,Approval_Date,Approval_Amount,First_Payment_Date,Second_Payment_Date," +
                        "Third_Payment_Date,Fourth_Payment_Date,Fifth_Payment_Date,First_Payment_Amount,Second_Payment_Amount," +
                        "Third_Payment_Amount,Foruth_Payment_Amount,Fifth_Payment_Amount,First_Payment_Cheque_Number," +
                        "Second_Payment_Cheque_Number,Third_Payment_Cheque_Number,Fourth_Payment_Cheque_Number,Fifth_Payment_Cheque_Number,Payment_Bank,Payment_Bank_Account_Number) values(?, ?,?,?,?,?,?,?,?,?,?,?,?, ?,?,?,?,?,?,?,?,?,?,?)", conn))
                    {

                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Project_Code });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Organisation });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Programme_Name });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Source_of_Funding });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Program_Leader });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Approval_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Approval_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.First_Payment_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Second_Payment_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Third_Payment_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Fourth_Payment_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Fifth_Payment_Date });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.Decimal, Value = universityModel.First_Payment_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.Decimal, Value = universityModel.Second_Payment_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.Decimal, Value = universityModel.Third_Payment_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.Decimal, Value = universityModel.Foruth_Payment_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.Decimal, Value = universityModel.Fifth_Payment_Amount });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.First_Payment_Cheque_Number });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Second_Payment_Cheque_Number });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Third_Payment_Cheque_Number });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Fourth_Payment_Cheque_Number });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Fifth_Payment_Cheque_Number });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Payment_Bank });
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = universityModel.Payment_Bank_Account_Number });

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public static UniversityModel GetUniversityByProjectCode(string code)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(GetConnectionString()))
                {
                    conn.Open();

                    string stm = "SELECT * FROM university Where Project_Code=?";

                    using (var cmd = new SQLiteCommand(stm, conn))
                    {
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = code });

                        SQLiteDataReader rdr = cmd.ExecuteReader();

                        UniversityModel ob = new UniversityModel();
                        while (rdr.Read())
                        {
                            ob.Project_Code = rdr["Project_Code"].ToString();
                            ob.Organisation = rdr["Organisation"].ToString();
                            ob.Programme_Name = rdr["Programme_Name"].ToString();
                            ob.Source_of_Funding = rdr["Source_of_Funding"].ToString();
                            ob.Program_Leader = rdr["Program_Leader"].ToString();
                            ob.Approval_Date = rdr["Approval_Date"].ToString();
                            ob.Approval_Amount = rdr["Approval_Amount"].ToString();
                            ob.First_Payment_Date = rdr["First_Payment_Date"].ToString();
                            ob.Second_Payment_Date = rdr["Second_Payment_Date"].ToString();
                            ob.Third_Payment_Date = rdr["Third_Payment_Date"].ToString();
                            ob.Fourth_Payment_Date = rdr["Fourth_Payment_Date"].ToString();
                            ob.Fifth_Payment_Date = rdr["Fifth_Payment_Date"].ToString();
                            ob.First_Payment_Amount = Convert.ToDecimal(rdr["First_Payment_Amount"]);
                            ob.Second_Payment_Amount = Convert.ToDecimal(rdr["Second_Payment_Amount"]);
                            ob.Third_Payment_Amount = Convert.ToDecimal(rdr["Third_Payment_Amount"]);
                            ob.Foruth_Payment_Amount = Convert.ToDecimal(rdr["Foruth_Payment_Amount"]);
                            ob.Fifth_Payment_Amount = Convert.ToDecimal(rdr["Fifth_Payment_Amount"]);
                            ob.First_Payment_Cheque_Number = rdr["First_Payment_Cheque_Number"].ToString();
                            ob.Second_Payment_Cheque_Number = rdr["Second_Payment_Cheque_Number"].ToString();
                            ob.Third_Payment_Cheque_Number = rdr["Third_Payment_Cheque_Number"].ToString();
                            ob.Fourth_Payment_Cheque_Number = rdr["Fourth_Payment_Cheque_Number"].ToString();
                            ob.Fifth_Payment_Cheque_Number = rdr["Fifth_Payment_Cheque_Number"].ToString();
                            ob.Payment_Bank = rdr["Payment_Bank"].ToString();
                            ob.Payment_Bank_Account_Number = rdr["Payment_Bank_Account_Number"].ToString();

                        }


                        return ob;

                    }




                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public static void DeleteUniversity(string ProjectCode)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(GetConnectionString()))
                {
                    conn.Open();

                    string stm = "Delete FROM university Where Project_Code=?";

                    using (var cmd = new SQLiteCommand(stm, conn))
                    {
                        cmd.Parameters.Add(new SQLiteParameter { DbType = DbType.String, Value = ProjectCode });
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
