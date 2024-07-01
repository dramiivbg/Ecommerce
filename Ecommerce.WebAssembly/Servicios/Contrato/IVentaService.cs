using Ecommerce.DTO;
namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
