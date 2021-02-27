using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Descrição resumida de receitasdao
/// </summary>
public class Cadastrodao
{

    private SqlConnection conn;
    public Cadastrodao()
    {
    }

    public bool Insert(Cadastro rec, out string message)
    {
        string sql;

        conn = new conn().getConnectionNew(out string messagem);
        try
        {

            sql = " insert into cadastro.Paciente (Id, Nome, SobreNome, CPF, Email, Endereco, NumeroResidencia, Bairro, DDDTelefone, Telefone) " +
                  "  values (" + rec.FId + "," +
                  "'" + rec.FNome + "'," +
                  "'" + rec.FSobreNome + "'," +
                  "'" + rec.FCPF + "'," +
                  "'" + rec.FEmail + "'," +
                  "'" + rec.FEndereco + "'," +
                  "'" + rec.FNumeroResidencia + "'," +
                  "'" + rec.FBairro + "'," +
                  "'" + rec.FDDDTelefone + "'," +
                  "'" + rec.FTelefone + "'  ) ";



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



    public List<Cadastro> getAll(out string message)
    {
        conn = new conn().getConnectionNew(out message);
        string sql;

        List<Cadastro> listcadastro = new List<Cadastro>();

        sql = "select Id, Nome, SobreNome, CPF, Email, Endereco, NumeroResidencia, Bairro, DDDTelefone, Telefone FROM cadastro.Paciente";

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
            listcadastro.Add(new Cadastro()
            {
                FId = Convert.ToInt32(dr[0].ToString()),
                FNome = dr[1].ToString(),
                FSobreNome = dr[2].ToString(),
                FCPF = dr[3].ToString(),
                FEmail = dr[4].ToString(),
                FEndereco = dr[5].ToString(),
                FNumeroResidencia = dr[6].ToString(),
                FBairro = dr[7].ToString(),
                FDDDTelefone = dr[8].ToString(),
                FTelefone = dr[9].ToString()

            });
        }

        conn.Close();
        return listcadastro;
    }



    public void DellCadastro(string id, out string message)
    {

        conn = new conn().getConnectionNew(out message);
        string sql;

        sql = "delete from cadastro.Paciente";
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