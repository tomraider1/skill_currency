using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DemoWindowsApplication
{
    public class DBConnect
    {
         SqlConnection connection;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
            string connectionString = "Data Source=vstsdemo.database.windows.net;Initial Catalog=VSTSDemo;Persist Security Info=False;User ID=vstsdemo;Password=Newuser@123";
            connection = new SqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                
                return false;
            }
        }


        //Insert statement
        public void Insert(Person p)
        {
            string query = "INSERT INTO tblPerson" +
                " ( [Name] , [Age] , [Phone] ) " +
                " VALUES " +
                " ( '" + p.Name + "' , " + p.Age + " , " + p.Phone + " ) ";


            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                }
                catch (Exception x)
                {
                }
                finally
                {
                    //close connection
                    this.CloseConnection();
                }
            }
        }

        //Update statement
        public void Update(Person p)
        {

            string query = "UPDATE tblPerson" +
                " SET [Name] = '" + p.Name + "'"+
                " , [Age] =  " + p.Age +
                " , [Phone] = " + p.Phone + 
                " WHERE [Id] = " + p.Id ;

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    SqlCommand cmd = new SqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception x)
                {
                }
                finally
                {
                    //close connection
                    this.CloseConnection();
                }
            }
        }

        //Delete statement
        public void Delete(int id)
        {
            string query = "DELETE FROM tblPerson WHERE [Id] = '" + id + "'";

            if (this.OpenConnection() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception x)
                {
                }
                finally
                {
                    //close connection
                    this.CloseConnection();
                }
            }
        }

        //Select statement
        public Person Select(double id)
        {
            string query = "SELECT * FROM tblPerson where Id = " + id;

            //Create a list to store the result
            Person p = new Person();

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    SqlCommand cmd = new SqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        p.Id = Convert.ToInt32(dataReader[0].ToString());
                        p.Name = dataReader[1].ToString();
                        p.Age = Convert.ToInt32(dataReader[2].ToString());
                        p.Phone = Convert.ToDouble(dataReader[3].ToString());


                    }
                    //list.Add("Name", dataReader[0].ToString());
                    //close Data Reader
                    dataReader.Close();

                }
                catch (Exception x)
                {
                }
                finally
                {
                    //close connection
                    this.CloseConnection();
                }
            }
            return p;
        }

        //Select All statement
        public List<Person> SelectAll()
        {
            string query = "SELECT * FROM [dbo].[tblPerson]";

            //Create a list to store the result
            List<Person> list = new List<Person>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    SqlCommand cmd = new SqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        Person p = new Person()
                        {
                            Id = Convert.ToInt32(dataReader[0].ToString()),
                            Name = dataReader[1].ToString(),
                            Age = Convert.ToInt32(dataReader[2].ToString()),
                            Phone = Convert.ToDouble(dataReader[3].ToString())
                        };
                        list.Add(p);
                    }

                    //close Data Reader
                    dataReader.Close();
                }
                catch (Exception x)
                {
                }
                finally
                {
                    //close connection
                    this.CloseConnection();
                }
            }
            return list;
        }


    }
}
