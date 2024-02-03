using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class PreparatRepository
    {
        public List<Preparat> preparatRepository { get; set; }

        public PreparatRepository()
        {
            preparatRepository = GetPreparatRepo();
        }

        public List<Preparat> GetPreparatRepo()
        {
            List<Preparat> listOfPreparate = new List<Preparat>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;"); 
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PreparatCatalog->Properties->Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Preparate", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Preparat m = new Preparat();
                    m.Id = (int)row["id"];
                    m.Denumire = row["Denumire"].ToString();
                    m.Pret = (int)row["Pret"];
                    m.Cantitate = (int)row["Cantitate"];
                    m.Cantitate_Totala = (int)row["Cantitate_Totala"];
                    m.Categorie = row["Categorie"].ToString();
                    m.Alergen = row["Alergen"].ToString();

                    listOfPreparate.Add(m);
                }

                return listOfPreparate;
            }
        }

        public List<Preparat> GetPreparatRepoSearch(string searchQuery)
        {
            List<Preparat> listOfPreparate = new List<Preparat>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PreparatCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecordsinPreparate", conn);
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
                    Preparat m = new Preparat();
                    m.Id = (int)row["id"];
                    m.Denumire = row["Denumire"].ToString();
                    m.Pret = (int)row["Pret"];
                    m.Cantitate = (int)row["Cantitate"];
                    m.Cantitate_Totala = (int)row["Cantitate_Totala"];
                    m.Categorie = row["Categorie"].ToString();
                    m.Alergen = row["Alergen"].ToString();

                    listOfPreparate.Add(m);
                }
                return listOfPreparate;
            }
        }

        public void addNewRecord(Preparat PreparatRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PreparatCatalog->Properties-?Settings.settings");
                }
                else if (PreparatRecord == null)
                    throw new Exception("The passed argument 'PreparatRecord' is null");

                SqlCommand query = new SqlCommand("addRecordinPreparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pDenumire", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pPret", SqlDbType.Int);
                SqlParameter param3 = new SqlParameter("pCantitate", SqlDbType.Int);
                SqlParameter param4 = new SqlParameter("pCantitate_Totala", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pCategorie", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pAlergen", SqlDbType.VarChar);

                param1.Value = PreparatRecord.Denumire;
                param2.Value = PreparatRecord.Pret;
                param3.Value = PreparatRecord.Cantitate;
                param4.Value = PreparatRecord.Cantitate_Totala;
                param5.Value = PreparatRecord.Categorie;
                param6.Value = PreparatRecord.Alergen;

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
                    throw new Exception("Connection String is Null. Set the value of Connection String in PreparatCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecordinPreparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(Preparat PreparatRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PreparatCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecordinPreparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pDenumire", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pPret", SqlDbType.Int);
                SqlParameter param4 = new SqlParameter("pCantitate", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pCantitate_Totala", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pCategorie", SqlDbType.VarChar);
                SqlParameter param7 = new SqlParameter("pAlergen", SqlDbType.VarChar);

                param1.Value = PreparatRecord.Id;
                param2.Value = PreparatRecord.Denumire;
                param3.Value = PreparatRecord.Pret;
                param4.Value = PreparatRecord.Cantitate;
                param5.Value = PreparatRecord.Cantitate_Totala;
                param6.Value = PreparatRecord.Categorie;
                param7.Value = PreparatRecord.Alergen;

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
    }
}