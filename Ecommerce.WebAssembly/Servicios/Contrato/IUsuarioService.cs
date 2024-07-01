using Ecommerce.DTO;
namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);

        Task<ResponseDTO<UsuarioDTO>> Obtener(int id);

        Task<ResponseDTO<SessionDTO>> Autorizacion(LoginDTO modelo);

        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);

        Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo);

        Task<ResponseDTO<bool>> Eliminar(int id);


    }
}
