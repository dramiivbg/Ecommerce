﻿using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Servicio.Contrato
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista(string buscar);
        Task<ProductoDTO> Obtener(int id);

        Task<List<ProductoDTO>> Catalogo(string categoria, string buscar);
        Task<ProductoDTO> Crear(ProductoDTO modelo);

        Task<bool> Editar(ProductoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
