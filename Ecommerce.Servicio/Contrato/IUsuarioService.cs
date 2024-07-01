﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Servicio.Contrato
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Lista(string rol, string buscar);
        Task<UsuarioDTO> Obtener(int id);
        Task<SessionDTO> Autorizacion(LoginDTO modelo);

        Task<UsuarioDTO> Crear(UsuarioDTO modelo);

        Task<bool> Editar(UsuarioDTO modelo);

        Task<bool> Eliminar(int id);

    }
}
