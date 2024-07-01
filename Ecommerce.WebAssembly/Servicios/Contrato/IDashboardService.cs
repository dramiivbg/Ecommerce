using Ecommerce.DTO;
namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
