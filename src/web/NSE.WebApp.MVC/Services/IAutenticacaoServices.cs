using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoServices
    {
        Task<string> Login(UsuarioLogin usuariologin);
        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }

}
