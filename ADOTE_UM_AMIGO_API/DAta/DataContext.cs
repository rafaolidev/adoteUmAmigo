using ADOTE_UM_AMIGO_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ADOTE_UM_AMIGO_API.Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Lista de propriedades que serão transformadas em tabelas no banco de dados
        public DbSet<Dog> Dogs { get; set; }
    }
}