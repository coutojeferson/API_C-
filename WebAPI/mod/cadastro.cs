using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de receitas
/// </summary>
public class Cadastro:cidade
{

    private int fId;
    private string fNome;
    private string fSobreNome;
    private string fCPF;
    private string fEmail;
    private string fEndereco;
    private string fNumeroResidencia;
    private string fBairro;
    private string fDDDTelefone;
    private string fTelefone;
    public Cadastro()
    {

    }

    public int FId { get => fId; set => fId = value; }
    public string FNome { get => fNome; set => fNome = value; }
    public string FSobreNome { get => fSobreNome; set => fSobreNome = value; }
    public string FCPF { get => fCPF; set => fCPF = value; }
    public string FEmail { get => fEmail; set => fEmail = value; }
    public string FEndereco { get => fEndereco; set => fEndereco = value; }
    public string FNumeroResidencia { get => fNumeroResidencia; set => fNumeroResidencia = value; }
    public string FBairro { get => fBairro; set => fBairro = value; }
    public string FDDDTelefone { get => fDDDTelefone; set => fDDDTelefone = value; }
    public string FTelefone { get => fTelefone; set => fTelefone = value; }

}