using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descrição resumida de conn
/// </summary>
public class conn
{

    private SqlConnection con;
    public conn()
    {

    }



    public SqlConnection getConnectionNew(out string message)
    {
        message = string.Empty;

        
        con = new SqlConnection("Server=JEFERSON_PC; Initial Catalog=CLINICA; User=sa; Password=123;");

        try
        {
            if (con == null || con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            message = string.Empty;
            return con;
        }
        catch (SqlException erro)
        {
            message = "Não foi possível acessar o banco de dados ";
            return null;
        }
    }


}
