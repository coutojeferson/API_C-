using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de tipo_receitas
/// </summary>
public class cidade:usuario
{

    private int fId;
    private string fDescricao;
    public cidade()
    {
  
    }

    public int Fid_cidade { get => fId; set => fId = value; }
    public string FDescricao { get => fDescricao; set => fDescricao = value; }
}