using Google.Protobuf.WellKnownTypes;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;




[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class SevicoAluno
{
    public SevicoAluno()
    {
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS, PUT, DELETE");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");


       
    }


    [OperationContract]
    public void DoWork()
    {
    }


    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/usuario")]
    public List<usuario> getlistall()
    {

        var userdao = new usuariodao();
        return userdao.getAll(out string message);
    }

    
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/usuario")]
    public void Cadastraall(  usuario user)
    {
        var usuariodao = new usuariodao();
        usuariodao.Insert(user,out string message);  
    }


    [OperationContract]
    [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/usuario/{id}")]
    public void Deleteall(string id)
    {
        var userdao = new usuariodao();
        userdao.delluser(id, out string message);
    }



    //tipo de receitas
    
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cidade")]
    public void Cadastrarcidade(cidade tprec)
    {
        var cidade = new cidadedao();
        cidade.Insert(tprec, out string message);
    }

    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cidade")]
    public List<cidade> Getlistalltipos()
    {

        var cidadedao = new cidadedao();
        return cidadedao.getAll(out string message);
    }


    [OperationContract]
    [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cidade/{id}")]
    public void Deletecidades(string id)
    {
       var cidadedao = new cidadedao();
       cidadedao.dellCidade(id, out string message);
    }

    //receitas
    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cadastro")]
    public void Cadastrarreceita(Cadastro rec)
    {
        var cadastrodao = new Cadastrodao();
        cadastrodao.Insert(rec, out string message);
    }

    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cadastro")]
    public List<Cadastro> Getlistallcadastro()
    {

        var cadastrodao = new Cadastrodao();
        return cadastrodao.getAll(out string message);
    }


    [OperationContract]
    [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/cadastro/{id}")]
    public void Deletecadastro(string id)
    {
        var cadastrodao = new Cadastrodao();
        cadastrodao.DellCadastro(id, out string message);
    }
     



}
