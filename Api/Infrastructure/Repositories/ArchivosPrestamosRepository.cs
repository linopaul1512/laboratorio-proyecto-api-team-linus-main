using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ArchivosPrestamosRepository: BaseRepository<Archivos_Prestamos>, IArchivosPrestamosRepository
    {
        public ArchivosPrestamosRepository(AppDbContext context) : base(context){}
    }
}