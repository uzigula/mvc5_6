﻿
using Dominio;

namespace DataLayer.DDDContext
{
    public class UsuarioRepositorio : GenericRepository<EFYovoyRepository,Usuario>
    {
        public UsuarioRepositorio(EFYovoyRepository context) : base(context)
        {
        }
    }
}