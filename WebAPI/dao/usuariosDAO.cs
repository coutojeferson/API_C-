using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Descrição resumida de usuariosDAO
/// </summary>
public class usuariosDAO
{
    private SqlConnection conn;
    public usuariosDAO()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }



    public bool InsertUpdate(usuarios use, out string message)
    {
        conn = new conn().getConnectionNew(out string messagem);
         {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_USERS_IN_UP", conn);
                cmd.CommandType = CommandType.StoredProcedure;

           
                cmd.Parameters.Add("@USE_LOGIN", SqlDbType.VarChar).Value = use.AUSE_LOGIN.ToString();
                cmd.Parameters.Add("@USE_NOME", SqlDbType.VarChar).Value = use.AUSE_NOME.ToString();
              

                // Return
                cmd.Parameters.Add(new SqlParameter("@RETURN", SqlDbType.VarChar, 200));
                cmd.Parameters["@RETURN"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                string error = (string)cmd.Parameters["@RETURN"].Value;
                message = error;
                return true;
            }
            catch (SqlException erro)
            {
                message = " Erro ao inserir dados" + erro;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

    }





    public List<usuarios> getAll(int id,  out string message)
    {
        conn = new conn().getConnectionNew(out message);
         string sql;

        List<usuarios> listUsers = new List<usuarios>();


        sql = "SELECT USE_INT_ID, USE_LOGIN, USE_NOME FROM USERS";
      //  if (id > 0) {
      //      sql = sql + " where USE_INT_ID =" + id.ToString();
      //  }

        StringBuilder strSQL = new StringBuilder();
        // strSQL.Append(" SELECT USE_INT_ID, USE_LOGIN, USE_NOME FROM USERS;  ");
        strSQL.Append(sql);

        SqlCommand cmd;
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strSQL.ToString();

        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            listUsers.Add(new usuarios()
            {
                AUSE_INT_ID = Convert.ToInt32(dr[0].ToString()),
                AUSE_LOGIN = dr[1].ToString(),
                AUSE_NOME = dr[2].ToString()
           
            });
        }

        conn.Close();
        return listUsers;
    }


    public void delluser(string id ,out string message) {

        conn = new conn().getConnectionNew(out message);
        string sql;

        sql = "delete FROM USERS";
        if (id != string.Empty)
        {
            sql = sql + " where USE_INT_ID =" + id;
        }

        StringBuilder strSQL = new StringBuilder();
       
        strSQL.Append(sql);

        SqlCommand cmd;
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strSQL.ToString();

        cmd.ExecuteNonQuery();
        conn.Close();
   






    }




}