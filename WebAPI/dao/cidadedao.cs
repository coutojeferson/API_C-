using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// Descrição resumida de tipo_receitasdao
/// </summary>
public class cidadedao
{
    private SqlConnection conn;
    public cidadedao()
    {

    }

    public bool Insert(cidade cidades, out string message)
    {
        string sql;

        conn = new conn().getConnectionNew(out string messagem);
        try
        {

            sql = " insert into cadastro.Cidade (Id, Descricao) " +
                  "  values (" + cidades.FId + ",'" + cidades.FDescricao + "'  ) ";



            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            //conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                message = "sucesso";
                return true;
            }
            else
            {
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


    public List<cidade> getAll(out string message)
    {
        conn = new conn().getConnectionNew(out message);
        string sql;

        List<cidade> listcidades = new List<cidade>();

        sql = "select Id, Descricao FROM cadastro.Cidade";

        StringBuilder strSQL = new StringBuilder();

        strSQL.Append(sql);

        SqlCommand cmd;
        cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strSQL.ToString();

        SqlDataReader dr;
        dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            listcidades.Add(new cidade()
            {
                FId = Convert.ToInt32(dr[0].ToString()),
                FDescricao = dr[2].ToString()
            });
        }

        conn.Close();
        return listcidades;
    }




    public void dellCidade(string id, out string message)
    {

        conn = new conn().getConnectionNew(out message);
        string sql;

        sql = "delete from cadastro.Cidade";
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