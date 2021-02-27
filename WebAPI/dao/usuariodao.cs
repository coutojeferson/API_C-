using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Descrição resumida de usuariodao
/// </summary>
public class usuariodao
{
    private SqlConnection conn;
    public usuariodao()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
    public bool Insert(usuario use, out string message)
    {
        string sql;
      
        conn = new conn().getConnectionNew( out string messagem);
            try
            {

                sql = " insert into seguranca.Usuario (Login, Senha, Ativo) " +
                      "  values ('"+ use.FLogin +"','"+use.FSenha+"','"+use.FAtivo+"'  ) ";
                    


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) {
                    message = "sucesso";
                    return true;
            }
            else {
                message = "erro";
                   return false;
            }
                    
                
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


    public List<usuario> getAll( out string message)
    {
        conn = new conn().getConnectionNew(out message);
        string sql;

        List<usuario> listUsuarios = new List<usuario>();


        sql = "select Id, Login, Senha, Ativo FROM seguranca.Usuario";

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
            listUsuarios.Add(new usuario()
            {
                FId = Convert.ToInt32(dr[0].ToString()),
                FLogin  = dr[1].ToString(),
                FSenha = dr[2].ToString(),
                FAtivo = dr[3].ToString()

            });
        }

        conn.Close();
        return listUsuarios;
    }



    public void delluser(string id, out string message)
    {

        conn = new conn().getConnectionNew(out message);
        string sql;

        sql = "delete from usuarios";
        if (id != string.Empty)
        {
            sql = sql + " where id =" + id;
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