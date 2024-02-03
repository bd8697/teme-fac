using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_MVP
{
    public class CategorieRepository
    {
        public List<Categorie> categorieRepository { get; set; }

        public CategorieRepository()
        {
            categorieRepository = GetCategorieRepo();
        }

       
        public List<Categorie> GetCategorieRepo()
        {
            List<Categorie> listOfCategorii = new List<Categorie>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //SqlConnection con= new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;"); 
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CategorieCatalog->Properties->Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Categorii", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Categorie m = new Categorie();
                    m.Title = row["Title"].ToString();

                    listOfCategorii.Add(m);
                }

                return listOfCategorii;
            }
        }

 
        public List<Categorie> GetCategorieRepoSearch(string searchQuery)
        {
            List<Categorie> listOfCategorii = new List<Categorie>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CategorieCatalog->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecordsinCategorii", conn);
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
                    Categorie m = new Categorie();
                    m.Title = row["Title"].ToString();

                    listOfCategorii.Add(m);
                }
                return listOfCategorii;
            }
        }


        public void addNewRecord(Categorie CategorieRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CategorieCatalog->Properties-?Settings.settings");
                }
                else if (CategorieRecord == null)
                    throw new Exception("The passed argument 'CategorieRecord' is null");

                SqlCommand query = new SqlCommand("addRecordinCategorii", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pTitle", SqlDbType.VarChar);

                param1.Value = CategorieRecord.Title;

                query.Parameters.Add(param1);
                query.ExecuteNonQuery();
            }
        }

     
        public void DelRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CategorieCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecordinCategorii", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }
    }
}
