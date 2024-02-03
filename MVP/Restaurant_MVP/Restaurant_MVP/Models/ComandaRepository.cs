using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class ComandaRepository
    {
        public List<Comanda> comandaRepository { get; set; }

        public ComandaRepository()
        {
            comandaRepository = GetComandaRepo();
        }


        public List<Comanda> GetComandaRepo()
        {
            List<Comanda> listOfComenzi = new List<Comanda>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;"); 
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ComandaCatalog->Properties->Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Comenzi", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Comanda m = new Comanda();
                    m.Id = (int)row["Id"];
                    m.Cod = (int)row["Cod"];
                    m.Client = row["Client"].ToString();
                    m.Continut = row["Continut"].ToString();
                    m.Pret = (int)row["Pret"];
                    m.Stare = row["Stare"].ToString();
                    m.Data = row["Data"].ToString();
                    m.Ora_Livrare = row["Ora_Livrare"].ToString();

                    listOfComenzi.Add(m);
                }

                return listOfComenzi;
            }
        }


        public List<Comanda> GetComandaRepoSearch(string searchQuery)
        {
            List<Comanda> listOfComenzi = new List<Comanda>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ComandaCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecordsinComenzi", conn);
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
                    Comanda m = new Comanda();
                    m.Id = (int)row["Id"];
                    m.Cod = (int)row["Cod"];
                    m.Client = row["Client"].ToString();
                    m.Continut = row["Continut"].ToString();
                    m.Pret = (int)row["Pret"];
                    m.Stare = row["Stare"].ToString();
                    m.Data = row["Data"].ToString();
                    m.Ora_Livrare = row["Ora_Livrare"].ToString();

                    listOfComenzi.Add(m);
                }
                return listOfComenzi;
            }
        }

 
        public void addNewRecord(Comanda ComandaRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ComandaCatalog->Properties-?Settings.settings");
                }
                else if (ComandaRecord == null)
                    throw new Exception("The passed argument 'ComandaRecord' is null");

                SqlCommand query = new SqlCommand("addRecordinComenzi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pClient", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pContinut", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pPret", SqlDbType.Int);
                SqlParameter param4 = new SqlParameter("pStare", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pData", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pOra_Livrare", SqlDbType.VarChar);

                param1.Value = ComandaRecord.Client;
                param2.Value = ComandaRecord.Continut;
                param3.Value = ComandaRecord.Pret;
                param4.Value = ComandaRecord.Stare;
                param5.Value = ComandaRecord.Data;
                param6.Value = ComandaRecord.Ora_Livrare;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.ExecuteNonQuery();
            }
        }

        public void DelRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ComandaCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecordinComenzi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(Comanda ComandaRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in ComandaCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecordinComenzi", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pID", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pCod", SqlDbType.Int);
                SqlParameter param3 = new SqlParameter("pClient", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pContinut", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pPret", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pStare", SqlDbType.VarChar);
                SqlParameter param7 = new SqlParameter("pData", SqlDbType.VarChar);
                SqlParameter param8 = new SqlParameter("pOra_Livrare", SqlDbType.VarChar);

                param1.Value = ComandaRecord.Id;
                param2.Value = ComandaRecord.Cod;
                param3.Value = ComandaRecord.Client;
                param4.Value = ComandaRecord.Continut;
                param5.Value = ComandaRecord.Pret;
                param6.Value = ComandaRecord.Stare;
                param7.Value = ComandaRecord.Data;
                param8.Value = ComandaRecord.Ora_Livrare;

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

