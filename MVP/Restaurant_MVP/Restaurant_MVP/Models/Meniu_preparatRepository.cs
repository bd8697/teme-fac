using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class Meniu_preparatRepository
    {
        public List<Meniu_preparat> preparatRepository { get; set; }

        public Meniu_preparatRepository()
        {
            preparatRepository = GetMeniu_preparatRepo();
        }

        public List<Meniu_preparat> GetMeniu_preparatRepo()
        {
            List<Meniu_preparat> listOfMeniu_preparate = new List<Meniu_preparat>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;"); 
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in Meniu_preparatCatalog->Properties->Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Meniuri_Preparate", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Meniu_preparat m = new Meniu_preparat();
                    m.Id = (int)row["id"];
                    m.Denumire = row["Denumire"].ToString();
                    m.Pret = row["Pret"].ToString();
                    m.Cantitate = row["Cantitate"].ToString();
                    m.Cantitate_Totala = row["Cantitate_Totala"].ToString();
                    m.Categorie = row["Categorie"].ToString();
                    m.Alergen = row["Alergen"].ToString();

                    listOfMeniu_preparate.Add(m);
                }

                return listOfMeniu_preparate;
            }
        }

        public List<Meniu_preparat> GetMeniu_preparatRepoSearch(string searchQuery)
        {
            List<Meniu_preparat> listOfMeniu_preparate = new List<Meniu_preparat>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in Meniu_preparatCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecordsinMeniuri_Preparate", conn);
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
                    Meniu_preparat m = new Meniu_preparat();
                    m.Id = (int)row["id"];
                    m.Denumire = row["Denumire"].ToString();
                    m.Pret = row["Pret"].ToString();
                    m.Cantitate = row["Cantitate"].ToString();
                    m.Cantitate_Totala = row["Cantitate_Totala"].ToString();
                    m.Categorie = row["Categorie"].ToString();
                    m.Alergen = row["Alergen"].ToString();

                    listOfMeniu_preparate.Add(m);
                }
                return listOfMeniu_preparate;
            }
        }

        public void addNewRecord(Meniu_preparat Meniu_preparatRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in Meniu_preparatCatalog->Properties-?Settings.settings");
                }
                else if (Meniu_preparatRecord == null)
                    throw new Exception("The passed argument 'Meniu_preparatRecord' is null");

                SqlCommand query = new SqlCommand("addRecordinMeniuri_Preparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pDenumire", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pPret", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pCantitate", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pCantitate_Totala", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pCategorie", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pAlergen", SqlDbType.VarChar);

                param1.Value = Meniu_preparatRecord.Denumire;
                param2.Value = Meniu_preparatRecord.Pret;
                param3.Value = Meniu_preparatRecord.Cantitate;
                param4.Value = Meniu_preparatRecord.Cantitate_Totala;
                param5.Value = Meniu_preparatRecord.Categorie;
                param6.Value = Meniu_preparatRecord.Alergen;

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
                    throw new Exception("Connection String is Null. Set the value of Connection String in Meniu_preparatCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecordinMeniuri_Preparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(Meniu_preparat Meniu_preparatRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in Meniu_preparatCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecordinMeniuri_Preparate", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pDenumire", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pPret", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pCantitate", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pCantitate_Totala", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pCategorie", SqlDbType.VarChar);
                SqlParameter param7 = new SqlParameter("pAlergen", SqlDbType.VarChar);

                param1.Value = Meniu_preparatRecord.Id;
                param2.Value = Meniu_preparatRecord.Denumire;
                param3.Value = Meniu_preparatRecord.Pret;
                param4.Value = Meniu_preparatRecord.Cantitate;
                param5.Value = Meniu_preparatRecord.Cantitate_Totala;
                param6.Value = Meniu_preparatRecord.Categorie;
                param7.Value = Meniu_preparatRecord.Alergen;

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