﻿using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class UsuarioService: IUsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");

        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        }
    }
}
