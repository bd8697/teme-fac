using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class ContRepository
    {
        public List<Cont> contRepository { get; set; }

        public ContRepository()
        {
            contRepository = GetContRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Cont> GetContRepo()
        {
            List<Cont> listOfConturi = new List<Cont>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;"); 
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ContCatalog->Properties->Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Conturi", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Cont m = new Cont();
                    m.Id = (int)row["Id"];
                    m.Nume = row["Nume"].ToString();
                    m.Prenume = row["Prenume"].ToString();
                    m.E_mail = row["e_mail"].ToString();
                    m.Telefon = row["Numar_telefon"].ToString();
                    m.Adresa = row["Adresa"].ToString();
                    m.Parola = row["Parola"].ToString();
                    m.Tip_cont = (bool)row["Tip_cont"];

                    listOfConturi.Add(m);
                }

                return listOfConturi;
            }
        }

        /*
         * Function: Return records that matches the Search Query String
         * with the help of stored procedure
         */
        public List<Cont> GetContRepoSearch(string searchQuery)
        {
            List<Cont> listOfConturi = new List<Cont>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ContCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecordsinConturi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar);
                param.Value = searchQuery;
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Cont m = new Cont();
                    m.Id = (int)row["Id"];
                    m.Nume = row["Nume"].ToString();
                    m.Prenume = row["Prenume"].ToString();
                    m.E_mail = row["Adresa_e-mail"].ToString();
                    m.Telefon = row["Numar_telefon"].ToString();
                    m.Adresa = row["Adresa"].ToString();
                    m.Parola = row["Parola"].ToString();
                    m.Tip_cont = (bool)row["Tip Cont"];

                    listOfConturi.Add(m);
                }
                return listOfConturi;
            }
        }

        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addNewRecord(Cont ContRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ContCatalog->Properties-?Settings.settings");
                }
                else if (ContRecord == null)
                    throw new Exception("The passed argument 'ContRecord' is null");

                SqlCommand query = new SqlCommand("addRecordinConturi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pNume", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pPrenume", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pE_mail", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pTelefon", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pAdresa", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pParola", SqlDbType.VarChar);
                SqlParameter param7 = new SqlParameter("pTip_cont", SqlDbType.Bit);

                param1.Value = ContRecord.Nume;
                param2.Value = ContRecord.Prenume;
                param3.Value = ContRecord.E_mail;
                param4.Value = ContRecord.Telefon;
                param5.Value = ContRecord.Adresa;
                param6.Value = ContRecord.Parola;
                param7.Value = ContRecord.Tip_cont;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.Parameters.Add(param7);
                query.ExecuteNonQuery();
            }
        }

   
        public void DelRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ContCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecordinConturi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(Cont ContRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ContCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecordinConturi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pID", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNume", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pPrenume", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pE_mail", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pTelefon", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pAdresa", SqlDbType.VarChar);
                SqlParameter param7 = new SqlParameter("pParola", SqlDbType.VarChar);
                SqlParameter param8 = new SqlParameter("pTip_cont", SqlDbType.Bit);

                param1.Value = ContRecord.Id;
                param2.Value = ContRecord.Nume;
                param3.Value = ContRecord.Prenume;
                param4.Value = ContRecord.E_mail;
                param5.Value = ContRecord.Telefon;
                param6.Value = ContRecord.Adresa;
                param7.Value = ContRecord.Parola;
                param8.Value = ContRecord.Tip_cont;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.Parameters.Add(param7);
                query.Parameters.Add(param8);
                query.ExecuteNonQuery();
            }
        }
    }
}
