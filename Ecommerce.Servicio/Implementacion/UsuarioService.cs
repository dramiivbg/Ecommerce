﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Modelo;
using Ecommerce.DTO;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using AutoMapper;
using Microsoft.VisualBasic;

namespace Ecommerce.Servicio.Implementacion
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;

        public UsuarioService(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<SessionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {

                var consulta = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<SessionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("no se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {

            try
            {
                var dbModelo = _mapper.Map<Usuario>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdUsuario != 0)
                    return _mapper.Map<UsuarioDTO>(rspModelo);
                else throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var fromDbMdelo = await consulta.FirstOrDefaultAsync();

                if(fromDbMdelo != null)
                {
                    fromDbMdelo.NombreCompleto = modelo.NombreCompleto;
                    fromDbMdelo.Correo = modelo.Correo;
                    fromDbMdelo.Clave = modelo.Clave;
                    var respuesta = await _modeloRepositorio.Editar(fromDbMdelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;

                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try  
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbMdelo = await consulta.FirstOrDefaultAsync();

                if (fromDbMdelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbMdelo);
                    if (!respuesta) throw new TaskCanceledException("No se pudo eliminar");

                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron resultados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta =  _modeloRepositorio.Consultar(p => p.Rol == rol && string.Concat(p.NombreCompleto!.ToLower(),p.Correo!.ToLower()).Contains(buscar.ToLower()));

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<UsuarioDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
