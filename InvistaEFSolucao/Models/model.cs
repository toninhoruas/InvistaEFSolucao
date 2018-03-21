using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace InvistaEFSolucao.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<IndicadorBiologico> IndicadoresBiologicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
    }

    public enum TipoContato
    {
        ContatoComercial = 0,
        ContatoTecnico = 1
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public Contato ContatoComercial { get; set; }
        public Contato ContatoTecnico { get; set; }
    }

    public class Contato
    {
        public int ContatoID { get; set; }
        public TipoContato Tipo { get; set; }
        public string NomePessoa { get; set; }
        public string Telefone { get; set; }
        public string Setor { get; set; }
        public string email { get; set; }        
    }

    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string CaminhoLogoEmpresa { get; set; }
        public Contato ContatoComercial { get; set; }
        
    }

    public class Equipamento
    {
        public int EquipamentoID { get; set; }
        public string NomeEquipamento { get; set; }
        public string NomeFabricante { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }

    }

    public class IndicadorBiologico
    {
        public int IndicadorBiologicoID { get; set; }
        public string Produto { get; set; }
        public string Microorganismo { get; set; }
        public string CorOriginal { get; set; }
        public string ValorD { get; set; }
        public string ValorZ { get; set; }
        public string ValorN { get; set; }
        public string CorPosterior{ get; set; }
    }

    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NomeUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string loginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
    
}
