using ADOTE_UM_AMIGO_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ADOTE_UM_AMIGO_API.Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Lista de propriedades que serão transformadas na tabela dogs
        public DbSet<Dog> Dogs { get; set; }
        // Lista de propriedades que serão transformadas na tabela tutores
        public DbSet<Tutor> Tutores { get; set; }
        // Lista de propriedades que serão transformadas na tabela mensagens
        public DbSet<Mensagem> Mensagens { get; set; }
    }
}