using agendadigital.entidades;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace agendadigital.EntityFramework
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public DbSet<Telefono> Telefonos { get; set; }
    }
}
