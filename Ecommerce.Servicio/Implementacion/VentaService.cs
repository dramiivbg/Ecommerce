using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Ecommerce.Servicio.Implementacion
{
    public class VentaService: IVentaService
    {
        private readonly IVentaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _modeloRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo registar");
                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
