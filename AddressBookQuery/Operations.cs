using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookQuery
{
    public class Operations
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionStr = "data source = (localdb)\\MSSQLLocalDB; initial catalog = AddressBookService; integrated security = true";
            con = new SqlConnection(connectionStr);
        }
        public void AddContact(AddressBook obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", obj.FirstName);
                com.Parameters.AddWithValue("@lastName", obj.LastName);
                com.Parameters.AddWithValue("@address", obj.Address);
                com.Parameters.AddWithValue("@city", obj.City);
                com.Parameters.AddWithValue("@state", obj.State);
                com.Parameters.AddWithValue("@zip", obj.Zip);
                com.Parameters.AddWithValue("@phoneNumber", obj.PhoneNumber);
                com.Parameters.AddWithValue("@email", obj.Email);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Contact Added");
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateContact(AddressBook obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("UpdateContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", obj.FirstName);
                com.Parameters.AddWithValue("@lastName", obj.LastName);
                com.Parameters.AddWithValue("@address", obj.Address);
                com.Parameters.AddWithValue("@city", obj.City);
                com.Parameters.AddWithValue("@state", obj.State);
                com.Parameters.AddWithValue("@zip", obj.Zip);
                com.Parameters.AddWithValue("@phoneNumber", obj.PhoneNumber);
                com.Parameters.AddWithValue("@email", obj.Email);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Contact Updated");
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteContact(string FirstName)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("DeleteContact", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@firstName", FirstName);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Contact Deleted");
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void City(string city)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("City", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@city", city);
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> addressBook = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            FirstName = Convert.ToString(dr["firstName"]),
                            LastName = Convert.ToString(dr["lastName"]),
                            Address = Convert.ToString(dr["address"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Zip = Convert.ToInt32(dr["zip"]),
                            PhoneNumber = Convert.ToString(dr["phoneNumber"]),
                            Email = Convert.ToString(dr["email"]),
                        });
                }
                Console.WriteLine("The persons in city " + city + " are: ");
                foreach (var data in addressBook)
                {
                    Console.WriteLine(data.FirstName + " " + data.LastName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void State(string state)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("State", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@state", state);
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> addressBook = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            FirstName = Convert.ToString(dr["firstName"]),
                            LastName = Convert.ToString(dr["lastName"]),
                            Address = Convert.ToString(dr["address"]),
                            City = Convert.ToString(dr["city"]),
                            State = Convert.ToString(dr["state"]),
                            Zip = Convert.ToInt32(dr["zip"]),
                            PhoneNumber = Convert.ToString(dr["phoneNumber"]),
                            Email = Convert.ToString(dr["email"]),
                        });
                }
                Console.WriteLine("The persons in the state " + state + " are: ");
                foreach (var data in addressBook)
                {
                    Console.WriteLine(data.FirstName + " " + data.LastName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SizeByCity()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SizeByCity", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> addressBook = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            City = Convert.ToString(dr["city"]),
                            Count = Convert.ToInt32(dr["count"])
                        });
                }
                Console.WriteLine("No.of persons in each city are ");
                foreach (var data in addressBook)
                {
                    Console.WriteLine(data.City + "--" + data.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void SizeByState()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SizeByState", con);
                com.CommandType = CommandType.StoredProcedure;
                con.Open();
                int i = com.ExecuteNonQuery();
                List<AddressBook> addressBook = new List<AddressBook>();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            State = Convert.ToString(dr["state"]),
                            Count = Convert.ToInt32(dr["count"])
                        });
                }
                Console.WriteLine("No.of persons in each state are ");
                foreach (var data in addressBook)
                {
                    Console.WriteLine(data.State + "--" + data.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void CountByType()
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("CountByType", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                List<AddressBook> addressBook = new List<AddressBook>();
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            Type = Convert.ToString(dr["type"]),
                            Count = Convert.ToInt32(dr["count"])
                        });
                }
                Console.WriteLine("No.of persons in each type are: ");
                foreach (var data in addressBook)
                {
                    Console.WriteLine(data.Type + "--" + data.Count);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void CreateAddPerson()
        {
            try
            {
                Connection();
                string query = "Create table AddPerson(id int primary key identity(1,1), " +
                    "contactId int Foreign Key References AddressBook(id), " +
                    "type int Foreign Key References type(id));";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Created table Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No table Created " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        public void AddPersonValues(AddressBook obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("AddPersonValues", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@contactId", obj.Id);
                com.Parameters.AddWithValue("@type", obj.Type);
                con.Open();
                com.ExecuteNonQuery();
                Console.WriteLine("Contact Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UsingWithThread(List<AddressBook> list)
        {
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Being Added:" + data.FirstName);
                    AddContact(data);
                    Console.WriteLine("Added:" + data.FirstName);
                });
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration with Thread: " + (end - start));
        }
        public void UsingWithoutThread(List<AddressBook> list)
        {
            DateTime start = DateTime.Now;
            foreach (var data in list)
            {
                AddContact(data);
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("Duration without Thread: " + (end - start));
        }
       
    }
}
