using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de usuario
/// </summary>
public class usuario
{

    private int fId;
    private string fLogin;
    private string fSenha;
    private string fAtivo; 


    public usuario()
    {

    }

    public int FId { get => fId; set => fId = value; }
    public string FLogin { get => fLogin; set => fLogin = value; }
    public string FSenha { get => fSenha; set => fSenha = value; }
    public string FAtivo { get => fAtivo; set => fAtivo = value; }
}