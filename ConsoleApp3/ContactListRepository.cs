using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ContactListRepository
    {

        //SHORT WAY USE OF DAPPER TO GET TABLE EAISY PISY SHISY

        //public List<ContactListGetset> GetById()
        //{
        //    return 0;
        //}



        //selection whole data/of one table/To get All data you have in the list of table
        public List<ContactListGetset> getConacts()   //list is fuction which we can get all the data .all data is called list
        {
            string SelectWT = $"select * from tblcontactlist;";
            SqlConnection Connection = new SqlConnection(Configuration.ConnectionString);
            List<ContactListGetset> List = Connection.Query<ContactListGetset>(SelectWT).ToList();
            return List;
            //list is data structure of que or line.
        }

        //only select record through one id .
        //public ContactListGetset GetById(int id)
        //{
        //    string IDquery = $"select * from tblcontactlist where Id = {id}";
        //    SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
        //    var GetContactId = connection.QueryFirst<ContactListGetset>(IDquery);
        //    return GetContactId;
        //}



        //only select record through one id .
        public ContactListGetset GetById(int? id)
        {
            if (id == null)
            {
                Console.WriteLine("Invalid input: id is null.");
                return null;
            }

            string IDquery = $"SELECT * FROM tblcontactlist WHERE Id = {id}";
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                try
                {
                    var GetContactId = connection.QueryFirstOrDefault<ContactListGetset>(IDquery);
                    return GetContactId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return null;
                }
            }
        }



        //save data fuction // a fuction has return type
        public int saveContactlist(ContactListGetset ctnt)
        {
            string query =
                        $"INSERT INTO  [tblcontactlist] (CName, Cemail, Caddress) " +
                        $"VALUES ('{ctnt.CName}','{ctnt.Cemail}','{ctnt.Caddress}');";

            

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            int result = command.ExecuteNonQuery(); // for execute that all command this is also called ado.net 

            connection.Close();
            Console.WriteLine("your data is saved ");
            return result;
        }
      

        // delete Contact list by rows affected
        public int deleteContactlistRow(int Id)
        {

            //string query = $"DELETE FROM Contacts WHERE ID = {id};";

            string query = $"DELETE FROM tblcontactlist WHERE Id = {Id};";
            
            SqlConnection Connection = new SqlConnection(Configuration.ConnectionString);

            Connection.Open();
            SqlCommand Command = new SqlCommand(query, Connection);
            int result = Command.ExecuteNonQuery();
            Connection.Close();



            return result;
        }

        //update row wise in the table
        public int UpdateRow(ContactListGetset ctntupdate)
        {
            SqlConnection Connectin0 = new SqlConnection(Configuration.ConnectionString);
            string updateQuery0 =
                       $"UPDATE tblcontactlist " +
                       $"SET CName = '{ctntupdate.CName}',Cemail = '{ctntupdate.Cemail}',Caddress = '{ctntupdate.Caddress}' " +
                       $"WHERE ID = {ctntupdate.Id};";
            Connectin0.Open();
            SqlCommand sqlCommand = new SqlCommand(updateQuery0, Connectin0);
            int rowaffected = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Rows update: " + rowaffected);

            Connectin0.Close();
            return rowaffected;
        }
    }
}
